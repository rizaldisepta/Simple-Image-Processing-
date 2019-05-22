namespace ImgProc1
{
    partial class FormLogBrightness
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
            this.hSB_LogBrightness = new System.Windows.Forms.HScrollBar();
            this.tB_LogBrightness = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hSB_LogBrightness
            // 
            this.hSB_LogBrightness.Location = new System.Drawing.Point(9, 43);
            this.hSB_LogBrightness.Maximum = 105;
            this.hSB_LogBrightness.Name = "hSB_LogBrightness";
            this.hSB_LogBrightness.Size = new System.Drawing.Size(233, 17);
            this.hSB_LogBrightness.TabIndex = 0;
            this.hSB_LogBrightness.ValueChanged += new System.EventHandler(this.hSB_LogBrightness_ValueChanged);
            // 
            // tB_LogBrightness
            // 
            this.tB_LogBrightness.Location = new System.Drawing.Point(250, 43);
            this.tB_LogBrightness.Name = "tB_LogBrightness";
            this.tB_LogBrightness.Size = new System.Drawing.Size(27, 20);
            this.tB_LogBrightness.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(202, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormLogBrightness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 120);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tB_LogBrightness);
            this.Controls.Add(this.hSB_LogBrightness);
            this.Name = "FormLogBrightness";
            this.Text = "FormLogBrightness";
            this.Load += new System.EventHandler(this.FormLogBrightness_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hSB_LogBrightness;
        public System.Windows.Forms.TextBox tB_LogBrightness;
        private System.Windows.Forms.Button button1;
    }
}