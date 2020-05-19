namespace EventsSDK
{
    partial class SDK
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonAddBiom = new System.Windows.Forms.Button();
            this.buttonDeleteBiom = new System.Windows.Forms.Button();
            this.listBoxBioms = new System.Windows.Forms.ListBox();
            this.textBoxDescriptionBiom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNameBiom = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDeleteAnimal = new System.Windows.Forms.Button();
            this.buttonAddAnimal = new System.Windows.Forms.Button();
            this.listBoxAnimals = new System.Windows.Forms.ListBox();
            this.textBoxDescriptionAnimal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNameAnimal = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDeleteAction = new System.Windows.Forms.Button();
            this.buttonAddAction = new System.Windows.Forms.Button();
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.textBoxDescriptionAction = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNameAction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentBiom = new System.Windows.Forms.Label();
            this.labelCurrentAnimal = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonAddBiom);
            this.tabPage1.Controls.Add(this.buttonDeleteBiom);
            this.tabPage1.Controls.Add(this.listBoxBioms);
            this.tabPage1.Controls.Add(this.textBoxDescriptionBiom);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBoxNameBiom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(713, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настрока биома";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonAddBiom
            // 
            this.buttonAddBiom.Location = new System.Drawing.Point(291, 305);
            this.buttonAddBiom.Name = "buttonAddBiom";
            this.buttonAddBiom.Size = new System.Drawing.Size(105, 25);
            this.buttonAddBiom.TabIndex = 27;
            this.buttonAddBiom.Text = "Добавить";
            this.buttonAddBiom.UseVisualStyleBackColor = true;
            this.buttonAddBiom.Click += new System.EventHandler(this.buttonAddBiom_Click);
            // 
            // buttonDeleteBiom
            // 
            this.buttonDeleteBiom.Location = new System.Drawing.Point(602, 304);
            this.buttonDeleteBiom.Name = "buttonDeleteBiom";
            this.buttonDeleteBiom.Size = new System.Drawing.Size(105, 25);
            this.buttonDeleteBiom.TabIndex = 26;
            this.buttonDeleteBiom.Text = "Удалить";
            this.buttonDeleteBiom.UseVisualStyleBackColor = true;
            this.buttonDeleteBiom.Click += new System.EventHandler(this.buttonDeleteBiom_Click);
            // 
            // listBoxBioms
            // 
            this.listBoxBioms.FormattingEnabled = true;
            this.listBoxBioms.Location = new System.Drawing.Point(446, 34);
            this.listBoxBioms.Name = "listBoxBioms";
            this.listBoxBioms.Size = new System.Drawing.Size(261, 264);
            this.listBoxBioms.TabIndex = 25;
            // 
            // textBoxDescriptionBiom
            // 
            this.textBoxDescriptionBiom.Location = new System.Drawing.Point(23, 111);
            this.textBoxDescriptionBiom.Multiline = true;
            this.textBoxDescriptionBiom.Name = "textBoxDescriptionBiom";
            this.textBoxDescriptionBiom.Size = new System.Drawing.Size(373, 187);
            this.textBoxDescriptionBiom.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Описание биома";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Имя биома";
            // 
            // textBoxNameBiom
            // 
            this.textBoxNameBiom.Location = new System.Drawing.Point(21, 48);
            this.textBoxNameBiom.Name = "textBoxNameBiom";
            this.textBoxNameBiom.Size = new System.Drawing.Size(375, 20);
            this.textBoxNameBiom.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDeleteAnimal);
            this.tabPage2.Controls.Add(this.buttonAddAnimal);
            this.tabPage2.Controls.Add(this.listBoxAnimals);
            this.tabPage2.Controls.Add(this.textBoxDescriptionAnimal);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBoxNameAnimal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(713, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Создание животных";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteAnimal
            // 
            this.buttonDeleteAnimal.Location = new System.Drawing.Point(596, 305);
            this.buttonDeleteAnimal.Name = "buttonDeleteAnimal";
            this.buttonDeleteAnimal.Size = new System.Drawing.Size(105, 25);
            this.buttonDeleteAnimal.TabIndex = 16;
            this.buttonDeleteAnimal.Text = "Удалить";
            this.buttonDeleteAnimal.UseVisualStyleBackColor = true;
            // 
            // buttonAddAnimal
            // 
            this.buttonAddAnimal.Location = new System.Drawing.Point(285, 291);
            this.buttonAddAnimal.Name = "buttonAddAnimal";
            this.buttonAddAnimal.Size = new System.Drawing.Size(105, 25);
            this.buttonAddAnimal.TabIndex = 15;
            this.buttonAddAnimal.Text = "Добавить";
            this.buttonAddAnimal.UseVisualStyleBackColor = true;
            // 
            // listBoxAnimals
            // 
            this.listBoxAnimals.FormattingEnabled = true;
            this.listBoxAnimals.Location = new System.Drawing.Point(440, 35);
            this.listBoxAnimals.Name = "listBoxAnimals";
            this.listBoxAnimals.Size = new System.Drawing.Size(261, 264);
            this.listBoxAnimals.TabIndex = 14;
            // 
            // textBoxDescriptionAnimal
            // 
            this.textBoxDescriptionAnimal.Location = new System.Drawing.Point(17, 98);
            this.textBoxDescriptionAnimal.Multiline = true;
            this.textBoxDescriptionAnimal.Name = "textBoxDescriptionAnimal";
            this.textBoxDescriptionAnimal.Size = new System.Drawing.Size(373, 187);
            this.textBoxDescriptionAnimal.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Описание";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Имя животного";
            // 
            // textBoxNameAnimal
            // 
            this.textBoxNameAnimal.Location = new System.Drawing.Point(15, 35);
            this.textBoxNameAnimal.Name = "textBoxNameAnimal";
            this.textBoxNameAnimal.Size = new System.Drawing.Size(375, 20);
            this.textBoxNameAnimal.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonDeleteAction);
            this.tabPage3.Controls.Add(this.buttonAddAction);
            this.tabPage3.Controls.Add(this.listBoxActions);
            this.tabPage3.Controls.Add(this.textBoxDescriptionAction);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBoxNameAction);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(713, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Создание дейсвий";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteAction
            // 
            this.buttonDeleteAction.Location = new System.Drawing.Point(596, 292);
            this.buttonDeleteAction.Name = "buttonDeleteAction";
            this.buttonDeleteAction.Size = new System.Drawing.Size(105, 25);
            this.buttonDeleteAction.TabIndex = 24;
            this.buttonDeleteAction.Text = "Удалить";
            this.buttonDeleteAction.UseVisualStyleBackColor = true;
            // 
            // buttonAddAction
            // 
            this.buttonAddAction.Location = new System.Drawing.Point(285, 291);
            this.buttonAddAction.Name = "buttonAddAction";
            this.buttonAddAction.Size = new System.Drawing.Size(105, 25);
            this.buttonAddAction.TabIndex = 23;
            this.buttonAddAction.Text = "Добавить";
            this.buttonAddAction.UseVisualStyleBackColor = true;
            // 
            // listBoxActions
            // 
            this.listBoxActions.FormattingEnabled = true;
            this.listBoxActions.Location = new System.Drawing.Point(440, 22);
            this.listBoxActions.Name = "listBoxActions";
            this.listBoxActions.Size = new System.Drawing.Size(261, 264);
            this.listBoxActions.TabIndex = 22;
            // 
            // textBoxDescriptionAction
            // 
            this.textBoxDescriptionAction.Location = new System.Drawing.Point(17, 98);
            this.textBoxDescriptionAction.Multiline = true;
            this.textBoxDescriptionAction.Name = "textBoxDescriptionAction";
            this.textBoxDescriptionAction.Size = new System.Drawing.Size(373, 187);
            this.textBoxDescriptionAction.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Описание";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Название дейсвия";
            // 
            // textBoxNameAction
            // 
            this.textBoxNameAction.Location = new System.Drawing.Point(15, 35);
            this.textBoxNameAction.Name = "textBoxNameAction";
            this.textBoxNameAction.Size = new System.Drawing.Size(375, 20);
            this.textBoxNameAction.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текущий биом";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выбранное животное";
            // 
            // labelCurrentBiom
            // 
            this.labelCurrentBiom.AutoSize = true;
            this.labelCurrentBiom.Location = new System.Drawing.Point(243, 37);
            this.labelCurrentBiom.Name = "labelCurrentBiom";
            this.labelCurrentBiom.Size = new System.Drawing.Size(81, 13);
            this.labelCurrentBiom.TabIndex = 3;
            this.labelCurrentBiom.Text = "Текущий биом";
            // 
            // labelCurrentAnimal
            // 
            this.labelCurrentAnimal.AutoSize = true;
            this.labelCurrentAnimal.Location = new System.Drawing.Point(134, 37);
            this.labelCurrentAnimal.Name = "labelCurrentAnimal";
            this.labelCurrentAnimal.Size = new System.Drawing.Size(81, 13);
            this.labelCurrentAnimal.TabIndex = 4;
            this.labelCurrentAnimal.Text = "Текущий биом";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(769, 24);
            this.MainMenu.TabIndex = 5;
            this.MainMenu.Text = "MainMenu";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // SDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 422);
            this.Controls.Add(this.labelCurrentAnimal);
            this.Controls.Add(this.labelCurrentBiom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "SDK";
            this.Text = "SDK";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxDescriptionBiom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNameBiom;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentBiom;
        private System.Windows.Forms.Label labelCurrentAnimal;
        private System.Windows.Forms.TextBox textBoxDescriptionAnimal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNameAnimal;
        private System.Windows.Forms.Button buttonAddBiom;
        private System.Windows.Forms.Button buttonDeleteBiom;
        private System.Windows.Forms.ListBox listBoxBioms;
        private System.Windows.Forms.Button buttonDeleteAnimal;
        private System.Windows.Forms.Button buttonAddAnimal;
        private System.Windows.Forms.ListBox listBoxAnimals;
        private System.Windows.Forms.Button buttonDeleteAction;
        private System.Windows.Forms.Button buttonAddAction;
        private System.Windows.Forms.ListBox listBoxActions;
        private System.Windows.Forms.TextBox textBoxDescriptionAction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxNameAction;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
    }
}

