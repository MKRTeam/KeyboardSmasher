namespace KeyboardSmasher.ExerciseMachine.GUI
{
    partial class SymbolStreamControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolStreamControl));
            this.symbolQueueControl1 = new KeyboardSmasher.ExerciseMachine.GUI.SymbolQueueControl();
            ((System.ComponentModel.ISupportInitialize)(this.symbolQueueControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // symbolQueueControl1
            // 
            this.symbolQueueControl1.Image = ((System.Drawing.Image)(resources.GetObject("symbolQueueControl1.Image")));
            this.symbolQueueControl1.Location = new System.Drawing.Point(35, 132);
            this.symbolQueueControl1.Name = "symbolQueueControl1";
            this.symbolQueueControl1.Size = new System.Drawing.Size(272, 50);
            this.symbolQueueControl1.TabIndex = 0;
            this.symbolQueueControl1.TabStop = false;
            // 
            // SymbolStreamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.symbolQueueControl1);
            this.Name = "SymbolStreamControl";
            this.Size = new System.Drawing.Size(336, 207);
            ((System.ComponentModel.ISupportInitialize)(this.symbolQueueControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SymbolQueueControl symbolQueueControl1;
    }
}
