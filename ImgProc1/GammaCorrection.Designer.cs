namespace ImgProc1
{
    partial class GammaCorrection
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
            this.hSB_GammaCorection = new System.Windows.Forms.HScrollBar();
            this.tB_Gamma = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hSB_GammaCorection
            // 
            this.hSB_GammaCorection.Location = new System.Drawing.Point(9, 27);
            this.hSB_GammaCorection.Maximum = 800;
            this.hSB_GammaCorection.Name = "hSB_GammaCorection";
            this.hSB_GammaCorection.Size = new System.Drawing.Size(226, 17);
            this.hSB_GammaCorection.TabIndex = 0;
            this.hSB_GammaCorection.ValueChanged += new System.EventHandler(this.hSB_GammaCorection_ValueChanged);
            // 
            // tB_Gamma
            // 
            this.tB_Gamma.Location = new System.Drawing.Point(247, 27);
            this.tB_Gamma.Name = "tB_Gamma";
            this.tB_Gamma.Size = new System.Drawing.Size(25, 20);
            this.tB_Gamma.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(197, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GammaCorrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 98);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tB_Gamma);
            this.Controls.Add(this.hSB_GammaCorection);
            this.Name = "GammaCorrection";
            this.Text = "GammaCorrection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hSB_GammaCorection;
        public System.Windows.Forms.TextBox tB_Gamma;
        private System.Windows.Forms.Button button1;
    }
}