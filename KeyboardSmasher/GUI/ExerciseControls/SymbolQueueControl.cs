using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Linq;

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
            public Letter(char letter, PointF position, Color color) {
                this.letter = letter;
                this.position = position;
                this.color = color;
            }
        }

        /// <summary>
        /// Двусвязный список отображаемых букв
        /// </summary>
        private Queue<Letter> LettersStream { get; set; }

        /// <summary>
        /// Блокирующийся объект для синхронизации доступа потоков к обновлению состояния элемента управления
        /// </summary>
        private readonly object UpdatingStateLock = new object();

        /// <summary>
        /// Таймер обновления состояния элемента управления при отображении потока букв
        /// </summary>
        private System.Windows.Forms.Timer UpdatingStateTimer { get; set; }

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
        private readonly Dictionary<Color, SolidBrush> brushes = new Dictionary<Color, SolidBrush>();

        /// <summary>
        /// Свдинуть отображаемые буквы влево
        /// </summary>
        /// <param name="pushValue">Величина сдвига (в пикселях). По умолчанию величина равна единице</param>
        private void PushQueueForward(int pushValue = 2) {
            // Если отображаемых букв нет - двигать нечего, выходим
            if (!LetterStreamIsEmpty)
            {
                // Обходим очередь и уменьшаем координату X каждой вершины на величину сдвига
                foreach (var letter in LettersStream)
                    letter.position.X -= pushValue;
                // Если первая буква ушла за линию - она исчезает
                if (LettersStream.Peek().position.X <= 0)
                {
                    LettersStream.Dequeue();
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
            using (Graphics g = Graphics.FromImage(Image))
            {
                // Задаём сглаживание при рисовании
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                // Заливаем холст белым
                g.Clear(Color.White);
                // Рисуем окружность выбора буквы в левом конце полосы контрола
                g.DrawEllipse(g_Pen, g_circleRectLeftUpPoint.X, g_circleRectLeftUpPoint.Y, g_circleDiametr, g_circleDiametr);
                // Рисуем буквы в соответствии с их информацией
                foreach (var letter in LettersStream) {
                    if (letter.position.X >= Width)
                        break;
                    g.DrawString(letter.letter.ToString(), g_font, brushes[letter.color], letter.position.X, letter.position.Y - g_fontSize / 2);
                }
            }
            Invalidate();
        }

        /// <summary>
        /// Обновить состояние элемента управления: добавить очередную букву из очереди ожидающих букв,
        /// сдвинуть уже отображаемые буквы влево, отрисовать новое состояние
        /// </summary>
        /// <param name="nullParam">Неиспользуемый параметр для соответствия делегату TimerCallback</param>
        private void UpdateState(object sender, EventArgs e) {
            LetterStreamIsEmpty = LettersStream.Count == 0;
            // Если менять нечего
            if (LetterStreamIsEmpty)
            {
                // Отрисовываем новое состояние - букв в потоке нет
                DrawNewState();
                // Поднимаем событие окончания потока, и выключаем таймер обновления состояния
                QueueEndEvt();
                UpdatingStateTimer.Stop();
                UpdatingStateTimer.Dispose();
            }
            else
            {
                // Сдвигаем отображаемые буквы влево
                PushQueueForward();
                // Отрисовываем новое состояние
                DrawNewState();
            }
        }



        /// <summary>
        /// Конструктор
        /// </summary>
        public SymbolQueueControl() {
            InitializeComponent();
            // Инициализируем изображение, отображаемое контролом
            Image = new Bitmap(Size.Width, Size.Height);
            // Инициализируем пустой список отображаемых букв
            LettersStream = new Queue<Letter>();
            // Задаём константные параметры рисования
            CalcDrawingParams();
            //заполняем словарь кистей кистями цветов раскраски букв
            foreach(var c in KeyboardHelper.Colors)
                brushes.Add(c, new SolidBrush(c));
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
            UpdatingStateTimer = new System.Windows.Forms.Timer();
            UpdatingStateTimer.Interval = (int)SymbolSpeed;
            UpdatingStateTimer.Tick += UpdateState;
            UpdatingStateTimer.Start();
        }


        /// <summary>
        /// Добавление буквы в поток букв
        /// </summary>
        /// <param name="letter">Символ добавляемой буквы</param>
        public void AddLettersToStream(char[] letters, int intervalNumb) {
            int circleRadius = Height / 2;
            int interval = Height / 2;
            if (intervalNumb == 1)
                interval = 4 * circleRadius;
            else if (intervalNumb == 2)
                interval = 3 * circleRadius;
            else if (intervalNumb == 3)
                interval = 2 * circleRadius;
            int curLetterX = Width;
            foreach (var c in letters) {
                char letter = char.ToUpper(c);
                // Добавляемая буква появляется на правой границе элемента управления
                float xPos = curLetterX;
                float yPos = (circleRadius - 5) - rand.Next(circleRadius - 15);
                Color color = KeyboardHelper.GetKeyColorForChar(letter);
                // Формируем новую букву и добавляем её
                Letter addingLetter = new Letter(letter, new PointF(xPos, yPos), color);
                LettersStream.Enqueue(addingLetter);
                curLetterX += interval;
            }
        }

        /// <summary>
        /// Метод для удаления первой буквы в очереди из неё
        /// (в случае, если нужная клавиша была верно нажата)
        /// </summary>
        public void DropFirstLetterFormStream() {
            // Блокируем доступ другим потокам - для того, чтобы не было параллельной работы с LettersStream
            lock (UpdatingStateLock) {
                LettersStream.Dequeue();
            }
        }

        /// <summary>
        /// Получить символ, в данный момент находящийся в окружности выбора букв
        /// </summary>
        /// <returns>Символ, находящийся в окружности выбора букв. Если такой отсутствует, возвращается символ '\0'</returns>
        public char GetRoundedChar() {
            if (LettersStream.Count == 0)
                return '\0';
            Letter firstLetter = LettersStream.Peek();
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
            Image = new Bitmap(Size.Width, Size.Height);
            Invalidate();
            // Перевычисляем параметры рисования
            CalcDrawingParams();
            // Отрисовываем новое состояние элемента управления
            DrawNewState();
        }
    }
}
