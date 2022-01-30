using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    class ProductManage
    {
        public List<Product> list { get; set; }
        public List<Form> listF { get; set; }
        public List<Ingredient> listI { get; set; }

        public ProductManage()
        {
            list = new List<Product>();
            listF = new List<Form>();
            listI = new List<Ingredient>();
        }

        public void ReadAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idProduct FROM products where deleted=0", "products");

            DataTable table = data.Tables["products"];

            Product aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Product(Convert.ToInt32(row["idProduct"]));
                ReadProduct(aux);
                list.Add(aux);
            }
        }

        public void ReadProduct(Product product)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM products where idProduct = " + product.idProduct, "products");

            DataTable table = data.Tables["products"];

            DataRow row = table.Rows[0];
            product.idForm = Convert.ToInt32(row["idForm"]);
            product.idIngredient = Convert.ToInt32(row["idIngredient"]);
            product.price = Convert.ToDouble(row["price"]);

            setFormIngredient(product);
        }

        public void ReadAllForms()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM forms", "forms");

            DataTable table = data.Tables["forms"];

            Form aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Form(Convert.ToInt32(row["idForm"]));
                aux.frmDesc = Convert.ToString(row["frmDesc"]);
                listF.Add(aux);
            }
        }

        public void ReadAllIngredients()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM ingredients", "ingredients");

            DataTable table = data.Tables["ingredients"];

            Ingredient aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Ingredient(Convert.ToInt32(row["idIngredient"]));
                aux.ingDesc = Convert.ToString(row["ingDesc"]);
                listI.Add(aux);
            }
        }

        public void setFormIngredient(Product product)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("select idForm, frmDesc from forms where idForm = " + product.idForm , "forms");

            DataTable table = data.Tables["forms"];
            DataRow row = table.Rows[0];

            product.form = new Form(Convert.ToInt32(row["idForm"]), Convert.ToString(row["frmDesc"]));

            data = Search.getData("select idIngredient, ingDesc from ingredients where idIngredient = " + product.idIngredient, "ingredients");

            table = data.Tables["ingredients"];
            row = table.Rows[0];

            product.ingredient = new Ingredient(Convert.ToInt32(row["idIngredient"]), Convert.ToString(row["ingDesc"]));

        }

        public void InsertProduct(Product product)
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idProduct)", "products", "")) + 1;

            product.idProduct = maximun;

            setFormIngredient(product);

            Search.setData("Insert into products(idProduct, idForm, idIngredient, price, deleted)" +
                " values (" + product.idProduct + ", " + product.idForm + ", " + product.idIngredient + ", " + product.price + ", 0)");

        }

        public void UpdateProduct(Product product)
        {
            ConnectOracle Search = new ConnectOracle();

            setFormIngredient(product);

            Search.setData("Update products set idForm = " + product.idForm + ", idIngredient = " + product.idIngredient + ", price = " + product.price +
                " where idProduct = " + product.idProduct);
        }

        public void DeleteProduct(Product product)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Delete from products where idProduct = " + product.idProduct);
        }
    }
}
