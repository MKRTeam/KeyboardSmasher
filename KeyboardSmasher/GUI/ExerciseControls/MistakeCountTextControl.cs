using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            public Letter(char letter, PointF position, Color color)
            {
                this.letter = letter;
                this.position = position;
                this.color = color;
            }
        }

        private Queue<Letter> TextToTypeQueue { get; set; }
        public Timer UpdatingStateTimer { get; private set; }

        private readonly object UpdatingStateLock = new object();

        public delegate void EventHandler();
        public event EventHandler WrongLetterEvent;
        public event EventHandler QueueIsEmptyEvent;

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

        private void CalcDrawingParams()
        {
            g_fontSize = Height / 2;
            g_font = new Font(FontFamily.GenericSansSerif, g_fontSize);
        }

        private void PushQueueForward()
        {
            int pushValue = g_fontSize;

            if (TextToTypeQueue.Count != 0)
            {
                foreach (var bukva in TextToTypeQueue)
                    bukva.position.X -= pushValue;

                //if (TextToTypeQueue.Peek().position.X < 0)
                //{
                //    TextToTypeQueue.Dequeue();
                //    WrongLetterEvent?.Invoke(); // выводим, что набрана не та буква
                //}
            }
        }

        private void DrawNewState()
        {
            using (Graphics g = Graphics.FromImage(Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.Clear(Color.White);

                foreach (var letter in TextToTypeQueue)
                {
                    if (letter.position.X >= Width)
                        break;
                    g.DrawString(letter.letter.ToString(), g_font, brushes[letter.color], letter.position.X, letter.position.Y - g_fontSize / 2);
                }
            }
            Invalidate();
        }

        private void UpdateState(object sender, EventArgs e)
        {
            if (TextToTypeQueue.Count == 0)
            {
                DrawNewState();
                QueueIsEmptyEvent();
                UpdatingStateTimer.Stop();
                UpdatingStateTimer.Dispose();
            }
            else if ((int)(TextToTypeQueue.Peek().position.X + 100) <= this.Width / 2)
            {
                UpdatingStateTimer.Stop();
            }
            else 
            {
                PushQueueForward();
                DrawNewState();
            }
        }

        public void Start()
        {
            if (UpdatingStateTimer != null)
                return;
            UpdatingStateTimer = new Timer
            {
                Interval = 4
            };
            UpdatingStateTimer.Tick += UpdateState;
            UpdatingStateTimer.Start();
        }

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
                curLetterX += 50;
            }
        }

        public char GetLetterInTheMiddleOfControl()
        {
            return TextToTypeQueue.Peek().letter;
        }

        public void DropFirstLetter()
        {
            lock (UpdatingStateLock)
            {
                TextToTypeQueue.Dequeue();
            }
        }

        private void SymbolQueueControl_SizeChanged(object sender, EventArgs e)
        {
            Image = new Bitmap(Size.Width, Size.Height);
            Invalidate();
            // Перевычисляем параметры рисования
            CalcDrawingParams();
            // Отрисовываем новое состояние элемента управления
            DrawNewState();
        }
    }
}
