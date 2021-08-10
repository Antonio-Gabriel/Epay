using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePay.Entity
{
    public class Product
    {
        public int IdProduct { get; set; }
        public Auth User { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public byte[] ProductImage { get; set; }
        public string Description { get; set; }
        public int ProductCode { get; set; }
    }
}
