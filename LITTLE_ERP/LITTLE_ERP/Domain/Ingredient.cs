using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Ingredient
    {
        public int idIngredient { get; set; }
        public String ingDesc { get; set; }

        public Manage.ProductManage manage { get; set; }

        public Ingredient()
        {
            manage = new Manage.ProductManage();
        }

        public Ingredient(int idIngredient)
        {
            manage = new Manage.ProductManage();
            this.idIngredient = idIngredient;
        }

        public Ingredient(int idIngredient, String ingDesc)
        {
            manage = new Manage.ProductManage();
            this.idIngredient = idIngredient;
            this.ingDesc = ingDesc;
        }

        public void ReadAll()
        {
            manage.ReadAllIngredients();
        }

    }
}
