using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class PaymentMethod
    {
        public int id { get; set; }
        public String name { get; set; }

        public PaymentMethod()
        {

        }

        public PaymentMethod(int id)
        {
            this.id = id;
        }

        public PaymentMethod(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
