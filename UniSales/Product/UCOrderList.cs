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
    public partial class UCOrderList : UserControl
    {
        public UCOrderList()
        {
            InitializeComponent();
        }

        private void UCOrderList_Load(object sender, EventArgs e)
        {
            OrderRepository orderRepository = new OrderRepository();
            var orders = orderRepository.GetOrders();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = orders;
        }
    }
}
