using System;
using System.Windows.Forms;
using Gameplay;
using Gameplay.ExerciseMachine;

namespace KeyboardSmasher.GUI.ExerciseMachine
{
    public enum SymbolStreamControlResult
    {
        NO_RESULT,
        PAUSE,
        RESUME,
        EXIT
    }

    public partial class SymbolStreamControl : UserControl {

        public delegate void SymbolStreamControlResultProc(SymbolStreamControlResult new_result);
        event SymbolStreamControlResultProc OnControlResultChanged;
        private SymbolStreamControlResult result;
        private SymbolStreamControlResult Result
        {
            get { return result; }
            set
            {
                result = value;
                OnControlResultChanged(result);
            }
        }




        /// <summary>
        /// Перечислитель, содержащий режимы работы элемента управления
        /// </summary>
        private enum ControlMode {
            /// <summary>
            /// Элемент управления был создан, но поток ещё не был запущен
            /// </summary>
            ControlStarted,
            /// <summary>
            /// Элемент управления был создан и поток был запущен
            /// </summary>
            StreamStarted,
            /// <summary>
            /// Элемент управления был создан, поток был запущен и уже завершён
            /// </summary>
            StreamFinished,
            StreamStoped
        }

        /// <summary>
        /// Текущий режим работы элемента управления
        /// </summary>
        private ControlMode CurControlMode { get; set; }

        private SymbolStream symbolStream;
        private SymbolStreamStatistic curStatistic;
        private Language lang;

        private static readonly string welcome_text = @"Добро пожаловать в тренажёр ""Поток букв""! На полосе сверху будет появляться поток букв. " +
                "Ваша задача - нажимать на клавишу, буква которой находится в кольце. Успевайте вовремя, и вы победите! " +
                "Нажмите клавишу 'Enter', чтобы начать.";

        char[] symbols; // символы, которые будут добавлены в очередь
        int lettersInterval; // интервальный коэффициент между буквами
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="lang">Язык</param>
        /// <param name="difficulty">Сложность</param>
        /// <param name="result_handler">Указатель на переменную результата</param>
        public SymbolStreamControl(Language lang, Difficulty difficulty, SymbolStreamControlResultProc result_handler) {
            InitializeComponent();
            this.lang = lang;
            // Текст приветствия
            lTaskText.Text = welcome_text;
            // Текущий режим работы элемента управления - "запущен"
            CurControlMode = ControlMode.ControlStarted;
            // Создаём статистику
            curStatistic = new SymbolStreamStatistic();
            symbolStream = new SymbolStream(lang, difficulty);
            OnControlResultChanged += result_handler;
            // Подписываемся на события SymbolQueueControl
            symbolQueueControl.LetterMissedEvt += OnLetterMissed;
            symbolQueueControl.QueueEndEvt += OnQueueEnd;

            // Заполняем Queue нужными символами с нужным интервалом
            int symbolCount = (int)symbolStream.SymbolsCount;
            lettersInterval = symbolStream.LettersInterval;
            symbols = new char[symbolCount];
            for (int i = 0; i < symbolCount; i++) {
                symbols[i] = symbolStream.getRandomSymbol();
            }
            
        }

        /// <summary>
        /// Флаг, поднимающийся при нажатии клавиши и опускающийся при её отпускании.
        /// Для того, чтобы исключить учёт удержания клавиши
        /// </summary>
        private bool f_keyDown = false;

        /// <summary>
        /// Обработчик события нажатия клавиши
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        public void Control_KeyDown(object sender, KeyEventArgs e) {
            // ! Подписан на событие самого контрола

            // Проверяем, было ли уже обработано событие - чтобы исключить учёт удержания клавиши
            if (f_keyDown)
                return;
            f_keyDown = true;

            Keys keyCode = e.KeyCode;
            // Начинаем состязание, если после отображения тренажёра нажат Enter
            if (CurControlMode == ControlMode.ControlStarted && keyCode == Keys.Enter) {
                symbolQueueControl.AddLettersToStream(symbols, lettersInterval); // добавляем символы в поток
                CurControlMode = ControlMode.StreamStarted; // стартуем поток
                lTaskText.Text = "Поток букв запущен!";
                symbolQueueControl.StartLettersStream(symbolStream.SymbolSpeed);
            }
            // Проверяем, не была ли нажата пауза
            else if (CurControlMode == ControlMode.StreamStarted && keyCode == Keys.Escape) {
                Result = SymbolStreamControlResult.PAUSE;
            }
            // Проверяем, не запрошено ли снятие паузы
            else if (CurControlMode == ControlMode.StreamStoped && keyCode == Keys.Escape) {
                Result = SymbolStreamControlResult.RESUME;
            }
            // Если поток идёт - проверяем нажатую кнопку на соответствие символу в кольце
            else if (CurControlMode == ControlMode.StreamStarted) {
                char roundedSymbol = symbolQueueControl.GetRoundedChar();
                char pressedSymbol;
                switch (lang)
                {
                    case Language.ENGLISH:
                        pressedSymbol = KeyboardHelper.GetUpperEngCharForKey(keyCode); break;
                    case Language.RUSSIAN:
                        pressedSymbol = KeyboardHelper.GetUpperRusCharForKey(keyCode); break;
                    default: pressedSymbol = '\0'; break;
                }
                if (roundedSymbol == '\0') {
                    curStatistic.missedCount++;
                    lTaskText.Text = "Мимо!";
                }
                else if (pressedSymbol == '\0' || pressedSymbol != roundedSymbol) {
                    curStatistic.missedCount++;
                    lTaskText.Text = "Неправильная клавиша!";
                }
                else if (pressedSymbol == roundedSymbol) {
                    symbolQueueControl.DropFirstLetterFormStream();
                    curStatistic.correctCount++;
                    lTaskText.Text = "Отлично!";
                }
            }
            // Завершение работы элемента управления
            else if (CurControlMode == ControlMode.StreamFinished && keyCode == Keys.Enter) {
                Result = SymbolStreamControlResult.EXIT;
            }
        }

        /// <summary>
        /// Обработчик события отпускания клавиши
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        public void Control_KeyUp(object sender, KeyEventArgs e) {
            f_keyDown = false;
        }

        /// <summary>
        /// Метод установки игровой паузы
        /// </summary>
        public void Pause()
        {
            symbolQueueControl.Pause();
            CurControlMode = ControlMode.StreamStoped;
        }

        /// <summary>
        /// Метод возврата из игровой паузы
        /// </summary>
        public void Resume()
        {
            symbolQueueControl.Resume();
            CurControlMode = ControlMode.StreamStarted;
        }

        /// <summary>
        /// Обработчик события пропуска буквы в потоке
        /// (т.е. пользователь вовремя не нажал нужную клавишу)
        /// </summary>
        private void OnLetterMissed() {
            curStatistic.missedCount++;
            // Запускаем изменение текста лейбла в том же потоке, в котором работает элемент управления
            lTaskText.Invoke(new Action(() => lTaskText.Text = "Буква была пропущена!"));
        }

        /// <summary>
        /// Обработчик события завершения потока букв
        /// </summary>
        private void OnQueueEnd() {
            // Запускаем изменение текста лейбла в том же потоке, в котором работает элемент управления
            lTaskText.Invoke(new Action(() => lTaskText.Text = $"Поток завершён!\nВерных нажатий:{curStatistic.correctCount}\nОшибок: {curStatistic.missedCount}\nНажмите Enter чтобы пойти дальше"));
            CurControlMode = ControlMode.StreamFinished;
        }
    }
}
