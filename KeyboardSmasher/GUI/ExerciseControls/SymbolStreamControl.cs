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

        // TODO: Настраиваемая сложность
    }
}
