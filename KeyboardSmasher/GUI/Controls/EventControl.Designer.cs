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
            this.tLPActionButton = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rTBTextActionScene
            // 
            this.rTBTextActionScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBTextActionScene.Location = new System.Drawing.Point(0, 0);
            this.rTBTextActionScene.Name = "rTBTextActionScene";
            this.rTBTextActionScene.ReadOnly = true;
            this.rTBTextActionScene.Size = new System.Drawing.Size(285, 362);
            this.rTBTextActionScene.TabIndex = 0;
            this.rTBTextActionScene.Text = "";
            // 
            // pictureBoxScene
            // 
            this.pictureBoxScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxScene.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxScene.Name = "pictureBoxScene";
            this.pictureBoxScene.Size = new System.Drawing.Size(484, 362);
            this.pictureBoxScene.TabIndex = 1;
            this.pictureBoxScene.TabStop = false;
            // 
            // tLPActionButton
            // 
            this.tLPActionButton.AutoScroll = true;
            this.tLPActionButton.AutoSize = true;
            this.tLPActionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tLPActionButton.ColumnCount = 1;
            this.tLPActionButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tLPActionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPActionButton.Location = new System.Drawing.Point(0, 0);
            this.tLPActionButton.Name = "tLPActionButton";
            this.tLPActionButton.RowCount = 1;
            this.tLPActionButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPActionButton.Size = new System.Drawing.Size(773, 190);
            this.tLPActionButton.TabIndex = 0;
            this.tLPActionButton.TabStop = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxScene);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rTBTextActionScene);
            this.splitContainer1.Size = new System.Drawing.Size(773, 362);
            this.splitContainer1.SplitterDistance = 484;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tLPActionButton);
            this.splitContainer2.Size = new System.Drawing.Size(773, 556);
            this.splitContainer2.SplitterDistance = 362;
            this.splitContainer2.TabIndex = 3;
            // 
            // EventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "EventControl";
            this.Size = new System.Drawing.Size(773, 556);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScene)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTBTextActionScene;
        private System.Windows.Forms.PictureBox pictureBoxScene;
        private System.Windows.Forms.TableLayoutPanel tLPActionButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}
