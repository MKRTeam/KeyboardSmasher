using System;
using System.Windows.Forms;
using Gameplay;
using Gameplay.ExerciseMachine;

namespace KeyboardSmasher.ExerciseMachine.GUI
{
    public enum MistakeCountControlResult
    {
        NO_RESULT,
        PAUSE,
        RESUME,
        EXIT
    }

    public partial class MistakeCountControl : UserControl
    {
        public delegate void MistakeCountControlResultProc(MistakeCountControlResult result);
        event MistakeCountControlResultProc OnControlResultChanged;
        private MistakeCountControlResult result;

        private MistakeCountControlResult Result
        {
            get { return result; }
            set
            {
                result = value;
                OnControlResultChanged(result);
            }
        }

        private enum ControlMode
        {
            ControlStarted,
            TypingStarted,
            TypingStopped,
            TypingFinished
        }

        private ControlMode CurrentControlMode { get; set; }
        private MistakeCount mistakeCount;
        private MistakeCountStatistic statistic;
        private Language lang;
        private char[] symbols;

        private static readonly string welcome_text = @"Добро пожаловать в тренажёр ""Подсчет ошибок""! На полосе сверху отображен текст. " +
                "Ваша задача - набрать его с нименьшим количеством ошибок или опечаток. Время на задание неограничено. " +
                "Нажмите клавишу 'Enter', чтобы начать.";

        public MistakeCountControl(Language lang, Difficulty difficulty, MistakeCountControlResultProc handler)
        {
            InitializeComponent();
            this.lang = lang;
            lbTaskText.Text = welcome_text;
            CurrentControlMode = ControlMode.ControlStarted;
            statistic = new MistakeCountStatistic();
            mistakeCount = new MistakeCount(lang, difficulty);
            OnControlResultChanged += handler;
            mistakeCountTextControl.WrongLetterEvent += OnWrongLetter;
            mistakeCountTextControl.QueueIsEmptyEvent += OnQueueIsEmpty;

            symbols = new char[mistakeCount.Text.Length];
            for (int i = 0; i < symbols.Length; ++i)
            {
                symbols[i] = mistakeCount.Text[i];
            }
        }

        private bool isKeyPressed = false;

        public void Control_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверяем, было ли уже обработано событие - чтобы исключить учёт удержания клавиши
            if (isKeyPressed)
                return;
            isKeyPressed = true;

            Keys keyCode = e.KeyCode;

            if (CurrentControlMode == ControlMode.ControlStarted && keyCode == Keys.Enter)
            {
                mistakeCountTextControl.AddLettersOnControl(symbols); // добавляем символы в поток
                CurrentControlMode = ControlMode.TypingStarted; // стартуем
                lbTaskText.Text = "Поехали!";
                mistakeCountTextControl.Start();
            }
            else if (CurrentControlMode == ControlMode.TypingStarted && keyCode == Keys.Escape)
            {
                Result = MistakeCountControlResult.PAUSE;
            }
            else if (CurrentControlMode == ControlMode.TypingStopped && keyCode == Keys.Escape)
            {
                Result = MistakeCountControlResult.RESUME;
            }
            // Если поток идёт - проверяем нажатую кнопку на соответствие символу в кольце
            else if (CurrentControlMode == ControlMode.TypingStarted)
            {
                char middleChar = mistakeCountTextControl.GetLetterInTheMiddleOfControl();
                char pressedSymbol = '\0';
                switch (lang)
                {
                    case Language.ENGLISH:
                        pressedSymbol = KeyboardHelper.GetUpperEngCharForKey(keyCode); break;
                    case Language.RUSSIAN:
                        pressedSymbol = KeyboardHelper.GetUpperRusCharForKey(keyCode); break;
                }
                if (pressedSymbol == '\0' || pressedSymbol != middleChar)
                {
                    statistic.errors++;
                    lbTaskText.Text = "Неправильная клавиша!";
                }
                else if (pressedSymbol == middleChar)
                {
                    mistakeCountTextControl.DropFirstLetter();
                    statistic.correct++;
                    mistakeCountTextControl.UpdatingStateTimer.Start();
                    lbTaskText.Text = "Верно";
                }
            }
            // Завершение работы элемента управления
            else if (CurrentControlMode == ControlMode.TypingFinished && keyCode == Keys.Enter)
            {
                Result = MistakeCountControlResult.EXIT;
            }
        }

        public void Control_KeyUp(object sender, KeyEventArgs e)
        {
            isKeyPressed = false;
        }

        private void OnQueueIsEmpty()
        {
            lbTaskText.Invoke(new Action(() => lbTaskText.Text = $"Поток завершён!\nВерных нажатий:{statistic.correct}" +
                    $"\nНеверных нажатий: {statistic.errors}\nНажмите Enter чтобы пойти дальше"));
            CurrentControlMode = ControlMode.TypingFinished;
        }

        private void OnWrongLetter()
        {
            statistic.errors++;
            // Запускаем изменение текста лейбла в том же потоке, в котором работает элемент управления
            lbTaskText.Invoke(new Action(() => lbTaskText.Text = "Неправильно набран номер!"));
        }
    }
}
