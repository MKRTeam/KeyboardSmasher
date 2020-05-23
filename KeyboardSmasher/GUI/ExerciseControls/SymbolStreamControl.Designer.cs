namespace KeyboardSmasher.GUI.ExerciseMachine
{
    partial class SymbolStreamControl {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolStreamControl));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lTaskText = new System.Windows.Forms.Label();
            this.pbKeyboard = new System.Windows.Forms.PictureBox();
            this.tlpMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.symbolQueueControl = new KeyboardSmasher.GUI.ExerciseMachine.SymbolQueueControl();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKeyboard)).BeginInit();
            this.tlpMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolQueueControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lTaskText, 0, 2);
            this.tlpMain.Controls.Add(this.pbKeyboard, 0, 0);
            this.tlpMain.Controls.Add(this.tlpMiddle, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.Size = new System.Drawing.Size(506, 347);
            this.tlpMain.TabIndex = 0;
            // 
            // lTaskText
            // 
            this.lTaskText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTaskText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTaskText.Location = new System.Drawing.Point(2, 277);
            this.lTaskText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTaskText.Name = "lTaskText";
            this.lTaskText.Size = new System.Drawing.Size(502, 70);
            this.lTaskText.TabIndex = 3;
            this.lTaskText.Text = "Успевайте нажимать клавиши, которые попадают в кольцо! Не ошибитесь с клавишей, и" +
    " нажимайте точно в нужное время!\r\n";
            this.lTaskText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbKeyboard
            // 
            this.pbKeyboard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbKeyboard.BackgroundImage")));
            this.pbKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbKeyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbKeyboard.Location = new System.Drawing.Point(2, 2);
            this.pbKeyboard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbKeyboard.Name = "pbKeyboard";
            this.pbKeyboard.Size = new System.Drawing.Size(502, 204);
            this.pbKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbKeyboard.TabIndex = 0;
            this.pbKeyboard.TabStop = false;
            // 
            // tlpMiddle
            // 
            this.tlpMiddle.ColumnCount = 1;
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMiddle.Controls.Add(this.symbolQueueControl, 0, 0);
            this.tlpMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMiddle.Location = new System.Drawing.Point(2, 210);
            this.tlpMiddle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpMiddle.Name = "tlpMiddle";
            this.tlpMiddle.RowCount = 1;
            this.tlpMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMiddle.Size = new System.Drawing.Size(502, 65);
            this.tlpMiddle.TabIndex = 2;
            // 
            // symbolQueueControl
            // 
            this.symbolQueueControl.AddingLettersIsOver = false;
            this.symbolQueueControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symbolQueueControl.Image = ((System.Drawing.Image)(resources.GetObject("symbolQueueControl.Image")));
            this.symbolQueueControl.Location = new System.Drawing.Point(2, 2);
            this.symbolQueueControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.symbolQueueControl.Name = "symbolQueueControl";
            this.symbolQueueControl.Size = new System.Drawing.Size(498, 61);
            this.symbolQueueControl.TabIndex = 1;
            this.symbolQueueControl.TabStop = false;
            // 
            // SymbolStreamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(112, 81);
            this.Name = "SymbolStreamControl";
            this.Size = new System.Drawing.Size(506, 347);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbKeyboard)).EndInit();
            this.tlpMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.symbolQueueControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.PictureBox pbKeyboard;
        private SymbolQueueControl symbolQueueControl;
        private System.Windows.Forms.TableLayoutPanel tlpMiddle;
        private System.Windows.Forms.Label lTaskText;
    }
}
