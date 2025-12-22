namespace FastFoodPlanner
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.MenuLB = new System.Windows.Forms.ListBox();
            this.AddFoodBtn = new System.Windows.Forms.Button();
            this.ChnageFoodBtn = new System.Windows.Forms.Button();
            this.DeleteFoodBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Меню";
            // 
            // MenuLB
            // 
            this.MenuLB.FormattingEnabled = true;
            this.MenuLB.Location = new System.Drawing.Point(12, 25);
            this.MenuLB.Name = "MenuLB";
            this.MenuLB.Size = new System.Drawing.Size(276, 355);
            this.MenuLB.TabIndex = 1;
            // 
            // AddFoodBtn
            // 
            this.AddFoodBtn.Location = new System.Drawing.Point(294, 25);
            this.AddFoodBtn.Name = "AddFoodBtn";
            this.AddFoodBtn.Size = new System.Drawing.Size(105, 23);
            this.AddFoodBtn.TabIndex = 2;
            this.AddFoodBtn.Text = "Добавить блюдо";
            this.AddFoodBtn.UseVisualStyleBackColor = true;
            this.AddFoodBtn.Click += new System.EventHandler(this.AddFoodBtn_Click);
            // 
            // ChnageFoodBtn
            // 
            this.ChnageFoodBtn.Location = new System.Drawing.Point(294, 54);
            this.ChnageFoodBtn.Name = "ChnageFoodBtn";
            this.ChnageFoodBtn.Size = new System.Drawing.Size(105, 23);
            this.ChnageFoodBtn.TabIndex = 3;
            this.ChnageFoodBtn.Text = "Изменить рецепт";
            this.ChnageFoodBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteFoodBtn
            // 
            this.DeleteFoodBtn.Location = new System.Drawing.Point(294, 83);
            this.DeleteFoodBtn.Name = "DeleteFoodBtn";
            this.DeleteFoodBtn.Size = new System.Drawing.Size(105, 23);
            this.DeleteFoodBtn.TabIndex = 4;
            this.DeleteFoodBtn.Text = "Удалить блюдо";
            this.DeleteFoodBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 389);
            this.Controls.Add(this.DeleteFoodBtn);
            this.Controls.Add(this.ChnageFoodBtn);
            this.Controls.Add(this.AddFoodBtn);
            this.Controls.Add(this.MenuLB);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox MenuLB;
        private System.Windows.Forms.Button AddFoodBtn;
        private System.Windows.Forms.Button ChnageFoodBtn;
        private System.Windows.Forms.Button DeleteFoodBtn;
    }
}

