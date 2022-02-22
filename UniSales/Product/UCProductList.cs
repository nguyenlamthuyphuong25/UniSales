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
    public partial class UCProductList : UserControl
    {
        public UCProductList()
        {
            InitializeComponent();
        }

        private void UCProductList_Load(object sender, EventArgs e)
        {
            ProductRepository productRepository = new ProductRepository();
            var products = productRepository.GetProducts();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = products;
        }
    }
}
