using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gameplay;
using Gameplay.ExerciseMachine;
using System.Timers;

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

        /// <summary>
        /// Метод получения русской буквы в верхнем регистре по коду клавиши.
        /// Если клавише не соответствует русская буква, вернётся '\0'
        /// </summary>
        /// <param name="keyCode">Код клавиши</param>
        /// <returns></returns>
        private char GetUpperRusCharForKey(Keys keyCode) {
            switch (keyCode) {
                case Keys.Q: return 'Й';
                case Keys.W: return 'Ц';
                case Keys.E: return 'У';
                case Keys.R: return 'К';
                case Keys.T: return 'Е';
                case Keys.Y: return 'Н';
                case Keys.U: return 'Г';
                case Keys.I: return 'Ш';
                case Keys.O: return 'Щ';
                case Keys.P: return 'З';
                case Keys.Oem4: return 'Х'; // Клавиша {
                case Keys.Oem6: return 'Ъ'; // Клавиша }
                case Keys.A: return 'Ф';
                case Keys.S: return 'Ы';
                case Keys.D: return 'В';
                case Keys.F: return 'А';
                case Keys.G: return 'П';
                case Keys.H: return 'Р';
                case Keys.J: return 'О';
                case Keys.K: return 'Л';
                case Keys.L: return 'Д';
                case Keys.Oem1: return 'Ж'; // Клавиша ;
                case Keys.Oem7: return 'Э'; // Клавиша '
                case Keys.Z: return 'Я';
                case Keys.X: return 'Ч';
                case Keys.C: return 'С';
                case Keys.V: return 'М';
                case Keys.B: return 'И';
                case Keys.N: return 'Т';
                case Keys.M: return 'Ь';
                case Keys.Oemcomma: return 'Б'; // Клавиша <
                case Keys.OemPeriod: return 'Ю'; // Клавиша >
                default: return '\0';
            }
        }

        /// <summary>
        /// Метод получения английской буквы в верхнем регистре по коду клавиши.
        /// Если клавише не соответствует английская буква, вернётся '\0'
        /// </summary>
        /// <param name="keyCode">Код клавиши</param>
        /// <returns></returns>
        private char GetUpperEngCharForKey(Keys keyCode) {
            switch (keyCode) {
                case Keys.Q: return 'Q';
                case Keys.W: return 'W';
                case Keys.E: return 'E';
                case Keys.R: return 'R';
                case Keys.T: return 'T';
                case Keys.Y: return 'Y';
                case Keys.U: return 'U';
                case Keys.I: return 'I';
                case Keys.O: return 'O';
                case Keys.P: return 'P';
                case Keys.A: return 'A';
                case Keys.S: return 'S';
                case Keys.D: return 'D';
                case Keys.F: return 'F';
                case Keys.G: return 'G';
                case Keys.H: return 'H';
                case Keys.J: return 'J';
                case Keys.K: return 'K';
                case Keys.L: return 'L';
                case Keys.Z: return 'Z';
                case Keys.X: return 'X';
                case Keys.C: return 'C';
                case Keys.V: return 'V';
                case Keys.B: return 'B';
                case Keys.N: return 'N';
                case Keys.M: return 'M';
                default: return '\0';
            }
        }

        /// <summary>
        /// Метод генерации следующей буквы (в верхнем регистре) заданного алфавита в заданном количестве для добавления в поток
        /// </summary>
        /// <param name="alphabet">Алфавит - массив допустимых символов для добавления в очередь</param>
        /// <returns></returns>
        private char GenerateRandomSymbol()
        {
            return char.ToUpper(symbolStream.getRandomSymbol());
        }

        /// <summary>
        /// Метод добавления очередной буквы в очередь. Соответствует делегату TimerCallback
        /// </summary>
        /// <param name="nullParam"></param>
        private void AddSymbolToQueue(object sender, ElapsedEventArgs e) {
            symbolQueueControl.AddLetterToStream(GenerateRandomSymbol());
            // Уменьшаем количество оставшихся для добавления символов и возвращаем сгенерированный символ
            p_remainingSymbolsCount--;
            // Если больше букв не будет
            if (p_remainingSymbolsCount == 0) {
                // Отключаем таймер на добавление букв
                AddingSymbolTimer.Dispose();
                // Сообщаем symbolQueueControl, что больше буквы добавляться не будут
                symbolQueueControl.AddingLettersIsOver = true;
            }
        }

        /// <summary>
        /// Таймер добавления нового символа в поток
        /// </summary>
        private System.Timers.Timer AddingSymbolTimer { get; set; }

        private SymbolStream symbolStream;
        uint p_remainingSymbolsCount;
        private SymbolStreamStatistic curStatistic;
        private Language lang;

        private static readonly string welcome_text = @"Добро пожаловать в тренажёр ""Поток букв""! На полосе сверху будет появляться поток букв. " +
                "Ваша задача - нажимать на клавишу, буква которой находится в кольце. Успевайте вовремя, и вы победите! " +
                "Нажмите клавишу 'Enter', чтобы начать.";

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
            p_remainingSymbolsCount = symbolStream.SymbolsCount;
            OnControlResultChanged += result_handler;
            // Подписываемся на события SymbolQueueControl
            symbolQueueControl.LetterMissedEvt += OnLetterMissed;
            symbolQueueControl.QueueEndEvt += OnQueueEnd;
        }

        /// <summary>
        /// Обработчик события нажатия клавиши
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        public void Control_KeyDown(object sender, KeyEventArgs e) {
            // ! Подписан на событие самого контрола
            Keys keyCode = e.KeyCode;
            // Начинаем состязание, если после запуска нажат Enter
            if (CurControlMode == ControlMode.ControlStarted && keyCode == Keys.Enter) {
                lTaskText.Text = "Поток букв запущен!";
                CurControlMode = ControlMode.StreamStarted;
                symbolQueueControl.StartLettersStream(symbolStream.SymbolSpeed);
                // Устанавливаем таймер на добавление новых букв в очередь
                AddingSymbolTimer = new System.Timers.Timer(symbolStream.TimeForSymbolCreation);
                AddingSymbolTimer.Elapsed += AddSymbolToQueue;
                AddingSymbolTimer.Start();
            }
            // Если поток идёт - проверяем нажатую кнопку на соответствие символу в кольце
            if (CurControlMode == ControlMode.StreamStarted) {
                char roundedSymbol = symbolQueueControl.GetRoundedChar();
                char pressedSymbol;
                switch (lang)
                {
                    case Language.ENGLISH:
                        pressedSymbol = GetUpperEngCharForKey(keyCode); break;
                    case Language.RUSSIAN:
                        pressedSymbol = GetUpperRusCharForKey(keyCode); break;
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
            if (keyCode == Keys.Escape && CurControlMode == ControlMode.StreamStoped)
                Result = SymbolStreamControlResult.RESUME;
            else if (keyCode == Keys.Escape)
                Result = SymbolStreamControlResult.PAUSE;
            if (CurControlMode == ControlMode.StreamFinished && keyCode == Keys.Enter)
            {
                Result = SymbolStreamControlResult.EXIT;
            }
        }

        public void Pause()
        {
            AddingSymbolTimer.Stop();
            symbolQueueControl.Pause();
            CurControlMode = ControlMode.StreamStoped;
        }

        public void Resume()
        {
            AddingSymbolTimer.Start();
            symbolQueueControl.Resume();
            CurControlMode = ControlMode.StreamStarted;
        }

        /// <summary>
        /// Обработчик события пропуска буквы в потоке
        /// (т.е. пользователь вовремя не нажал нужную клавишу)
        /// </summary>
        private void OnLetterMissed() {
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
