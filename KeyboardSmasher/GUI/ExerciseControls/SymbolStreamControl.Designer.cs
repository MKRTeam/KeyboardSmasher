namespace KeyboardSmasher.ExerciseMachine.GUI
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
            this.symbolQueueControl = new KeyboardSmasher.ExerciseMachine.GUI.SymbolQueueControl();
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
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.Size = new System.Drawing.Size(675, 427);
            this.tlpMain.TabIndex = 0;
            // 
            // lTaskText
            // 
            this.lTaskText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTaskText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTaskText.Location = new System.Drawing.Point(3, 341);
            this.lTaskText.Name = "lTaskText";
            this.lTaskText.Size = new System.Drawing.Size(669, 86);
            this.lTaskText.TabIndex = 3;
            this.lTaskText.Text = "Успевайте нажимать клавиши, которые попадают в кольцо! Не ошибитесь с клавишей, и" +
    " нажимайте точно в нужное время!\r\n";
            this.lTaskText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbKeyboard
            // 
            this.pbKeyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbKeyboard.Image = ((System.Drawing.Image)(resources.GetObject("pbKeyboard.Image")));
            this.pbKeyboard.Location = new System.Drawing.Point(3, 3);
            this.pbKeyboard.Name = "pbKeyboard";
            this.pbKeyboard.Size = new System.Drawing.Size(669, 250);
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
            this.tlpMiddle.Location = new System.Drawing.Point(3, 259);
            this.tlpMiddle.Name = "tlpMiddle";
            this.tlpMiddle.RowCount = 1;
            this.tlpMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMiddle.Size = new System.Drawing.Size(669, 79);
            this.tlpMiddle.TabIndex = 2;
            // 
            // symbolQueueControl
            // 
            this.symbolQueueControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symbolQueueControl.Image = ((System.Drawing.Image)(resources.GetObject("symbolQueueControl.Image")));
            this.symbolQueueControl.Location = new System.Drawing.Point(3, 3);
            this.symbolQueueControl.Name = "symbolQueueControl";
            this.symbolQueueControl.Size = new System.Drawing.Size(663, 73);
            this.symbolQueueControl.TabIndex = 1;
            this.symbolQueueControl.TabStop = false;
            // 
            // SymbolStreamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(150, 100);
            this.Name = "SymbolStreamControl";
            this.Size = new System.Drawing.Size(675, 427);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
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
