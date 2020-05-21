namespace EventsSDK
{
    partial class EditEventForm
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
            this.textBoxEventDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.btnCreateAction = new System.Windows.Forms.Button();
            this.btnEditAction = new System.Windows.Forms.Button();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.btnSaveEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxEventDescription
            // 
            this.textBoxEventDescription.Location = new System.Drawing.Point(75, 9);
            this.textBoxEventDescription.Multiline = true;
            this.textBoxEventDescription.Name = "textBoxEventDescription";
            this.textBoxEventDescription.Size = new System.Drawing.Size(545, 134);
            this.textBoxEventDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Описание";
            // 
            // listBoxActions
            // 
            this.listBoxActions.FormattingEnabled = true;
            this.listBoxActions.Location = new System.Drawing.Point(93, 153);
            this.listBoxActions.Name = "listBoxActions";
            this.listBoxActions.Size = new System.Drawing.Size(527, 160);
            this.listBoxActions.TabIndex = 4;
            // 
            // btnCreateAction
            // 
            this.btnCreateAction.Location = new System.Drawing.Point(12, 206);
            this.btnCreateAction.Name = "btnCreateAction";
            this.btnCreateAction.Size = new System.Drawing.Size(75, 23);
            this.btnCreateAction.TabIndex = 5;
            this.btnCreateAction.Text = "Добавить";
            this.btnCreateAction.UseVisualStyleBackColor = true;
            this.btnCreateAction.Click += new System.EventHandler(this.btnCreateAction_Click);
            // 
            // btnEditAction
            // 
            this.btnEditAction.Location = new System.Drawing.Point(12, 235);
            this.btnEditAction.Name = "btnEditAction";
            this.btnEditAction.Size = new System.Drawing.Size(75, 23);
            this.btnEditAction.TabIndex = 6;
            this.btnEditAction.Text = "Изменить";
            this.btnEditAction.UseVisualStyleBackColor = true;
            this.btnEditAction.Click += new System.EventHandler(this.btnEditAction_Click);
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.Location = new System.Drawing.Point(12, 264);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAction.TabIndex = 7;
            this.btnDeleteAction.Text = "Удалить";
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
            // 
            // btnSaveEvent
            // 
            this.btnSaveEvent.Location = new System.Drawing.Point(289, 321);
            this.btnSaveEvent.Name = "btnSaveEvent";
            this.btnSaveEvent.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEvent.TabIndex = 8;
            this.btnSaveEvent.Text = "Сохранить";
            this.btnSaveEvent.UseVisualStyleBackColor = true;
            this.btnSaveEvent.Click += new System.EventHandler(this.btnSaveEvent_Click);
            // 
            // EditEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 356);
            this.Controls.Add(this.btnSaveEvent);
            this.Controls.Add(this.btnDeleteAction);
            this.Controls.Add(this.btnEditAction);
            this.Controls.Add(this.btnCreateAction);
            this.Controls.Add(this.listBoxActions);
            this.Controls.Add(this.textBoxEventDescription);
            this.Controls.Add(this.label2);
            this.Name = "EditEventForm";
            this.Text = "EditEventForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxEventDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxActions;
        private System.Windows.Forms.Button btnCreateAction;
        private System.Windows.Forms.Button btnEditAction;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.Button btnSaveEvent;
    }
}