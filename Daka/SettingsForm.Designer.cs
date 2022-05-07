namespace Daka
{
    partial class SettingsForm
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chooseFilePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChangeViewDays = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 273);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(162, 135);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 21);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // chooseFilePath
            // 
            this.chooseFilePath.Enabled = false;
            this.chooseFilePath.Location = new System.Drawing.Point(372, 50);
            this.chooseFilePath.Name = "chooseFilePath";
            this.chooseFilePath.Size = new System.Drawing.Size(75, 23);
            this.chooseFilePath.TabIndex = 2;
            this.chooseFilePath.Text = "选择目录";
            this.chooseFilePath.UseVisualStyleBackColor = true;
            this.chooseFilePath.Click += new System.EventHandler(this.chooseFilePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "打卡信息保存位置：";
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Location = new System.Drawing.Point(160, 55);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(53, 12);
            this.FilePathLabel.TabIndex = 4;
            this.FilePathLabel.Text = "filepath";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "天";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "显示打卡天数：";
            // 
            // ChangeViewDays
            // 
            this.ChangeViewDays.Location = new System.Drawing.Point(372, 132);
            this.ChangeViewDays.Name = "ChangeViewDays";
            this.ChangeViewDays.Size = new System.Drawing.Size(75, 23);
            this.ChangeViewDays.TabIndex = 7;
            this.ChangeViewDays.Text = "修改";
            this.ChangeViewDays.UseVisualStyleBackColor = true;
            this.ChangeViewDays.Click += new System.EventHandler(this.ChangeViewDays_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(201, 210);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 8;
            this.resetButton.Text = "恢复默认";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(325, 210);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "确认修改";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 273);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.ChangeViewDays);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseFilePath);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.splitter1);
            this.Name = "SettingsForm";
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseFilePath;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button ChangeViewDays;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}