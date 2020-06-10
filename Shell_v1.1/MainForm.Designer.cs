namespace Shell_v1._02
{
    partial class MainForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.userControl = new Shell_v1._02.UserControl();
            this.SuspendLayout();
            // 
            // userControl
            // 
            this.userControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl.Location = new System.Drawing.Point(0, 0);
            this.userControl.Name = "userControl";
            this.userControl.Size = new System.Drawing.Size(1066, 594);
            this.userControl.TabIndex = 0;
            this.userControl.Load += new System.EventHandler(this.userControl_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 594);
            this.Controls.Add(this.userControl);
            this.Name = "MainForm";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private UserControl userControl;
    }
}