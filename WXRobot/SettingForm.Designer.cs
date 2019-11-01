namespace DigitalClockPackge
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageA = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShutdownCancel = new System.Windows.Forms.Button();
            this.btnShutdownStart = new System.Windows.Forms.Button();
            this.cbShutdownMinute = new System.Windows.Forms.ComboBox();
            this.btnShutdownRightNow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cbShutdownHour = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnPaint = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnRobot = new System.Windows.Forms.Button();
            this.btnStartPath = new System.Windows.Forms.Button();
            this.btnNotepad = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.tabPageB = new System.Windows.Forms.TabPage();
            this.btnRMTest = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageC = new System.Windows.Forms.TabPage();
            this.listViewKJ = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKJEnable = new System.Windows.Forms.Button();
            this.btnKJTest = new System.Windows.Forms.Button();
            this.btnKJRemove = new System.Windows.Forms.Button();
            this.btnKJAdd = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageA.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageB.SuspendLayout();
            this.tabPageC.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "开机自启动";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageA);
            this.tabControl1.Controls.Add(this.tabPageB);
            this.tabControl1.Controls.Add(this.tabPageC);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 484);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageA
            // 
            this.tabPageA.Controls.Add(this.checkBox2);
            this.tabPageA.Controls.Add(this.groupBox1);
            this.tabPageA.Controls.Add(this.btnPaint);
            this.tabPageA.Controls.Add(this.button3);
            this.tabPageA.Controls.Add(this.btnRobot);
            this.tabPageA.Controls.Add(this.btnStartPath);
            this.tabPageA.Controls.Add(this.btnNotepad);
            this.tabPageA.Controls.Add(this.btnCalc);
            this.tabPageA.Controls.Add(this.checkBox1);
            this.tabPageA.Location = new System.Drawing.Point(4, 25);
            this.tabPageA.Name = "tabPageA";
            this.tabPageA.Size = new System.Drawing.Size(668, 455);
            this.tabPageA.TabIndex = 2;
            this.tabPageA.Text = "基本功能";
            this.tabPageA.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(140, 23);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 19);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "启动最小化";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShutdownCancel);
            this.groupBox1.Controls.Add(this.btnShutdownStart);
            this.groupBox1.Controls.Add(this.cbShutdownMinute);
            this.groupBox1.Controls.Add(this.btnShutdownRightNow);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.cbShutdownHour);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(449, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 184);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "关机";
            // 
            // btnShutdownCancel
            // 
            this.btnShutdownCancel.Location = new System.Drawing.Point(114, 80);
            this.btnShutdownCancel.Name = "btnShutdownCancel";
            this.btnShutdownCancel.Size = new System.Drawing.Size(80, 35);
            this.btnShutdownCancel.TabIndex = 6;
            this.btnShutdownCancel.Text = "取消任务";
            this.btnShutdownCancel.UseVisualStyleBackColor = true;
            this.btnShutdownCancel.Click += new System.EventHandler(this.btnShutdownCancel_Click);
            // 
            // btnShutdownStart
            // 
            this.btnShutdownStart.Location = new System.Drawing.Point(114, 27);
            this.btnShutdownStart.Name = "btnShutdownStart";
            this.btnShutdownStart.Size = new System.Drawing.Size(80, 35);
            this.btnShutdownStart.TabIndex = 3;
            this.btnShutdownStart.Text = "开始任务";
            this.btnShutdownStart.UseVisualStyleBackColor = true;
            this.btnShutdownStart.Click += new System.EventHandler(this.btnShutdownStart_Click);
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
            this.cbShutdownMinute.Location = new System.Drawing.Point(11, 136);
            this.cbShutdownMinute.Name = "cbShutdownMinute";
            this.cbShutdownMinute.Size = new System.Drawing.Size(49, 23);
            this.cbShutdownMinute.TabIndex = 4;
            this.cbShutdownMinute.SelectedIndexChanged += new System.EventHandler(this.cbShutdownMinute_SelectedIndexChanged);
            // 
            // btnShutdownRightNow
            // 
            this.btnShutdownRightNow.Location = new System.Drawing.Point(114, 130);
            this.btnShutdownRightNow.Name = "btnShutdownRightNow";
            this.btnShutdownRightNow.Size = new System.Drawing.Size(80, 35);
            this.btnShutdownRightNow.TabIndex = 6;
            this.btnShutdownRightNow.Text = "立即关机";
            this.btnShutdownRightNow.UseVisualStyleBackColor = true;
            this.btnShutdownRightNow.Click += new System.EventHandler(this.btnShutdownRightNow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "分";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 19);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "倒计时";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
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
            this.cbShutdownHour.Location = new System.Drawing.Point(11, 97);
            this.cbShutdownHour.Name = "cbShutdownHour";
            this.cbShutdownHour.Size = new System.Drawing.Size(49, 23);
            this.cbShutdownHour.TabIndex = 4;
            this.cbShutdownHour.SelectedIndexChanged += new System.EventHandler(this.cbShutdownHour_SelectedIndexChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 52);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 19);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "正计时";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(19, 120);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(75, 37);
            this.btnPaint.TabIndex = 3;
            this.btnPaint.Text = "画图";
            this.btnPaint.UseVisualStyleBackColor = true;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 375);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 37);
            this.button3.TabIndex = 3;
            this.button3.Text = "查询天气";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnRobot
            // 
            this.btnRobot.Location = new System.Drawing.Point(19, 314);
            this.btnRobot.Name = "btnRobot";
            this.btnRobot.Size = new System.Drawing.Size(123, 37);
            this.btnRobot.TabIndex = 3;
            this.btnRobot.Text = "企业微信机器人";
            this.btnRobot.UseVisualStyleBackColor = true;
            this.btnRobot.Click += new System.EventHandler(this.btnRobot_Click);
            // 
            // btnStartPath
            // 
            this.btnStartPath.Location = new System.Drawing.Point(19, 247);
            this.btnStartPath.Name = "btnStartPath";
            this.btnStartPath.Size = new System.Drawing.Size(75, 37);
            this.btnStartPath.TabIndex = 3;
            this.btnStartPath.Text = "应用路径";
            this.btnStartPath.UseVisualStyleBackColor = true;
            this.btnStartPath.Click += new System.EventHandler(this.btnStartPath_Click);
            // 
            // btnNotepad
            // 
            this.btnNotepad.Location = new System.Drawing.Point(19, 184);
            this.btnNotepad.Name = "btnNotepad";
            this.btnNotepad.Size = new System.Drawing.Size(75, 37);
            this.btnNotepad.TabIndex = 3;
            this.btnNotepad.Text = "记事本";
            this.btnNotepad.UseVisualStyleBackColor = true;
            this.btnNotepad.Click += new System.EventHandler(this.btnNotepad_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(19, 61);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 37);
            this.btnCalc.TabIndex = 2;
            this.btnCalc.Text = "计算器";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // tabPageB
            // 
            this.tabPageB.Controls.Add(this.btnRMTest);
            this.tabPageB.Controls.Add(this.button2);
            this.tabPageB.Controls.Add(this.btnEnable);
            this.tabPageB.Controls.Add(this.btnEdit);
            this.tabPageB.Controls.Add(this.btnRemove);
            this.tabPageB.Controls.Add(this.btnAdd);
            this.tabPageB.Controls.Add(this.listView1);
            this.tabPageB.Location = new System.Drawing.Point(4, 25);
            this.tabPageB.Name = "tabPageB";
            this.tabPageB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageB.Size = new System.Drawing.Size(668, 455);
            this.tabPageB.TabIndex = 0;
            this.tabPageB.Text = "周期任务";
            this.tabPageB.UseVisualStyleBackColor = true;
            // 
            // btnRMTest
            // 
            this.btnRMTest.Location = new System.Drawing.Point(572, 154);
            this.btnRMTest.Name = "btnRMTest";
            this.btnRMTest.Size = new System.Drawing.Size(90, 23);
            this.btnRMTest.TabIndex = 13;
            this.btnRMTest.Text = "测试";
            this.btnRMTest.UseVisualStyleBackColor = true;
            this.btnRMTest.Click += new System.EventHandler(this.btnRMTest_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(572, 95);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(90, 23);
            this.btnEnable.TabIndex = 11;
            this.btnEnable.Text = "禁/启用";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(572, 65);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(572, 36);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(571, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(559, 443);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "内容";
            this.columnHeader1.Width = 126;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 149;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "周期";
            this.columnHeader3.Width = 140;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 4;
            this.columnHeader8.Text = "类型";
            this.columnHeader8.Width = 86;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "可用";
            this.columnHeader4.Width = 48;
            // 
            // tabPageC
            // 
            this.tabPageC.Controls.Add(this.listViewKJ);
            this.tabPageC.Controls.Add(this.btnKJEnable);
            this.tabPageC.Controls.Add(this.btnKJTest);
            this.tabPageC.Controls.Add(this.btnKJRemove);
            this.tabPageC.Controls.Add(this.btnKJAdd);
            this.tabPageC.Location = new System.Drawing.Point(4, 25);
            this.tabPageC.Name = "tabPageC";
            this.tabPageC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageC.Size = new System.Drawing.Size(668, 455);
            this.tabPageC.TabIndex = 1;
            this.tabPageC.Text = "开机程序";
            this.tabPageC.UseVisualStyleBackColor = true;
            // 
            // listViewKJ
            // 
            this.listViewKJ.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewKJ.FullRowSelect = true;
            this.listViewKJ.HideSelection = false;
            this.listViewKJ.Location = new System.Drawing.Point(6, 6);
            this.listViewKJ.MultiSelect = false;
            this.listViewKJ.Name = "listViewKJ";
            this.listViewKJ.Size = new System.Drawing.Size(560, 443);
            this.listViewKJ.TabIndex = 13;
            this.listViewKJ.UseCompatibleStateImageBehavior = false;
            this.listViewKJ.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "应用名";
            this.columnHeader5.Width = 231;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "路径";
            this.columnHeader6.Width = 237;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "可用";
            this.columnHeader7.Width = 74;
            // 
            // btnKJEnable
            // 
            this.btnKJEnable.Location = new System.Drawing.Point(572, 64);
            this.btnKJEnable.Name = "btnKJEnable";
            this.btnKJEnable.Size = new System.Drawing.Size(90, 23);
            this.btnKJEnable.TabIndex = 12;
            this.btnKJEnable.Text = "禁/启用";
            this.btnKJEnable.UseVisualStyleBackColor = true;
            this.btnKJEnable.Click += new System.EventHandler(this.btnKJEnable_Click);
            // 
            // btnKJTest
            // 
            this.btnKJTest.Location = new System.Drawing.Point(572, 93);
            this.btnKJTest.Name = "btnKJTest";
            this.btnKJTest.Size = new System.Drawing.Size(90, 23);
            this.btnKJTest.TabIndex = 2;
            this.btnKJTest.Text = "测试";
            this.btnKJTest.UseVisualStyleBackColor = true;
            this.btnKJTest.Click += new System.EventHandler(this.btnKJTest_Click);
            // 
            // btnKJRemove
            // 
            this.btnKJRemove.Location = new System.Drawing.Point(572, 35);
            this.btnKJRemove.Name = "btnKJRemove";
            this.btnKJRemove.Size = new System.Drawing.Size(90, 23);
            this.btnKJRemove.TabIndex = 2;
            this.btnKJRemove.Text = "移除";
            this.btnKJRemove.UseVisualStyleBackColor = true;
            this.btnKJRemove.Click += new System.EventHandler(this.btnKJRemove_Click);
            // 
            // btnKJAdd
            // 
            this.btnKJAdd.Location = new System.Drawing.Point(572, 6);
            this.btnKJAdd.Name = "btnKJAdd";
            this.btnKJAdd.Size = new System.Drawing.Size(90, 23);
            this.btnKJAdd.TabIndex = 1;
            this.btnKJAdd.Text = "新增";
            this.btnKJAdd.UseVisualStyleBackColor = true;
            this.btnKJAdd.Click += new System.EventHandler(this.btnKJAdd_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(700, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageA.ResumeLayout(false);
            this.tabPageA.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageB.ResumeLayout(false);
            this.tabPageC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tabPageC;
        private System.Windows.Forms.TabPage tabPageA;
        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.Button btnNotepad;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnKJRemove;
        private System.Windows.Forms.Button btnKJAdd;
        private System.Windows.Forms.Button btnKJTest;
        private System.Windows.Forms.Button btnRMTest;
        private System.Windows.Forms.Button btnKJEnable;
        private System.Windows.Forms.ListView listViewKJ;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnStartPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShutdownCancel;
        private System.Windows.Forms.Button btnShutdownStart;
        private System.Windows.Forms.ComboBox cbShutdownMinute;
        private System.Windows.Forms.Button btnShutdownRightNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cbShutdownHour;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnRobot;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button3;
    }
}