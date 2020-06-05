namespace KeyboardSmasher.ExerciseMachine.GUI
{
    partial class WordsOnReactionControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tB_Reading = new System.Windows.Forms.TextBox();
            this.timerForExercise = new System.Windows.Forms.Timer(this.components);
            this.tB_writing = new System.Windows.Forms.TextBox();
            this.buttonStartEnd = new System.Windows.Forms.Button();
            this.labelResults = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.timerToDisplay = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tB_Reading
            // 
            this.tB_Reading.BackColor = System.Drawing.SystemColors.Control;
            this.tB_Reading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Reading.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tB_Reading.Font = new System.Drawing.Font("Noto Serif", 14.25F);
            this.tB_Reading.Location = new System.Drawing.Point(71, 17);
            this.tB_Reading.Multiline = true;
            this.tB_Reading.Name = "tB_Reading";
            this.tB_Reading.ReadOnly = true;
            this.tB_Reading.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_Reading.ShortcutsEnabled = false;
            this.tB_Reading.Size = new System.Drawing.Size(647, 230);
            this.tB_Reading.TabIndex = 2;
            this.tB_Reading.TabStop = false;
            this.tB_Reading.Text = "Напечатайте как можно быстрее в нижнем поле текст, который появится здесь!\r\nНажми" +
    "те  СТАРТ  чтобы начать";
            // 
            // timerForExercise
            // 
            this.timerForExercise.Tick += new System.EventHandler(this.timerForExercise_Tick);
            // 
            // tB_writing
            // 
            this.tB_writing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_writing.Enabled = false;
            this.tB_writing.Font = new System.Drawing.Font("Noto Serif", 9.749999F);
            this.tB_writing.Location = new System.Drawing.Point(71, 344);
            this.tB_writing.Multiline = true;
            this.tB_writing.Name = "tB_writing";
            this.tB_writing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_writing.ShortcutsEnabled = false;
            this.tB_writing.Size = new System.Drawing.Size(647, 112);
            this.tB_writing.TabIndex = 1;
            // 
            // buttonStartEnd
            // 
            this.buttonStartEnd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStartEnd.FlatAppearance.BorderSize = 2;
            this.buttonStartEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartEnd.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.buttonStartEnd.Location = new System.Drawing.Point(327, 263);
            this.buttonStartEnd.Name = "buttonStartEnd";
            this.buttonStartEnd.Size = new System.Drawing.Size(139, 53);
            this.buttonStartEnd.TabIndex = 0;
            this.buttonStartEnd.Text = "СТАРТ";
            this.buttonStartEnd.UseVisualStyleBackColor = false;
            this.buttonStartEnd.Click += new System.EventHandler(this.buttonStartEnd_Click);
            this.buttonStartEnd.MouseLeave += new System.EventHandler(this.buttonStartEnd_MouseLeave);
            this.buttonStartEnd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonStartEnd_MouseMove);
            // 
            // labelResults
            // 
            this.labelResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResults.Font = new System.Drawing.Font("Noto Serif Cond", 12F);
            this.labelResults.Location = new System.Drawing.Point(71, 487);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(647, 54);
            this.labelResults.TabIndex = 3;
            // 
            // labelTimer
            // 
            this.labelTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTimer.Font = new System.Drawing.Font("Noto Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimer.Location = new System.Drawing.Point(650, 263);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(68, 53);
            this.labelTimer.TabIndex = 4;
            this.labelTimer.Text = "100";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerToDisplay
            // 
            this.timerToDisplay.Interval = 1000;
            this.timerToDisplay.Tick += new System.EventHandler(this.timerToDisplay_Tick);
            // 
            // WordsOnReactionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KeyboardSmasher.Properties.Resources.keys_background_1024x768;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.buttonStartEnd);
            this.Controls.Add(this.tB_writing);
            this.Controls.Add(this.tB_Reading);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "WordsOnReactionControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WordsOnReactionControl_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_Reading;
        private System.Windows.Forms.Timer timerForExercise;
        private System.Windows.Forms.TextBox tB_writing;
        private System.Windows.Forms.Button buttonStartEnd;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Timer timerToDisplay;
    }
}
