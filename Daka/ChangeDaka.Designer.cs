namespace Daka
{
    partial class ChangeDaka
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
            this.label4 = new System.Windows.Forms.Label();
            this.remainDays = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.itemName = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.DeletButton = new System.Windows.Forms.Button();
            this.totalDays = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "到：";
            // 
            // remainDays
            // 
            this.remainDays.Location = new System.Drawing.Point(92, 94);
            this.remainDays.Name = "remainDays";
            this.remainDays.Size = new System.Drawing.Size(62, 21);
            this.remainDays.TabIndex = 14;
            this.remainDays.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "天";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "还要坚持";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(92, 151);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // itemName
            // 
            this.itemName.Location = new System.Drawing.Point(92, 36);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(193, 21);
            this.itemName.TabIndex = 10;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(235, 220);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 9;
            this.ConfirmButton.Text = "确认";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "打卡项目：";
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(154, 220);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(75, 23);
            this.ChangeButton.TabIndex = 16;
            this.ChangeButton.Text = "修改";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // DeletButton
            // 
            this.DeletButton.Location = new System.Drawing.Point(23, 220);
            this.DeletButton.Name = "DeletButton";
            this.DeletButton.Size = new System.Drawing.Size(75, 23);
            this.DeletButton.TabIndex = 17;
            this.DeletButton.Text = "删除";
            this.DeletButton.UseVisualStyleBackColor = true;
            this.DeletButton.Click += new System.EventHandler(this.DeletButton_Click);
            // 
            // totalDays
            // 
            this.totalDays.AutoSize = true;
            this.totalDays.Location = new System.Drawing.Point(167, 101);
            this.totalDays.Name = "totalDays";
            this.totalDays.Size = new System.Drawing.Size(77, 12);
            this.totalDays.TabIndex = 18;
            this.totalDays.Text = "/ totalDays ";
            // 
            // ChangeDaka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 273);
            this.Controls.Add(this.totalDays);
            this.Controls.Add(this.DeletButton);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.remainDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.label1);
            this.itemId = "ChangeDaka";
            this.Text = "修改信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox remainDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button DeletButton;
        private System.Windows.Forms.Label totalDays;
    }
}