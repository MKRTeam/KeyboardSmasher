namespace EventsSDK
{
    partial class EditBiomForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBiomName = new System.Windows.Forms.TextBox();
            this.textBoxBiomDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxObjects = new System.Windows.Forms.ListBox();
            this.btnCreateObject = new System.Windows.Forms.Button();
            this.btnEditObject = new System.Windows.Forms.Button();
            this.btnDeleteObject = new System.Windows.Forms.Button();
            this.btnSaveBiom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // textBoxBiomName
            // 
            this.textBoxBiomName.Location = new System.Drawing.Point(76, 10);
            this.textBoxBiomName.Name = "textBoxBiomName";
            this.textBoxBiomName.Size = new System.Drawing.Size(206, 20);
            this.textBoxBiomName.TabIndex = 1;
            // 
            // textBoxBiomDescription
            // 
            this.textBoxBiomDescription.Location = new System.Drawing.Point(76, 36);
            this.textBoxBiomDescription.Multiline = true;
            this.textBoxBiomDescription.Name = "textBoxBiomDescription";
            this.textBoxBiomDescription.Size = new System.Drawing.Size(206, 134);
            this.textBoxBiomDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Описание";
            // 
            // listBoxObjects
            // 
            this.listBoxObjects.FormattingEnabled = true;
            this.listBoxObjects.Location = new System.Drawing.Point(93, 176);
            this.listBoxObjects.Name = "listBoxObjects";
            this.listBoxObjects.Size = new System.Drawing.Size(189, 134);
            this.listBoxObjects.TabIndex = 4;
            // 
            // btnCreateObject
            // 
            this.btnCreateObject.Location = new System.Drawing.Point(12, 206);
            this.btnCreateObject.Name = "btnCreateObject";
            this.btnCreateObject.Size = new System.Drawing.Size(75, 23);
            this.btnCreateObject.TabIndex = 5;
            this.btnCreateObject.Text = "Добавить";
            this.btnCreateObject.UseVisualStyleBackColor = true;
            this.btnCreateObject.Click += new System.EventHandler(this.btnCreateObject_Click);
            // 
            // btnEditObject
            // 
            this.btnEditObject.Location = new System.Drawing.Point(12, 235);
            this.btnEditObject.Name = "btnEditObject";
            this.btnEditObject.Size = new System.Drawing.Size(75, 23);
            this.btnEditObject.TabIndex = 6;
            this.btnEditObject.Text = "Изменить";
            this.btnEditObject.UseVisualStyleBackColor = true;
            this.btnEditObject.Click += new System.EventHandler(this.btnEditObject_Click);
            // 
            // btnDeleteObject
            // 
            this.btnDeleteObject.Location = new System.Drawing.Point(12, 264);
            this.btnDeleteObject.Name = "btnDeleteObject";
            this.btnDeleteObject.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteObject.TabIndex = 7;
            this.btnDeleteObject.Text = "Удалить";
            this.btnDeleteObject.UseVisualStyleBackColor = true;
            this.btnDeleteObject.Click += new System.EventHandler(this.btnDeleteObject_Click);
            // 
            // btnSaveBiom
            // 
            this.btnSaveBiom.Location = new System.Drawing.Point(105, 321);
            this.btnSaveBiom.Name = "btnSaveBiom";
            this.btnSaveBiom.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBiom.TabIndex = 8;
            this.btnSaveBiom.Text = "Сохранить";
            this.btnSaveBiom.UseVisualStyleBackColor = true;
            this.btnSaveBiom.Click += new System.EventHandler(this.btnSaveBiom_Click);
            // 
            // EditBiomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 356);
            this.Controls.Add(this.btnSaveBiom);
            this.Controls.Add(this.btnDeleteObject);
            this.Controls.Add(this.btnEditObject);
            this.Controls.Add(this.btnCreateObject);
            this.Controls.Add(this.listBoxObjects);
            this.Controls.Add(this.textBoxBiomDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBiomName);
            this.Controls.Add(this.label1);
            this.Name = "EditBiomForm";
            this.Text = "EditBiomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBiomName;
        private System.Windows.Forms.TextBox textBoxBiomDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxObjects;
        private System.Windows.Forms.Button btnCreateObject;
        private System.Windows.Forms.Button btnEditObject;
        private System.Windows.Forms.Button btnDeleteObject;
        private System.Windows.Forms.Button btnSaveBiom;
    }
}