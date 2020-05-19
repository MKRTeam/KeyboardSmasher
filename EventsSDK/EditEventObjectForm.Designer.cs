namespace EventsSDK
{
    partial class EditEventObjectForm
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
            this.textBoxObjectName = new System.Windows.Forms.TextBox();
            this.textBoxObjectDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.btnEditEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnSaveObject = new System.Windows.Forms.Button();
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
            // textBoxObjectName
            // 
            this.textBoxObjectName.Location = new System.Drawing.Point(76, 10);
            this.textBoxObjectName.Name = "textBoxObjectName";
            this.textBoxObjectName.Size = new System.Drawing.Size(206, 20);
            this.textBoxObjectName.TabIndex = 1;
            // 
            // textBoxObjectDescription
            // 
            this.textBoxObjectDescription.Location = new System.Drawing.Point(76, 36);
            this.textBoxObjectDescription.Multiline = true;
            this.textBoxObjectDescription.Name = "textBoxObjectDescription";
            this.textBoxObjectDescription.Size = new System.Drawing.Size(206, 134);
            this.textBoxObjectDescription.TabIndex = 3;
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
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.Location = new System.Drawing.Point(93, 176);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(189, 134);
            this.listBoxEvents.TabIndex = 4;
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.Location = new System.Drawing.Point(12, 206);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(75, 23);
            this.btnCreateEvent.TabIndex = 5;
            this.btnCreateEvent.Text = "Добавить";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            // 
            // btnEditEvent
            // 
            this.btnEditEvent.Location = new System.Drawing.Point(12, 235);
            this.btnEditEvent.Name = "btnEditEvent";
            this.btnEditEvent.Size = new System.Drawing.Size(75, 23);
            this.btnEditEvent.TabIndex = 6;
            this.btnEditEvent.Text = "Изменить";
            this.btnEditEvent.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(12, 264);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteEvent.TabIndex = 7;
            this.btnDeleteEvent.Text = "Удалить";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            // 
            // btnSaveObject
            // 
            this.btnSaveObject.Location = new System.Drawing.Point(105, 321);
            this.btnSaveObject.Name = "btnSaveObject";
            this.btnSaveObject.Size = new System.Drawing.Size(75, 23);
            this.btnSaveObject.TabIndex = 8;
            this.btnSaveObject.Text = "Сохранить";
            this.btnSaveObject.UseVisualStyleBackColor = true;
            // 
            // EditBiomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 356);
            this.Controls.Add(this.btnSaveObject);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.btnEditEvent);
            this.Controls.Add(this.btnCreateEvent);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.textBoxObjectDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxObjectName);
            this.Controls.Add(this.label1);
            this.Name = "EditBiomForm";
            this.Text = "EditBiomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxObjectName;
        private System.Windows.Forms.TextBox textBoxObjectDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.Button btnEditEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnSaveObject;
    }
}