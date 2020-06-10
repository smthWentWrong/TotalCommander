namespace Shell_v1._02
{
    partial class ShellBrowser
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.comboBoxDisks = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(364, 27);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 1;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(445, 27);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Open";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // comboBoxDisks
            // 
            this.comboBoxDisks.FormattingEnabled = true;
            this.comboBoxDisks.Location = new System.Drawing.Point(3, 3);
            this.comboBoxDisks.Name = "comboBoxDisks";
            this.comboBoxDisks.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDisks.TabIndex = 5;
            this.comboBoxDisks.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisks_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(4, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(516, 446);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(364, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // ShellBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBoxDisks);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.textBox1);
            this.Name = "ShellBrowser";
            this.Size = new System.Drawing.Size(523, 505);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.ComboBox comboBoxDisks;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}
