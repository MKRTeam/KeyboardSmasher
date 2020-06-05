using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KeyboardSmasher.GUI.ExerciseControls
{
    public partial class MistakeCountTextControl : PictureBox
    {
        private class Letter
        {
            public readonly char letter;    // символ
            public PointF position;         // левый верхний угол
            public Color color;             // цвет

            public Letter(char letter, PointF position, Color color)  // структура для букв: сам символ, позиция, цвет
            {
                this.letter = letter;
                this.position = position;
                this.color = color;
            }
        }

        private Queue<Letter> TextToTypeQueue { get; set; } // очередь букв для печати
        public Timer UpdatingStateTimer { get; private set; } // таймер обновления экрана

        private readonly object UpdatingStateLock = new object();

        public delegate void EventHandler();
        public event EventHandler WrongLetterEvent; // на неверное нажатие
        public event EventHandler QueueIsEmptyEvent; // на окончание тренажера

        private int g_fontSize;     // размер шрифта, с учётом ширины полосы (равен половине высоты контрола)
        private Font g_font;        // шрифт

        private readonly Dictionary<Color, SolidBrush> brushes = new Dictionary<Color, SolidBrush>();   // набор кистей для букв. группировка по цвету
        

        public MistakeCountTextControl()
        {
            InitializeComponent();
            Image = new Bitmap(Size.Width, Size.Height);
            TextToTypeQueue = new Queue<Letter>();
            CalcDrawingParams();
            foreach (var clr in KeyboardHelper.Colors)
                brushes.Add(clr, new SolidBrush(clr));
            DrawNewState();
            Invalidate();
        }

        /// <summary>
        /// Метод вычисления констант рисования на основе размеров элемента управления 
        /// и ширины линии окружности выбора букв
        /// </summary>
        private void CalcDrawingParams()
        {
            g_fontSize = Height / 2;
            g_font = new Font(FontFamily.GenericSansSerif, g_fontSize);
        }

        /// <summary>
        /// Метод для очистки экрана от букв в конце тренажера
        /// </summary>
        public void Clear()
        {
            using (Graphics g = Graphics.FromImage(Image))
            {
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 13, Width, 14 + g_fontSize));
            }
            Invalidate();
        }

        /// <summary>
        /// Свдинуть отображаемые буквы влево
        /// </summary>
        private void PushQueueForward()
        {
            int pushValue = g_fontSize;

            if (TextToTypeQueue.Count != 0)
            {
                foreach (var bukva in TextToTypeQueue)
                    bukva.position.X -= pushValue;
            }
        }

        /// <summary>
        /// Отрисовать новое состояние элемента управления
        /// </summary>
        private void DrawNewState()
        {
            using (Graphics g = Graphics.FromImage(Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 13, Width, 14 + g_fontSize));
                foreach (var letter in TextToTypeQueue)
                {
                    if (letter.position.X >= Width)
                        break;
                    g.DrawString(letter.letter.ToString(), g_font, brushes[letter.color], letter.position.X, letter.position.Y - g_fontSize / 2);
                }
            }
            Invalidate();
        }

        /// <summary>
        /// Обновить состояние элемента управления: добавить очередную букву из очереди ожидающих букв,
        /// сдвинуть уже отображаемые буквы влево, отрисовать новое состояние. Подцепляется на исполнение
        /// по таймеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateState(object sender, EventArgs e)
        {
            if (TextToTypeQueue.Count == 0)
            {
                DrawNewState();
                QueueIsEmptyEvent();
                UpdatingStateTimer.Stop();
                UpdatingStateTimer.Dispose();
            }
            else if ((int)(TextToTypeQueue.Peek().position.X + g_fontSize * 4) <= Width / 2)
            {
                UpdatingStateTimer.Stop();
            }
            else 
            {
                PushQueueForward();
                DrawNewState();
            }
        }

        /// <summary>
        /// Метод запуска
        /// </summary>
        public void Start()
        {
            if (UpdatingStateTimer != null)
                return;
            UpdatingStateTimer = new Timer
            {
                Interval = 10
            };
            UpdatingStateTimer.Tick += UpdateState;
            UpdatingStateTimer.Start();
        }

        /// <summary>
        /// Добавление букв в очередь
        /// </summary>
        /// <param name="characters">Символы добавляемых букв</param>
        public void AddLettersOnControl(char[] characters)
        {
            int curLetterX = Width;
            foreach (var character in characters)
            {
                char letter = char.ToUpper(character);
                float xPos = curLetterX;
                float yPos = this.Height / 2 - 30;
                Color color = KeyboardHelper.GetKeyColorForChar(letter);
                Letter newLetter = new Letter(letter, new PointF(xPos, yPos), color);
                TextToTypeQueue.Enqueue(newLetter);
                curLetterX += 30;
            }
        }


        /// <summary>
        /// Получить символ, который нужно ввести
        /// </summary>
        /// <returns>Первый символ из очереди</returns>
        public char GetLetterInTheMiddleOfControl()
        {
            return TextToTypeQueue.Peek().letter;
        }

        /// <summary>
        /// Метод для удаления первой буквы в очереди
        /// (в случае, если нужная клавиша была верно нажата)
        /// </summary>
        public void DropFirstLetter()
        {
            lock (UpdatingStateLock)
            {
                TextToTypeQueue.Dequeue();
            }
        }
    }
}
