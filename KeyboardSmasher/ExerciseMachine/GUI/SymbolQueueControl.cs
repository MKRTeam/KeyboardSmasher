using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace KeyboardSmasher.ExerciseMachine.GUI {
    public partial class SymbolQueueControl : PictureBox {
        // Структура для хранения буквы в очереди
        private struct Letter {
            public readonly char letter; // символ буквы
            public PointF position; // позиция рисования буквы

            // Конструктор
            public Letter(char letter, PointF position) {
                this.letter = letter;
                this.position = position;
            }
        }

        // Очередь отображаемых букв
        private Queue<Letter> LettersQueue { get; set; }

        // Отобразить содержимое контрола
        private void DrawContent() {
            // Рисуем кольцо в левом конце 
            int circleDiametr = Height; // диаметр кольца равен высоте полосы контрола
            Color circleColor = Color.Red; // цвет кольца
            Graphics g = Graphics.FromImage(Image);
            g.Clear(Color.White);
            g.DrawEllipse(new Pen(circleColor, 5), 0, 0, circleDiametr, circleDiametr);
        }

        // Конструктор
        public SymbolQueueControl() {
            // TODO: скорость движения букв?
            InitializeComponent();
            // Инициализируем изображение, отображаемое контролом
            Image = new Bitmap(Width, Height);
            // Инициализируем пустую очередь отображаемых букв
            LettersQueue = new Queue<Letter>();
            // Отображаем
            DrawContent();
        }

        /// <summary>
        /// Добавление буквы в очередь
        /// </summary>
        /// <param name="letter">Добавляемая буква</param>
        public void EnqueueLetter(char letter) {
            // TODO: Задаём координату Y буквы рандомно - чтоб они шли зигзагом
            LettersQueue.Enqueue(new Letter(letter, new PointF(Width + 10, Height / 2)));
        }

        // Изменение размеров контрола
        private void SymbolQueueControl_Resize(object sender, EventArgs e) {
            // Задаём изображение с новым размером
            Image = new Bitmap(Width, Height);
            // Отрисовываем содержимое
            DrawContent();
        }
    }
}
