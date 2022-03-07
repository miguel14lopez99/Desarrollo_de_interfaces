using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create ingredient objects
    /// </summary>
    class Ingredient
    {
        public int idIngredient { get; set; }
        public String ingDesc { get; set; }

        public Manage.ProductManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        public Ingredient()
        {
            manage = new Manage.ProductManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        /// <param name="idIngredient">The ingredient identifier.</param>
        public Ingredient(int idIngredient)
        {
            manage = new Manage.ProductManage();
            this.idIngredient = idIngredient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        /// <param name="idIngredient">The ingredient identifier.</param>
        /// <param name="ingDesc">The ingredient description.</param>
        public Ingredient(int idIngredient, String ingDesc)
        {
            manage = new Manage.ProductManage();
            this.idIngredient = idIngredient;
            this.ingDesc = ingDesc;
        }

        /// <summary>
        /// Reads all Ingredients from de database.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAllIngredients();
        }

    }
}
