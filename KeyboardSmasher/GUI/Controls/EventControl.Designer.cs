namespace KeyboardSmasher.GUI.Controls
{
    partial class EventControl
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
            this.rTBTextActionScene = new System.Windows.Forms.RichTextBox();
            this.pictureBoxScene = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tLPActionButton = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScene)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rTBTextActionScene
            // 
            this.rTBTextActionScene.Location = new System.Drawing.Point(538, 3);
            this.rTBTextActionScene.Name = "rTBTextActionScene";
            this.rTBTextActionScene.Size = new System.Drawing.Size(232, 332);
            this.rTBTextActionScene.TabIndex = 0;
            this.rTBTextActionScene.Text = "";
            // 
            // pictureBoxScene
            // 
            this.pictureBoxScene.Location = new System.Drawing.Point(0, 3);
            this.pictureBoxScene.Name = "pictureBoxScene";
            this.pictureBoxScene.Size = new System.Drawing.Size(532, 332);
            this.pictureBoxScene.TabIndex = 1;
            this.pictureBoxScene.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tLPActionButton);
            this.panel1.Location = new System.Drawing.Point(6, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 215);
            this.panel1.TabIndex = 2;
            // 
            // tLPActionButton
            // 
            this.tLPActionButton.AutoSize = true;
            this.tLPActionButton.ColumnCount = 1;
            this.tLPActionButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tLPActionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPActionButton.Location = new System.Drawing.Point(0, 0);
            this.tLPActionButton.Name = "tLPActionButton";
            this.tLPActionButton.RowCount = 1;
            this.tLPActionButton.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tLPActionButton.Size = new System.Drawing.Size(767, 215);
            this.tLPActionButton.TabIndex = 0;
            // 
            // EventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxScene);
            this.Controls.Add(this.rTBTextActionScene);
            this.Name = "EventControl";
            this.Size = new System.Drawing.Size(773, 556);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EventControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScene)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTBTextActionScene;
        private System.Windows.Forms.PictureBox pictureBoxScene;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tLPActionButton;
    }
}
