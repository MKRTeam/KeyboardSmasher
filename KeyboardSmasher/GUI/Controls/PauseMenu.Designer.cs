﻿namespace KeyboardSmasher.GUI.Controls
{
    partial class PauseMenu
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnContinueGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExitToMenu = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoEllipsis = true;
            this.btnExit.BackColor = System.Drawing.Color.FloralWhite;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(193, 366);
            this.btnExit.Margin = new System.Windows.Forms.Padding(8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(222, 40);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "ВЫХОД";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.AutoSize = true;
            this.btnSettings.BackColor = System.Drawing.Color.Ivory;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSettings.Location = new System.Drawing.Point(40, 190);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(8);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(235, 40);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "НАСТРОЙКИ";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnContinueGame
            // 
            this.btnContinueGame.AutoEllipsis = true;
            this.btnContinueGame.BackColor = System.Drawing.Color.FloralWhite;
            this.btnContinueGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinueGame.Location = new System.Drawing.Point(193, 134);
            this.btnContinueGame.Margin = new System.Windows.Forms.Padding(8);
            this.btnContinueGame.Name = "btnContinueGame";
            this.btnContinueGame.Size = new System.Drawing.Size(222, 40);
            this.btnContinueGame.TabIndex = 5;
            this.btnContinueGame.Text = "ПРОДОЛЖИТЬ";
            this.btnContinueGame.UseVisualStyleBackColor = false;
            this.btnContinueGame.Click += new System.EventHandler(this.btnContinueGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "ПАУЗА";
            // 
            // btnExitToMenu
            // 
            this.btnExitToMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitToMenu.AutoSize = true;
            this.btnExitToMenu.BackColor = System.Drawing.Color.FloralWhite;
            this.btnExitToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitToMenu.Location = new System.Drawing.Point(40, 310);
            this.btnExitToMenu.Margin = new System.Windows.Forms.Padding(8);
            this.btnExitToMenu.Name = "btnExitToMenu";
            this.btnExitToMenu.Size = new System.Drawing.Size(235, 40);
            this.btnExitToMenu.TabIndex = 8;
            this.btnExitToMenu.Text = "ВЫЙТИ В ГЛАВНОЕ МЕНЮ";
            this.btnExitToMenu.UseVisualStyleBackColor = false;
            this.btnExitToMenu.Click += new System.EventHandler(this.btnExitToMenu_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.AutoEllipsis = true;
            this.btnInfo.BackColor = System.Drawing.Color.FloralWhite;
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.Location = new System.Drawing.Point(193, 254);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(8);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(222, 40);
            this.btnInfo.TabIndex = 9;
            this.btnInfo.Text = "СПРАВКА";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // PauseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnExitToMenu);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnContinueGame);
            this.Controls.Add(this.label1);
            this.Name = "PauseMenu";
            this.Size = new System.Drawing.Size(460, 430);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnContinueGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExitToMenu;
        private System.Windows.Forms.Button btnInfo;
    }
}
