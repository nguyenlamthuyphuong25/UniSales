using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSales.Repository.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public int Status { get; set; }
    }
}
