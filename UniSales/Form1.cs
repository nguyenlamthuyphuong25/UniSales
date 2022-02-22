using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniSales.Product;

namespace UniSales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UCProductList uCProductList;
        UCOrderList uCOrderList;
        UCCategoryList uCCategoryList;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void orderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uCProductList == null)
            {
                uCProductList = new UCProductList();
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(uCProductList);
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uCOrderList == null)
            {
                uCOrderList = new UCOrderList();
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(uCOrderList);
        }

        private void categoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uCCategoryList == null)
            {
                uCCategoryList = new UCCategoryList();
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(uCCategoryList);
        }
    }
}
