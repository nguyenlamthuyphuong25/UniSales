using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSales.Repository.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public String Description { get; set; }
        public int Status { get; set; }
        public int CatId { get; set; }
    }
}
