namespace EventsSDK
{
    partial class SDK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listboxBioms = new System.Windows.Forms.ListBox();
            this.btnCreateBiom = new System.Windows.Forms.Button();
            this.btnEditBiom = new System.Windows.Forms.Button();
            this.btnDeleteBiom = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(365, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            // 
            // listboxBioms
            // 
            this.listboxBioms.FormattingEnabled = true;
            this.listboxBioms.Location = new System.Drawing.Point(13, 28);
            this.listboxBioms.Name = "listboxBioms";
            this.listboxBioms.Size = new System.Drawing.Size(247, 264);
            this.listboxBioms.TabIndex = 1;
            // 
            // btnCreateBiom
            // 
            this.btnCreateBiom.Location = new System.Drawing.Point(276, 28);
            this.btnCreateBiom.Name = "btnCreateBiom";
            this.btnCreateBiom.Size = new System.Drawing.Size(75, 23);
            this.btnCreateBiom.TabIndex = 2;
            this.btnCreateBiom.Text = "Добавить";
            this.btnCreateBiom.UseVisualStyleBackColor = true;
            // 
            // btnEditBiom
            // 
            this.btnEditBiom.Location = new System.Drawing.Point(276, 58);
            this.btnEditBiom.Name = "btnEditBiom";
            this.btnEditBiom.Size = new System.Drawing.Size(75, 23);
            this.btnEditBiom.TabIndex = 3;
            this.btnEditBiom.Text = "Изменить";
            this.btnEditBiom.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBiom
            // 
            this.btnDeleteBiom.Location = new System.Drawing.Point(276, 88);
            this.btnDeleteBiom.Name = "btnDeleteBiom";
            this.btnDeleteBiom.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBiom.TabIndex = 4;
            this.btnDeleteBiom.Text = "Удалить";
            this.btnDeleteBiom.UseVisualStyleBackColor = true;
            // 
            // SDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 309);
            this.Controls.Add(this.btnDeleteBiom);
            this.Controls.Add(this.btnEditBiom);
            this.Controls.Add(this.btnCreateBiom);
            this.Controls.Add(this.listboxBioms);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "SDK";
            this.Text = "SDK";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ListBox listboxBioms;
        private System.Windows.Forms.Button btnCreateBiom;
        private System.Windows.Forms.Button btnEditBiom;
        private System.Windows.Forms.Button btnDeleteBiom;
    }
}