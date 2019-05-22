namespace ImgProc1
{
    partial class FormLogContrast
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
            this.hS_LogContrast = new System.Windows.Forms.HScrollBar();
            this.tB_LogContrast = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hS_LogContrast
            // 
            this.hS_LogContrast.Location = new System.Drawing.Point(9, 45);
            this.hS_LogContrast.Name = "hS_LogContrast";
            this.hS_LogContrast.Size = new System.Drawing.Size(233, 17);
            this.hS_LogContrast.TabIndex = 0;
            this.hS_LogContrast.ValueChanged += new System.EventHandler(this.hS_LogContrast_ValueChanged);
            // 
            // tB_LogContrast
            // 
            this.tB_LogContrast.Location = new System.Drawing.Point(253, 45);
            this.tB_LogContrast.Name = "tB_LogContrast";
            this.tB_LogContrast.Size = new System.Drawing.Size(28, 20);
            this.tB_LogContrast.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(206, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormLogContrast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 121);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tB_LogContrast);
            this.Controls.Add(this.hS_LogContrast);
            this.Name = "FormLogContrast";
            this.Text = "FormLogContrast";
            this.Load += new System.EventHandler(this.FormLogContrast_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hS_LogContrast;
        public System.Windows.Forms.TextBox tB_LogContrast;
        private System.Windows.Forms.Button button1;
    }
}