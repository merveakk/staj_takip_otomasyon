﻿namespace staj_takip
{
    partial class cv_pdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cv_pdf));
            this.axAcroPDF2 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF2)).BeginInit();
            this.SuspendLayout();
            // 
            // axAcroPDF2
            // 
            this.axAcroPDF2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF2.Enabled = true;
            this.axAcroPDF2.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF2.Name = "axAcroPDF2";
            this.axAcroPDF2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF2.OcxState")));
            this.axAcroPDF2.Size = new System.Drawing.Size(800, 450);
            this.axAcroPDF2.TabIndex = 0;
            // 
            // cv_pdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axAcroPDF2);
            this.Name = "cv_pdf";
            this.Text = "cv_pdf";
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF2;
    }
}