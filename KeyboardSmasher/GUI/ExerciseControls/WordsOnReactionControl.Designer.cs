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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tB_writing = new System.Windows.Forms.TextBox();
            this.buttonStartPause = new System.Windows.Forms.Button();
            this.labelResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tB_Reading
            // 
            this.tB_Reading.BackColor = System.Drawing.SystemColors.Control;
            this.tB_Reading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Reading.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tB_Reading.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_Reading.Location = new System.Drawing.Point(71, 37);
            this.tB_Reading.Multiline = true;
            this.tB_Reading.Name = "tB_Reading";
            this.tB_Reading.ReadOnly = true;
            this.tB_Reading.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_Reading.ShortcutsEnabled = false;
            this.tB_Reading.Size = new System.Drawing.Size(647, 230);
            this.tB_Reading.TabIndex = 2;
            this.tB_Reading.TabStop = false;
            this.tB_Reading.Text = "Напечатайте как можно быстрее в нижнем поле текст, который появится здесь!\r\nНажми" +
    "те СТАРТ чтобы начать";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tB_writing
            // 
            this.tB_writing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_writing.Enabled = false;
            this.tB_writing.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_writing.Location = new System.Drawing.Point(71, 376);
            this.tB_writing.Multiline = true;
            this.tB_writing.Name = "tB_writing";
            this.tB_writing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_writing.ShortcutsEnabled = false;
            this.tB_writing.Size = new System.Drawing.Size(647, 117);
            this.tB_writing.TabIndex = 1;
            // 
            // buttonStartPause
            // 
            this.buttonStartPause.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStartPause.FlatAppearance.BorderSize = 2;
            this.buttonStartPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartPause.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartPause.Location = new System.Drawing.Point(327, 297);
            this.buttonStartPause.Name = "buttonStartPause";
            this.buttonStartPause.Size = new System.Drawing.Size(139, 53);
            this.buttonStartPause.TabIndex = 0;
            this.buttonStartPause.Text = "СТАРТ";
            this.buttonStartPause.UseVisualStyleBackColor = false;
            this.buttonStartPause.Click += new System.EventHandler(this.buttonStartPause_Click);
            this.buttonStartPause.MouseLeave += new System.EventHandler(this.buttonStartPause_MouseLeave);
            this.buttonStartPause.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonStartPause_MouseMove);
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResults.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResults.Location = new System.Drawing.Point(160, 530);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(2, 24);
            this.labelResults.TabIndex = 3;
            // 
            // WordsOnReactionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KeyboardSmasher.Properties.Resources.keys_background_1024x768;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.buttonStartPause);
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
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox tB_writing;
        private System.Windows.Forms.Button buttonStartPause;
        private System.Windows.Forms.Label labelResults;
    }
}
