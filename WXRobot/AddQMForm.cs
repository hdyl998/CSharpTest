﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClockPackge
{
    public partial class AddQMForm : Form
    {

        public int editIndex=-1;

        public AddQMForm()
        {
            InitializeComponent();


      
        }

        private void AddQMForm_Load(object sender, EventArgs e)
        {
            if (editIndex != -1) {
                var item = DataManager.getInstance().getQuickMenuItems()[editIndex];

         
                textBox1.Text = item.name;
                textBox2.Text = item.action;
   

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0||textBox2.Text.Length==0)
            {
                MessageBox.Show("数据不能为空");
                return;
            }
            QuickMenuItem item;
            if (editIndex == -1)
            {
                item = new QuickMenuItem();
                DataManager.getInstance().getQuickMenuItems().Add(item);
            }
            else {
                item = DataManager.getInstance().getQuickMenuItems()[editIndex];
            }
            item.name = textBox1.Text;
            item.action = textBox2.Text;
     
            this.DialogResult = DialogResult.OK;
            this.Close();
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.runCmd(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Utils.runExe("cmd");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "选择程序或快捷方式";
            dialog.Multiselect = true;
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "All files(*.*)|*.*|可执行程序|*.exe|快捷方式|*.lnk";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                foreach (string str in dialog.FileNames)
                {
                    string name;
                    string path;

                    int indexEnd = str.LastIndexOf(".");
                    int indexStart = str.LastIndexOf("\\");
                    if (indexEnd != -1 && indexStart != -1)
                    {
                        name = str.Substring(indexStart + 1, indexEnd - indexStart - 1);
                    }
                    else
                    {
                        name = str;
                    }

                    path = str;

                    textBox1.Text = name;
                    textBox2.Text = string.Format("\"{0}\"", path);
                }
 
               
            }
        }
    }
}
