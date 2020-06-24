namespace DigitalClockPackge
{
    partial class AddRemindForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnComplete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxExtra = new System.Windows.Forms.TextBox();
            this.panelOpenExe = new System.Windows.Forms.Panel();
            this.btnChoose = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.panelSendMsg = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonRobotSel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelShowTime = new System.Windows.Forms.Label();
            this.panelOpenExe.SuspendLayout();
            this.panelSendMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "主题";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
            this.textBox1.TabIndex = 1;
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(166, 349);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(2);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(127, 33);
            this.btnComplete.TabIndex = 4;
            this.btnComplete.Text = "完成";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "类别";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(42, 49);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(125, 20);
            this.comboBoxType.TabIndex = 2;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "程序";
            // 
            // textBoxExtra
            // 
            this.textBoxExtra.Location = new System.Drawing.Point(40, 15);
            this.textBoxExtra.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxExtra.Name = "textBoxExtra";
            this.textBoxExtra.Size = new System.Drawing.Size(341, 21);
            this.textBoxExtra.TabIndex = 1;
            // 
            // panelOpenExe
            // 
            this.panelOpenExe.Controls.Add(this.btnChoose);
            this.panelOpenExe.Controls.Add(this.textBoxExtra);
            this.panelOpenExe.Controls.Add(this.label5);
            this.panelOpenExe.Location = new System.Drawing.Point(1, 210);
            this.panelOpenExe.Margin = new System.Windows.Forms.Padding(2);
            this.panelOpenExe.Name = "panelOpenExe";
            this.panelOpenExe.Size = new System.Drawing.Size(459, 46);
            this.panelOpenExe.TabIndex = 5;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(394, 15);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(56, 20);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "选择";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(67, 183);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(41, 12);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "label6";
            // 
            // panelSendMsg
            // 
            this.panelSendMsg.Controls.Add(this.textBox3);
            this.panelSendMsg.Controls.Add(this.textBox2);
            this.panelSendMsg.Controls.Add(this.buttonRobotSel);
            this.panelSendMsg.Controls.Add(this.label7);
            this.panelSendMsg.Controls.Add(this.label6);
            this.panelSendMsg.Location = new System.Drawing.Point(1, 260);
            this.panelSendMsg.Margin = new System.Windows.Forms.Padding(2);
            this.panelSendMsg.Name = "panelSendMsg";
            this.panelSendMsg.Size = new System.Drawing.Size(459, 80);
            this.panelSendMsg.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(64, 43);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(317, 21);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 11);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(317, 21);
            this.textBox2.TabIndex = 3;
            // 
            // buttonRobotSel
            // 
            this.buttonRobotSel.Location = new System.Drawing.Point(394, 26);
            this.buttonRobotSel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRobotSel.Name = "buttonRobotSel";
            this.buttonRobotSel.Size = new System.Drawing.Size(56, 20);
            this.buttonRobotSel.TabIndex = 2;
            this.buttonRobotSel.Text = "选择";
            this.buttonRobotSel.UseVisualStyleBackColor = true;
            this.buttonRobotSel.Click += new System.EventHandler(this.buttonRobotSel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 46);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "发送内容";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Hook地址";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "时间";
            // 
            // labelShowTime
            // 
            this.labelShowTime.AutoSize = true;
            this.labelShowTime.Location = new System.Drawing.Point(43, 88);
            this.labelShowTime.Name = "labelShowTime";
            this.labelShowTime.Size = new System.Drawing.Size(17, 12);
            this.labelShowTime.TabIndex = 10;
            this.labelShowTime.Text = "--";
            // 
            // AddRemindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 391);
            this.Controls.Add(this.labelShowTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelSendMsg);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.panelOpenExe);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRemindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增周期任务";
            this.Load += new System.EventHandler(this.RemindNewForm_Load);
            this.panelOpenExe.ResumeLayout(false);
            this.panelOpenExe.PerformLayout();
            this.panelSendMsg.ResumeLayout(false);
            this.panelSendMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxExtra;
        private System.Windows.Forms.Panel panelOpenExe;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Panel panelSendMsg;
        private System.Windows.Forms.Button buttonRobotSel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelShowTime;
    }
}