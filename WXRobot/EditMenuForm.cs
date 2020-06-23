using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClockPackge
{
    //https://blog.csdn.net/imxiangzi/article/details/81200517
    public partial class EditMenuForm : Form
    {



        public EditMenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(txtNodeName.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) {
                MessageBox.Show("请选择要添加子节点的节点！");
                return;
            }
            treeView1.SelectedNode.Nodes.Add(txtNodeName.Text.Trim());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择要添加子节点的节点！");
                return;
            }
            treeView1.SelectedNode.Remove();
        }

        private void EditMenuForm_Load(object sender, EventArgs e)
        {

        }
        //最大深度
        const int MAX_LEVEL = 2;


        private void button4_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择要添加子节点的节点！");
                return;
            }
            MessageBox.Show(treeView1.SelectedNode.Level+"");
        }
    }
}
