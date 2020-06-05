using System;
using System.Windows.Forms;
using Gameplay;
using Gameplay.ExerciseMachine;

namespace KeyboardSmasher.ExerciseMachine.GUI
{
    public enum MistakeCountControlResult // результаты тренажера
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

        private enum ControlMode  // режимы работы тренажера
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

        private static readonly string welcome_text = @"Добро пожаловать в тренажёр ""Подсчет ошибок""! На полосе будет отображен текст. " +
                "Ваша задача - набрать его с наименьшим количеством ошибок или опечаток. Время на задание неограничено. " +
                "\nНажмите клавишу 'Enter', чтобы начать.";

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

        // обработчик нажатия клавиш. основная логика
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
            else if (CurrentControlMode == ControlMode.TypingStarted && keyCode == Keys.Escape) // на паузу
            {
                Result = MistakeCountControlResult.PAUSE;
            }
            else if (CurrentControlMode == ControlMode.TypingStopped && keyCode == Keys.Escape) // на восстановление от паузы
            {
                Result = MistakeCountControlResult.RESUME;
            }
            else if (CurrentControlMode == ControlMode.TypingStarted)   // при печатании
            {
                char middleSymbol = mistakeCountTextControl.GetLetterInTheMiddleOfControl();
                char pressedSymbol = '\0';
                switch (lang)
                {
                    case Language.ENGLISH:
                        pressedSymbol = KeyboardHelper.GetUpperEngCharForKey(keyCode); break;
                    case Language.RUSSIAN:
                        pressedSymbol = KeyboardHelper.GetUpperRusCharForKey(keyCode); break;
                }
                if (pressedSymbol == '\0' || pressedSymbol != middleSymbol)
                {
                    statistic.errors++;
                    lbTaskText.Text = "Неправильная клавиша!";
                }
                else if (pressedSymbol == middleSymbol)
                {
                    mistakeCountTextControl.DropFirstLetter();
                    statistic.correct++;
                    mistakeCountTextControl.UpdatingStateTimer.Start();
                    lbTaskText.Text = "Верно";
                }
            }
            else if (CurrentControlMode == ControlMode.TypingFinished && keyCode == Keys.Enter) // при завершении работы
            {
                Result = MistakeCountControlResult.EXIT;
            }
        }

        // обработчик при отпускании клавиш
        public void Control_KeyUp(object sender, KeyEventArgs e)
        {
            isKeyPressed = false;
        }

        /// <summary>
        /// Метод для завершения работы тренажера: вывод статистики
        /// </summary>
        private void OnQueueIsEmpty()
        {
            lbTaskText.Invoke(new Action(() => lbTaskText.Text = $"Набор текста завершён!\nВерных нажатий:{statistic.correct}" +
                    $"\nНеверных нажатий: {statistic.errors}\nНажмите Enter чтобы пойти дальше"));
            mistakeCountTextControl.Clear();
            CurrentControlMode = ControlMode.TypingFinished;
        }

        /// <summary>
        /// Метод для обработки нажатия неверной клавиши
        /// </summary>
        private void OnWrongLetter()
        {
            statistic.errors++;
            lbTaskText.Invoke(new Action(() => lbTaskText.Text = "Неверная буква!"));
        }
    }
}
