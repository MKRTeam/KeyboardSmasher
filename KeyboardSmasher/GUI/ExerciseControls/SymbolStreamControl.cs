using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher.ExerciseMachine.GUI
{
    /// <summary>
    /// Структура для хранения статистики задания SymbolStream
    /// </summary>
    public struct SymbolStreamStatistic {
        /// <summary>
        /// Количество промахов (пропущенная буква или буква, нажатая преждевременно)
        /// </summary>
        public int missedCount;
        /// <summary>
        /// Количество верно нажатых букв
        /// </summary>
        public int correctCount;
    }


    public partial class SymbolStreamControl : UserControl {
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
            StreamFinished
        }


        private SymbolStreamStatistic curStatistics;

        /// <summary>
        /// Текущий режим работы элемента управления
        /// </summary>
        private ControlMode CurControlMode { get; set; }

        /// <summary>
        /// Массив букв русского алфавита (в верхнем регистре)
        /// </summary>
        private readonly char[] c_rusAlphabet = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".ToCharArray();
        /// <summary>
        /// Массив букв английского алфавита (в верхнем регистре)
        /// </summary>
        private readonly char[] c_engAlphabet = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();

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
        /// Язык символов в очереди - параметр: 'ru'/'en'
        /// </summary>
        private readonly string p_symbolsLanguage;
        /// <summary>
        /// Допустимый алфавит символов
        /// </summary>
        private readonly char[] p_alphabet;
        /// <summary>
        /// Задержка перед добавлением в очередь очередного символа
        /// </summary>
        private readonly int p_symbolsReleaseDelay;
        /// <summary>
        /// Количество оставшихся для добавления в очередь символов
        /// </summary>
        private int p_remainingSymbolsCount;

        /// <summary>
        /// Метод генерации следующей буквы (в верхнем регистре) заданного алфавита в заданном количестве для добавления в поток
        /// </summary>
        /// <param name="alphabet">Алфавит - массив допустимых символов для добавления в очередь</param>
        /// <returns></returns>
        private char GenerateNextSymbol() {
            Random rand = new Random();
            return char.ToUpper(p_alphabet[rand.Next(p_alphabet.Length)]);
        }


        /// <summary>
        /// Таймер добавления нового символа в поток
        /// </summary>
        private System.Threading.Timer AddingSymbolTimer { get; set; }

        /// <summary>
        /// Метод добавления очередной буквы в очередь. Соответствует делегату TimerCallback
        /// </summary>
        /// <param name="nullParam"></param>
        private void AddSymbolToQueue(object nullParam) {
            symbolQueueControl.AddLetterToStream(GenerateNextSymbol());
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
        /// Конструктор
        /// </summary>
        /// <param name="language">Язык символов потока: 'en' - английский, 'ru' - русский</param>
        /// <param name="alphabet">Алфавит символов, которые могут составлять поток</param>
        /// <param name="symbolsCount">Количество символов в потоке</param>
        /// <param name="symbolsReleaseDelay">Задержка перед появлением нового символа</param>
        public SymbolStreamControl(string language = "en", char[] alphabet = null, int symbolsCount = 20, int symbolsReleaseDelay = 50) {
            InitializeComponent();
            // Проверка правильности аргументов
            if (language != "en" && language != "ru")
                throw new ArgumentException("Неправильно указан язык!");
            if (symbolsCount <= 0)
                throw new ArgumentException("Количество символов не может быть отрицательным или нулевым!");
            if (symbolsReleaseDelay <= 0)
                throw new ArgumentException("Задержка добавления символов не может быть отрицательной или нулевой!");
            // Текст приветствия
            lTaskText.Text =
                @"Добро пожаловать в тренажёр ""Поток букв""! На полосе сверху будет появляться поток букв. " +
                "Ваша задача - нажимать на клавишу, буква которой находится в кольце. Успевайте вовремя, и вы победите! " +
                "Нажмите клавишу 'Enter', чтобы начать.";
            // Текущий режим работы элемента управления - "запущен"
            CurControlMode = ControlMode.ControlStarted;
            // Создаём статистику
            curStatistics = new SymbolStreamStatistic();
            // Подписываемся на события SymbolQueueControl
            symbolQueueControl.LetterMissedEvt += OnLetterMissed;
            symbolQueueControl.QueueEndEvt += OnQueueEnd;
            // Задаём параметры
            if (alphabet == null && language == "en")
                alphabet = c_engAlphabet;
            else
                alphabet = c_rusAlphabet;
            p_symbolsLanguage = language;
            p_alphabet = alphabet;
            p_symbolsReleaseDelay = symbolsReleaseDelay;
            p_remainingSymbolsCount = symbolsCount;
        }

        /// <summary>
        /// Обработчик события нажатия клавиши
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        public void OnKeyDown(object sender, KeyEventArgs e) {
            // ! Подписан на событие самого контрола
            Keys keyCode = e.KeyCode;
            // Начинаем состязание, если после запуска нажат Enter
            if (CurControlMode == ControlMode.ControlStarted && keyCode == Keys.Enter) {
                lTaskText.Text = "Поток букв запущен!";
                CurControlMode = ControlMode.StreamStarted;
                symbolQueueControl.StartLettersStream();
                // Устанавливаем таймер на добавление новых букв в очередь
                AddingSymbolTimer = new System.Threading.Timer(AddSymbolToQueue, null, 0, p_symbolsReleaseDelay);
            }
            // Если поток идёт - проверяем нажатую кнопку на соответствие символу в кольце
            else if (CurControlMode == ControlMode.StreamStarted) {
                char roundedSymbol = symbolQueueControl.GetRoundedChar();
                char pressedSymbol;
                pressedSymbol = p_symbolsLanguage == "en" ? GetUpperEngCharForKey(keyCode) : GetUpperRusCharForKey(keyCode);
                if (roundedSymbol == '\0') {
                    curStatistics.missedCount++;
                    lTaskText.Text = "Мимо!";
                }
                else if (pressedSymbol == '\0' || pressedSymbol != roundedSymbol) {
                    curStatistics.missedCount++;
                    lTaskText.Text = "Неправильная клавиша!";
                }
                else if (pressedSymbol == roundedSymbol) {
                    symbolQueueControl.DropFirstLetterFormStream();
                    curStatistics.correctCount++;
                    lTaskText.Text = "Отлично!";
                }
            }
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
            lTaskText.Invoke(new Action(() => lTaskText.Text = $"Поток завершён!\nВерных нажатий:{curStatistics.correctCount}\nОшибок: {curStatistics.missedCount}"));
            CurControlMode = ControlMode.StreamFinished;
        }
    }
}
