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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordsOnReactionControl));
            this.tB_Reading = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tB_writing = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tB_Reading
            // 
            this.tB_Reading.BackColor = System.Drawing.SystemColors.Control;
            this.tB_Reading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Reading.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tB_Reading.Font = new System.Drawing.Font("Vollkorn", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_Reading.Location = new System.Drawing.Point(105, 53);
            this.tB_Reading.Multiline = true;
            this.tB_Reading.Name = "tB_Reading";
            this.tB_Reading.ReadOnly = true;
            this.tB_Reading.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_Reading.ShortcutsEnabled = false;
            this.tB_Reading.Size = new System.Drawing.Size(800, 350);
            this.tB_Reading.TabIndex = 0;
            this.tB_Reading.Visible = false;
            // 
            // tB_writing
            // 
            this.tB_writing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_writing.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_writing.Location = new System.Drawing.Point(105, 604);
            this.tB_writing.Name = "tB_writing";
            this.tB_writing.Size = new System.Drawing.Size(800, 25);
            this.tB_writing.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(105, 430);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(800, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // WordsOnReactionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tB_writing);
            this.Controls.Add(this.tB_Reading);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "WordsOnReactionControl";
            this.Size = new System.Drawing.Size(1024, 768);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_Reading;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox tB_writing;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
