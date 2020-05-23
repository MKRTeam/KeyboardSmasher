using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace KeyboardSmasher.GUI.ExerciseMachine
{
    public partial class SymbolQueueControl : PictureBox {
        /// <summary>
        /// Класс буквы для хранения информации об отображаемых буквах
        /// </summary>
        private class Letter {
            public readonly char letter; // символ буквы
            public PointF position; // позиция рисования буквы - т.е. координаты левого верхнего угла
            public Color color; // цвет

            // Конструктор
            public Letter(char letter, PointF position) {
                this.letter = letter;
                this.position = position;
                // Рандомизируем цвет буквы
                Random random = new Random();
                color = Color.FromArgb(random.Next(230), random.Next(230), random.Next(230));
            }
        }

        /// <summary>
        /// Очередь ожидающих отображения букв
        /// </summary>
        private Queue<char> AddingLettersQueue { get; set; }

        /// <summary>
        /// Двусвязный список отображаемых букв
        /// </summary>
        private LinkedList<Letter> LettersStream { get; set; }

        /// <summary>
        /// Блокирующийся объект для синхронизации доступа потоков к обновлению состояния элемента управления
        /// </summary>
        private readonly object UpdatingStateLock = new object();

        /// <summary>
        /// Таймер обновления состояния элемента управления при отображении потока букв
        /// </summary>
        private System.Timers.Timer UpdatingStateTimer { get; set; }

        /// <summary>
        /// Делегат обработчика событий очереди: "Буква была проущена" и "Очередь опустела"
        /// </summary>
        public delegate void OnQueueEventsHandler();
        /// <summary>
        /// Событие "Буква была пропущена" - активируется при исчезновении буквы из очереди
        /// </summary>
        public event OnQueueEventsHandler LetterMissedEvt;
        /// <summary>
        /// Событие "Очередь опустела" - активируется при исчезновении последней буквы из очереди
        /// </summary>
        public event OnQueueEventsHandler QueueEndEvt;


        /// <summary>
        /// Признак окончания добавления букв. Если данный признак - истина,
        /// то после исчезновения всех букв из потока работа элемента управления кончается
        /// </summary>
        public bool AddingLettersIsOver { get; set; }


        // -----------------Параметры рисования------------------
        private Color g_circleColor = Color.Orange; // цвет кольца
        private Point g_circleRectLeftUpPoint; // верхний левый угол описанного вокруг окружности четырёхугольника - с учётом ширины кисти
        private int g_circleDiametr; // диаметр окружности выбора букв (равен высоте полосы контрола минус ширина кисти)
        private int g_fontSize; // размер шрифта, с учётом ширины полосы (равен половине высоты контрола
        private Font g_font; // шрифт
        private Pen g_Pen;//ручка которой рисуем эллипс

        /// <summary>
        /// Метод вычисления констант рисования на основе размеров элемента управления 
        /// и ширины линии окружности выбора букв
        /// </summary>
        private void CalcDrawingParams() {
            int g_penWidth = Height / 10;
            g_circleRectLeftUpPoint = new Point(0 + g_penWidth / 2, 0 + g_penWidth / 2);
            g_circleDiametr = Height - g_penWidth;
            g_fontSize = Height / 2;
            g_font = new Font(FontFamily.GenericSansSerif, g_fontSize);
            g_Pen = new Pen(g_circleColor, g_penWidth);
        }
        // -----------------Параметры рисования------------------


        private static Random rand = new Random();
        private bool LetterStreamIsEmpty;
        private bool AddingLetterQueueIsEmpty;
        /// <summary>
        /// Добавить первую букву из очереди ожидающих отображения букв в список отображаемых букв,
        /// если соблюдается необходимый интервал после последней отображаемой буквой
        /// </summary>
        private void AddLetterFromBuffer() {
            int radius = Height / 2;
            // Если расстояние между последней отображаемой буквой (если есть) и правой границей элемента управления
            // (точкой добавления новой буквы) не меньше пороговой величины (диаметра окружности выбора букв) - добавляем букву
            if (!AddingLetterQueueIsEmpty && (LetterStreamIsEmpty || 
                Width - LettersStream.Last.Value.position.X >= radius)) {
                // Добавляемая буква появляется на правой границе элемента управления
                float xPos = Width;
                float yPos = (radius - 5) - rand.Next(radius - 15);
                // Формируем новую букву и добавляем её
                Letter addingLetter = new Letter(AddingLettersQueue.Dequeue(), new PointF(xPos, yPos));
                LettersStream.AddLast(addingLetter);
            }
        }

        /// <summary>
        /// Свдинуть отображаемые буквы влево
        /// </summary>
        /// <param name="pushValue">Величина сдвига (в пикселях). По умолчанию величина равна единице</param>
        private void PushQueueForward(int pushValue = 1) {
            // Если отображаемых букв нет - двигать нечего, выходим
            if (!LetterStreamIsEmpty)
            {
                // Обходим двусвязный список и уменьшаем координату X каждой вершины на величину сдвига
                foreach (var listNode in LettersStream)
                    listNode.position.X -= pushValue;
                // Если первая буква ушла за линию - она исчезает
                if (LettersStream.First.Value.position.X <= 0)
                {
                    LettersStream.RemoveFirst();
                    // Оповещаем о том, что одна буква ушла из очереди, т.к. была пропущена
                    LetterMissedEvt?.Invoke();
                }
            }
        }

        /// <summary>
        /// Отрисовать новое состояние элемента управления
        /// </summary>
        private void DrawNewState() {
            // Рисуем новое состояние элемента управления
            Bitmap newImage = new Bitmap(Size.Width, Size.Height);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // Задаём сглаживание при рисовании
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                // Заливаем холст белым
                g.Clear(Color.White);
                // Рисуем окружность выбора буквы в левом конце полосы контрола
                g.DrawEllipse(g_Pen, g_circleRectLeftUpPoint.X, g_circleRectLeftUpPoint.Y, g_circleDiametr, g_circleDiametr);
                // Рисуем буквы в соответствии с их информацией
                foreach (var letter in LettersStream)
                    g.DrawString(letter.letter.ToString(), g_font, new SolidBrush(letter.color), letter.position.X, letter.position.Y - g_fontSize / 2);
            }

            Image = newImage;
            Invalidate();
            //Refresh();
        }

        /// <summary>
        /// Обновить состояние элемента управления: добавить очередную букву из очереди ожидающих букв,
        /// сдвинуть уже отображаемые буквы влево, отрисовать новое состояние
        /// </summary>
        /// <param name="nullParam">Неиспользуемый параметр для соответствия делегату TimerCallback</param>
        private void UpdateState(object sender, ElapsedEventArgs e) {
            LetterStreamIsEmpty = LettersStream.Count == 0;
            AddingLetterQueueIsEmpty = AddingLettersQueue.Count == 0;
            // Если менять нечего
            if (LetterStreamIsEmpty && AddingLetterQueueIsEmpty) {
                // Если букв в потоке и в буфере нет, и добавление букв в очередь закончено - конец
                if (AddingLettersIsOver == true) {
                    // Отрисовываем новое состояние - букв в потоке нет
                    DrawNewState();
                    // Поднимаем событие окончания потока, и выключаем таймер обновления состояния
                    QueueEndEvt();
                    UpdatingStateTimer.Stop();
                    UpdatingStateTimer.Dispose();
                }
            }
            else
            {
                // Блокируем обновление состояния элемента управления, чтобы не было попытки
                // обновить состояние при обновлении состояния (критическая секция)
                lock (UpdatingStateLock)
                {
                    // Добавляем букву из очереди добавляемых букв
                    AddLetterFromBuffer();
                    // Сдвигаем отображаемые буквы влево
                    PushQueueForward();
                    // Отрисовываем новое состояние
                    DrawNewState();
                }
            }
        }



        /// <summary>
        /// Конструктор
        /// </summary>
        public SymbolQueueControl() {
            InitializeComponent();
            // Инициализируем изображение, отображаемое контролом
            Image = new Bitmap(Size.Width, Size.Height);
            // Инициализируем пустую очередь добавляемых букв
            AddingLettersQueue = new Queue<char>();
            // Инициализируем пустой список отображаемых букв
            LettersStream = new LinkedList<Letter>();
            // Задаём константные параметры рисования
            CalcDrawingParams();
            // Устанавливаем признак окончания очереди в ложь
            AddingLettersIsOver = false;
            // Отрисовываем окружность выбора, чтобы она была видна при добавлении элемента управления на форму
            DrawNewState();
            Invalidate();
        }



        /// <summary>
        /// Запуск потока букв
        /// </summary>
        /// <param name="speedCoefficient">Коэффициент ускорения (мс). Ускорение при значении от нуля до единицы (не включая).
        /// Замедление при значении больше единицы. Стандартное значение равняется единице</param>
        public void StartLettersStream(double SymbolSpeed) {
            if (UpdatingStateTimer != null)
                return;
            // Запускаем таймер обновления состояния
            UpdatingStateTimer = new System.Timers.Timer(1.0 / SymbolSpeed);
            UpdatingStateTimer.Elapsed += UpdateState;
            UpdatingStateTimer.Start();
        }


        /// <summary>
        /// Добавление буквы в поток букв
        /// </summary>
        /// <param name="letter">Символ добавляемой буквы</param>
        public void AddLetterToStream(char letter) {
            // Добавляем букву в очередь ожидающих добавления букв. Это сделано для того,
            // чтобы в потоке букв соблюдался межбуквенный интервал и буквы не располагались 
            // слишком близко друг к другу
            AddingLettersQueue.Enqueue(letter);
        }

        /// <summary>
        /// Метод для удаления первой буквы в очереди из неё
        /// (в случае, если нужная клавиша была верно нажата)
        /// </summary>
        public void DropFirstLetterFormStream() {
            // Блокируем доступ другим потокам - для того, чтобы не было параллельной работы с LettersStream
            lock (UpdatingStateLock) {
                LettersStream.RemoveFirst();
            }
        }

        /// <summary>
        /// Получить символ, в данный момент находящийся в окружности выбора букв
        /// </summary>
        /// <returns>Символ, находящийся в окружности выбора букв. Если такой отсутствует, возвращается символ '\0'</returns>
        public char GetRoundedChar() {
            if (LettersStream.Count == 0)
                return '\0';
            Letter firstLetter = LettersStream.First.Value;
            int letterX = (int)firstLetter.position.X + g_fontSize / 2; // получаем координату X серединки буквы 
            if (letterX < g_circleRectLeftUpPoint.X + g_circleDiametr && letterX > g_circleRectLeftUpPoint.X)
                return firstLetter.letter;
            else
                return '\0';
        }

        public void Pause()
        {
            UpdatingStateTimer.Stop();
        }

        public void Resume()
        {
            UpdatingStateTimer.Start();
        }

        /// <summary>
        /// Обработчик события "размер контрола изменён"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void SymbolQueueControl_SizeChanged(object sender, EventArgs e) {
            // Перевычисляем параметры рисования
            CalcDrawingParams();
            // Отрисовываем новое состояние элемента управления
            DrawNewState();
        }
    }
}
