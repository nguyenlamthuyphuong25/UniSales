using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniSales.Repository;

namespace UniSales.Product
{
    public partial class UCCategoryList : UserControl
    {
        public UCCategoryList()
        {
            InitializeComponent();
        }

        private void UCCategoryList_Load(object sender, EventArgs e)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var cates = categoryRepository.GetCategory();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = cates;
        }
    }
}
