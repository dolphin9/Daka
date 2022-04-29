namespace Daka
{
    partial class Error
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
            this.text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(76, 21);
            this.text.TabIndex = 0;
            this.text.Text = "label1";
            this.text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 228);
            this.Controls.Add(this.text);
            this.Name = "Error";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label text;
    }
}