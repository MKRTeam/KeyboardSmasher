namespace KeyboardSmasher.ExerciseMachine.GUI
{
    partial class MistakeCountControl
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.mistakeCountTextControl = new KeyboardSmasher.GUI.ExerciseControls.MistakeCountTextControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbTaskText = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.tlpMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mistakeCountTextControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.tlpMiddle, 0, 1);
            this.tlpMain.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpMain.Controls.Add(this.lbTaskText, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.08091F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.91909F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tlpMain.Size = new System.Drawing.Size(573, 367);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpMiddle
            // 
            this.tlpMiddle.ColumnCount = 1;
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMiddle.Controls.Add(this.mistakeCountTextControl, 0, 0);
            this.tlpMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMiddle.Location = new System.Drawing.Point(3, 235);
            this.tlpMiddle.Name = "tlpMiddle";
            this.tlpMiddle.RowCount = 1;
            this.tlpMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMiddle.Size = new System.Drawing.Size(567, 71);
            this.tlpMiddle.TabIndex = 0;
            // 
            // mistakeCountTextControl
            // 
            this.mistakeCountTextControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mistakeCountTextControl.Image = global::KeyboardSmasher.Properties.Resources.mistakeCountArrows;
            this.mistakeCountTextControl.Location = new System.Drawing.Point(3, 3);
            this.mistakeCountTextControl.Name = "mistakeCountTextControl";
            this.mistakeCountTextControl.Size = new System.Drawing.Size(561, 65);
            this.mistakeCountTextControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mistakeCountTextControl.TabIndex = 0;
            this.mistakeCountTextControl.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::KeyboardSmasher.Properties.Resources.keys;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(567, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbTaskText
            // 
            this.lbTaskText.AutoSize = true;
            this.lbTaskText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTaskText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTaskText.Location = new System.Drawing.Point(2, 309);
            this.lbTaskText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTaskText.Name = "lbTaskText";
            this.lbTaskText.Size = new System.Drawing.Size(569, 58);
            this.lbTaskText.TabIndex = 2;
            this.lbTaskText.Text = "special";
            this.lbTaskText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MistakeCountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "MistakeCountControl";
            this.Size = new System.Drawing.Size(573, 367);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mistakeCountTextControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpMiddle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private KeyboardSmasher.GUI.ExerciseControls.MistakeCountTextControl mistakeCountTextControl;
        private System.Windows.Forms.Label lbTaskText;
    }
}
