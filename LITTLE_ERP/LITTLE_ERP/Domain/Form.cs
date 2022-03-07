using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create form objects
    /// </summary>
    class Form
    {
        public int idForm { get; set; }
        public String frmDesc { get; set; }

        public Manage.ProductManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form"/> class.
        /// </summary>
        public Form()
        {
            manage = new Manage.ProductManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form"/> class.
        /// </summary>
        /// <param name="idForm">The form identifier.</param>
        public Form(int idForm)
        {
            manage = new Manage.ProductManage();
            this.idForm = idForm;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form"/> class.
        /// </summary>
        /// <param name="idForm">The form identifier.</param>
        /// <param name="frmDesc">The form description.</param>
        public Form(int idForm, String frmDesc)
        {
            manage = new Manage.ProductManage();
            this.idForm = idForm;
            this.frmDesc = frmDesc;
        }

        /// <summary>
        /// Reads all forms from the database.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAllForms();
        }

    }
}
