namespace WXRobot
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
            this.tabPageB = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageC = new System.Windows.Forms.TabPage();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnNotepad = new System.Windows.Forms.Button();
            this.btnPaint = new System.Windows.Forms.Button();
            this.btnShutdownStart = new System.Windows.Forms.Button();
            this.cbShutdownHour = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShutdownCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbShutdownMinute = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShutdownRightNow = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageA.SuspendLayout();
            this.tabPageB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 449);
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
            this.tabControl1.Location = new System.Drawing.Point(30, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 374);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageA
            // 
            this.tabPageA.Controls.Add(this.groupBox1);
            this.tabPageA.Controls.Add(this.btnPaint);
            this.tabPageA.Controls.Add(this.btnNotepad);
            this.tabPageA.Controls.Add(this.btnCalc);
            this.tabPageA.Controls.Add(this.checkBox1);
            this.tabPageA.Location = new System.Drawing.Point(4, 25);
            this.tabPageA.Name = "tabPageA";
            this.tabPageA.Size = new System.Drawing.Size(542, 345);
            this.tabPageA.TabIndex = 2;
            this.tabPageA.Text = "基本功能";
            this.tabPageA.UseVisualStyleBackColor = true;
            // 
            // tabPageB
            // 
            this.tabPageB.Controls.Add(this.button2);
            this.tabPageB.Controls.Add(this.btnEnable);
            this.tabPageB.Controls.Add(this.btnEdit);
            this.tabPageB.Controls.Add(this.btnRemove);
            this.tabPageB.Controls.Add(this.btnAdd);
            this.tabPageB.Controls.Add(this.listView1);
            this.tabPageB.Location = new System.Drawing.Point(4, 25);
            this.tabPageB.Name = "tabPageB";
            this.tabPageB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageB.Size = new System.Drawing.Size(542, 322);
            this.tabPageB.TabIndex = 0;
            this.tabPageB.Text = "周期提醒";
            this.tabPageB.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(433, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(433, 120);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(90, 23);
            this.btnEnable.TabIndex = 11;
            this.btnEnable.Text = "禁/启用";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(433, 90);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(433, 61);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(432, 31);
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
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(19, 31);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(407, 261);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "内容";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "周期";
            this.columnHeader3.Width = 74;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "可用";
            // 
            // tabPageC
            // 
            this.tabPageC.Location = new System.Drawing.Point(4, 25);
            this.tabPageC.Name = "tabPageC";
            this.tabPageC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageC.Size = new System.Drawing.Size(542, 322);
            this.tabPageC.TabIndex = 1;
            this.tabPageC.Text = "开机程序";
            this.tabPageC.UseVisualStyleBackColor = true;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(19, 61);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 2;
            this.btnCalc.Text = "计算器";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnNotepad
            // 
            this.btnNotepad.Location = new System.Drawing.Point(19, 104);
            this.btnNotepad.Name = "btnNotepad";
            this.btnNotepad.Size = new System.Drawing.Size(75, 23);
            this.btnNotepad.TabIndex = 3;
            this.btnNotepad.Text = "记事本";
            this.btnNotepad.UseVisualStyleBackColor = true;
            this.btnNotepad.Click += new System.EventHandler(this.btnNotepad_Click);
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(19, 147);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(75, 23);
            this.btnPaint.TabIndex = 3;
            this.btnPaint.Text = "画图";
            this.btnPaint.UseVisualStyleBackColor = true;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // btnShutdownStart
            // 
            this.btnShutdownStart.Location = new System.Drawing.Point(108, 24);
            this.btnShutdownStart.Name = "btnShutdownStart";
            this.btnShutdownStart.Size = new System.Drawing.Size(80, 23);
            this.btnShutdownStart.TabIndex = 3;
            this.btnShutdownStart.Text = "定时任务";
            this.btnShutdownStart.UseVisualStyleBackColor = true;
            this.btnShutdownStart.Click += new System.EventHandler(this.btnShutdownStart_Click);
            // 
            // cbShutdownHour
            // 
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
            "10"});
            this.cbShutdownHour.Location = new System.Drawing.Point(9, 24);
            this.cbShutdownHour.Name = "cbShutdownHour";
            this.cbShutdownHour.Size = new System.Drawing.Size(49, 23);
            this.cbShutdownHour.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShutdownRightNow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnShutdownCancel);
            this.groupBox1.Controls.Add(this.cbShutdownMinute);
            this.groupBox1.Controls.Add(this.cbShutdownHour);
            this.groupBox1.Controls.Add(this.btnShutdownStart);
            this.groupBox1.Location = new System.Drawing.Point(19, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "关机";
            // 
            // btnShutdownCancel
            // 
            this.btnShutdownCancel.Location = new System.Drawing.Point(108, 53);
            this.btnShutdownCancel.Name = "btnShutdownCancel";
            this.btnShutdownCancel.Size = new System.Drawing.Size(80, 23);
            this.btnShutdownCancel.TabIndex = 6;
            this.btnShutdownCancel.Text = "取消任务";
            this.btnShutdownCancel.UseVisualStyleBackColor = true;
            this.btnShutdownCancel.Click += new System.EventHandler(this.btnShutdownCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "小时";
            // 
            // cbShutdownMinute
            // 
            this.cbShutdownMinute.FormattingEnabled = true;
            this.cbShutdownMinute.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cbShutdownMinute.Location = new System.Drawing.Point(9, 82);
            this.cbShutdownMinute.Name = "cbShutdownMinute";
            this.cbShutdownMinute.Size = new System.Drawing.Size(49, 23);
            this.cbShutdownMinute.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "分";
            // 
            // btnShutdownRightNow
            // 
            this.btnShutdownRightNow.Location = new System.Drawing.Point(108, 82);
            this.btnShutdownRightNow.Name = "btnShutdownRightNow";
            this.btnShutdownRightNow.Size = new System.Drawing.Size(80, 23);
            this.btnShutdownRightNow.TabIndex = 6;
            this.btnShutdownRightNow.Text = "立即关机";
            this.btnShutdownRightNow.UseVisualStyleBackColor = true;
            this.btnShutdownRightNow.Click += new System.EventHandler(this.btnShutdownRightNow_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(612, 498);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageA.ResumeLayout(false);
            this.tabPageA.PerformLayout();
            this.tabPageB.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShutdownCancel;
        private System.Windows.Forms.ComboBox cbShutdownHour;
        private System.Windows.Forms.Button btnShutdownStart;
        private System.Windows.Forms.Button btnShutdownRightNow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbShutdownMinute;
    }
}