using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class OrderProducts
    {
        public Int64 idOrder { get; set; }
        public int idProduct { get; set; }
        public String description { get; set; }
        public Double pricesale { get; set; }
        public int amount { get; set; }

        public OrderProducts()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is OrderProducts products &&
                   idOrder == products.idOrder &&
                   idProduct == products.idProduct;
        }
    }
}
