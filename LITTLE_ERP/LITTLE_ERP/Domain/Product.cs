using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create Product objects
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
            manage = new Manage.ProductManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="idProduct">The product identifier.</param>
        public Product(int idProduct)
        {
            manage = new Manage.ProductManage();
            this.idProduct = idProduct;
        }

        /// <summary>
        /// Reads all products from the database.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAll();
        }

        /// <summary>
        /// Reads an specific product from the database.
        /// </summary>
        public void ReadProduct()
        {
            manage.ReadProduct(this);
        }

        /// <summary>
        /// Inserts the product in the database.
        /// </summary>
        public void Insert()
        {
            manage.InsertProduct(this);
        }

        /// <summary>
        /// Updates the product data from the database.
        /// </summary>
        public void Update()
        {
            manage.UpdateProduct(this);
        }

        /// <summary>
        /// Deletes the product from the database.
        /// </summary>
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
