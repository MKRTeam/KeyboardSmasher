﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KeyboardSmasher.ExerciseMachine.GUI {
    public partial class SymbolQueueControl : PictureBox {
        /// <summary>
        /// Класс буквы для хранения информации об отображаемых буквах
        /// </summary>
        private class Letter {
            public readonly char letter; // символ буквы
            public PointF position; // позиция рисования буквы
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
        /// Блокирующийся объект для синхронизации доступа потоков к полю Image
        /// </summary>
        private readonly object GraphicsLock = new object();

        /// <summary>
        /// Блокирующийся объект для синхронизации доступа потоков к обновлению состояния элемента управления
        /// </summary>
        private readonly object UpdatingStateLock = new object();

        /// <summary>
        /// Таймер обновления состояния элемента управления при отображении потока букв
        /// </summary>
        private System.Threading.Timer UpdatingStateTimer { get; set; }



        // -----------------Параметры рисования------------------
        private Color g_circleColor = Color.Orange; // цвет кольца
        private int g_penWidth; // ширина линии кольца (зависит от высоты элемента управления)
        private Point g_circleRectLeftUpPoint; // верхний левый угол описанного вокруг окружности четырёхугольника - с учётом ширины кисти
        private int g_circleDiametr; // диаметр окружности выбора букв (равен высоте полосы контрола минус ширина кисти)
        private int g_fontSize; // размер шрифта, с учётом ширины полосы (равен половине высоты контрола
        private Font g_font; // шрифт

        /// <summary>
        /// Метод вычисления констант рисования на основе размеров элемента управления 
        /// и ширины линии окружности выбора букв
        /// </summary>
        private void CalcDrawingParams() {
            g_penWidth = Height / 10;
            g_circleRectLeftUpPoint = new Point(0 + g_penWidth / 2, 0 + g_penWidth / 2);
            g_circleDiametr = Height - g_penWidth;
            g_fontSize = Height / 2;
            g_font = new Font(FontFamily.GenericSansSerif, g_fontSize);
        }
        // -----------------Параметры рисования------------------



        /// <summary>
        /// Добавить первую букву из очереди ожидающих отображения букв в список отображаемых букв,
        /// если соблюдается необходимый интервал после последней отображаемой буквой
        /// </summary>
        private void AddLetterFromBuffer() {
            // Если очередь ожидающих букв пуста - добавлять нечего
            if (AddingLettersQueue.Count == 0)
                return;
            // Если расстояние между последней отображаемой буквой (если есть) и правой границей элемента управления
            // (точкой добавления новой буквы) не меньше пороговой величины (диаметра окружности выбора букв) - добавляем букву
            if (LettersStream.Count == 0 || (LettersStream.Count != 0 && Width - LettersStream.Last.Value.position.X >= Height)) {
                // Добавляемая буква появляется на правой границе элемента управления
                float xPos = Width;
                // Координата Y буквы задаётся случайно - так, чтобы буквы "прыгали", при этом есть отступ от горизонтальных границ
                Random random = new Random();
                float yPos = (Height / 2 - 5) - random.Next(Height / 2 - 15); // Height / 2 - ширина шрифта
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
            // Если первая буква ушла за линию - она исчезает
            if (LettersStream.First.Value.position.X <= 0)
                LettersStream.RemoveFirst();
            // Если отображаемых букв нет - двигать нечего, выходим
            if (LettersStream.Count == 0)
                return;
            // Обходим двусвязный список и уменьшаем координату X каждой вершины на величину сдвига
            foreach (var listNode in LettersStream)
                listNode.position.X -= pushValue;
        }

        /// <summary>
        /// Отрисовать новое состояние элемента управления
        /// </summary>
        private void DrawNewState() {
            // Параметры рисования
            // Блокируем доступ к атрибуту Image другим потокам, и рисуем новое состояние элемента управления
            lock (GraphicsLock) {
                Graphics g = Graphics.FromImage(Image);
                // Задаём сглаживание при рисовании
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                // Заливаем холст белым
                g.Clear(Color.White);
                // Рисуем окружность выбора буквы в левом конце полосы контрола
                g.DrawEllipse(new Pen(g_circleColor, g_penWidth), g_circleRectLeftUpPoint.X, g_circleRectLeftUpPoint.Y, g_circleDiametr, g_circleDiametr);
                // Рисуем буквы в соответствии с их информацией
                foreach (var letter in LettersStream)
                    g.DrawString(letter.letter.ToString(), g_font, new SolidBrush(letter.color), letter.position.X, letter.position.Y - g_fontSize / 2);
                g.Dispose();
            }
            Invalidate();
        }

        /// <summary>
        /// Обновить состояние элемента управления: добавить очередную букву из очереди ожидающих букв,
        /// сдвинуть уже отображаемые буквы влево, отрисовать новое состояние
        /// </summary>
        /// <param name="nullParam">Неиспользуемый параметр для соответствия делегату TimerCallback</param>
        private void UpdateState(object nullParam) {
            // Блокируем обновление состояния элемента управления, чтобы не было попытки
            // обновить состояние при обновлении состояния (критическая секция)
            lock (UpdatingStateLock) {
                // Если менять нечего - выходим
                if (LettersStream.Count == 0 && AddingLettersQueue.Count == 0)
                    return;
                // Добавляем букву из очереди добавляемых букв
                AddLetterFromBuffer();
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
            lock (GraphicsLock) {
                Image = new Bitmap(Width, Height);
            }
            // Инициализируем пустую очередь добавляемых букв
            AddingLettersQueue = new Queue<char>();
            // Инициализируем пустой список отображаемых букв
            LettersStream = new LinkedList<Letter>();
            // Задаём константные параметры рисования
            CalcDrawingParams();
            // Отрисовываем окружность выбора, чтобы она была видна при добавлении элемента управления на форму
            DrawNewState();
            Invalidate();
        }



        /// <summary>
        /// Запуск потока букв
        /// </summary>
        /// <param name="speedCoefficient">Коэффициент ускорения (мс). Ускорение при значении от нуля до единицы (не включая).
        /// Замедление при значении больше единицы. Стандартное значение равняется единице</param>
        public void StartLettersStream() {
            if (UpdatingStateTimer != null)
                return;
            // Запускаем таймер обновления состояния
            UpdatingStateTimer = new System.Threading.Timer(UpdateState, null, 0, 10);
        }

        /// <summary>
        /// Остановка потока букв
        /// </summary>
        public void StopLettersStream() {
            // Удаляем таймер обновления состояния
            if (UpdatingStateTimer != null)
                UpdatingStateTimer.Dispose();
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
        /// Получить символ, в данный момент находящийся в окружности выбора букв
        /// </summary>
        /// <returns>Символ, находящийся в окружности выбора букв. Если такой отсутствует, возвращается символ '\0'</returns>
        public char GetRoundedChar() {
            Letter firstLetter = LettersStream.First.Value;
            if (firstLetter.position.X < g_circleRectLeftUpPoint.X + g_circleDiametr && firstLetter.position.X > g_circleRectLeftUpPoint.X)
                return firstLetter.letter;
            else
                return '\0';
        }

        /// <summary>
        /// Обработчик события "размер контрола изменён"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void SymbolQueueControl_SizeChanged(object sender, EventArgs e) {
            // Меняем размеры изображения под новый размер элемента управления, при этом блокируем
            // атрибут Image для использования другими потоками 
            lock (GraphicsLock) {
                Image = new Bitmap(Size.Width, Size.Height);
            }
            // Перевычисляем параметры рисования
            CalcDrawingParams();
            // Отрисовываем новое состояние элемента управления
            DrawNewState();
        }
    }
}