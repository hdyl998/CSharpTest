namespace WXRobot
{
    partial class AddGuanjiForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbShutdownMinute = new System.Windows.Forms.ComboBox();
            this.cbShutdownHour = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "分";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbShutdownMinute
            // 
            this.cbShutdownMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShutdownMinute.FormattingEnabled = true;
            this.cbShutdownMinute.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cbShutdownMinute.Location = new System.Drawing.Point(28, 77);
            this.cbShutdownMinute.Name = "cbShutdownMinute";
            this.cbShutdownMinute.Size = new System.Drawing.Size(49, 23);
            this.cbShutdownMinute.TabIndex = 7;
            // 
            // cbShutdownHour
            // 
            this.cbShutdownHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShutdownHour.FormattingEnabled = true;
            this.cbShutdownHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbShutdownHour.Location = new System.Drawing.Point(28, 37);
            this.cbShutdownHour.Name = "cbShutdownHour";
            this.cbShutdownHour.Size = new System.Drawing.Size(49, 23);
            this.cbShutdownHour.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 41);
            this.button1.TabIndex = 11;
            this.button1.Text = "完成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddGuanjiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 188);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbShutdownMinute);
            this.Controls.Add(this.cbShutdownHour);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddGuanjiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加关机计划";
            this.Load += new System.EventHandler(this.AddGuanjiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbShutdownMinute;
        private System.Windows.Forms.ComboBox cbShutdownHour;
        private System.Windows.Forms.Button button1;
    }
}