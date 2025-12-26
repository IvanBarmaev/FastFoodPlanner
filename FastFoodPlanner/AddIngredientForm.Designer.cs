namespace FastFoodPlanner
{
    partial class AddIngredientForm
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
            this.NameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ValueNUD = new System.Windows.Forms.NumericUpDown();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.AcceptBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ValueNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(12, 25);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(188, 20);
            this.NameTB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество";
            // 
            // ValueNUD
            // 
            this.ValueNUD.Location = new System.Drawing.Point(12, 64);
            this.ValueNUD.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.ValueNUD.Name = "ValueNUD";
            this.ValueNUD.Size = new System.Drawing.Size(188, 20);
            this.ValueNUD.TabIndex = 3;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(125, 90);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptBtn.Location = new System.Drawing.Point(44, 90);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.AcceptBtn.TabIndex = 5;
            this.AcceptBtn.Text = "Добавить";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            // 
            // AddIngredientForm
            // 
            this.AcceptButton = this.AcceptBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(212, 123);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ValueNUD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.label1);
            this.Name = "AddIngredientForm";
            this.Text = "AddIngredientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddIngredientFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ValueNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button AcceptBtn;
        public System.Windows.Forms.TextBox NameTB;
        public System.Windows.Forms.NumericUpDown ValueNUD;
    }
}