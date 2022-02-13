using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Product
    {
        public int idProduct { get; set; }
        public int idForm { get; set; }
        public int idIngredient { get; set; }
        public int amount { get; set; }
        public double price { get; set; }

        public Form form { get; set; }
        public Ingredient ingredient { get; set; }

        public Manage.ProductManage manage { get; set; }

        public Product()
        {
            manage = new Manage.ProductManage();
        }

        public Product(int idProduct)
        {
            manage = new Manage.ProductManage();
            this.idProduct = idProduct;
        }

        public void ReadAll()
        {
            manage.ReadAll();
        }

        public void ReadProduct()
        {
            manage.ReadProduct(this);
        }

        public void Insert()
        {
            manage.InsertProduct(this);
        }

        public void Update()
        {
            manage.UpdateProduct(this);
        }

        public void Delete()
        {
            manage.DeleteProduct(this);
        }

        public override string ToString()
        {
            return form.frmDesc + " " + ingredient.ingDesc;
        }


    }
}
