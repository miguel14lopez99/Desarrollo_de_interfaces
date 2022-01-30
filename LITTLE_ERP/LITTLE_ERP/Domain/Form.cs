using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Form
    {
        public int idForm { get; set; }
        public String frmDesc { get; set; }

        public Manage.ProductManage manage { get; set; }

        public Form()
        {
            manage = new Manage.ProductManage();
        }

        public Form(int idForm)
        {
            manage = new Manage.ProductManage();
            this.idForm = idForm;
        }

        public Form(int idForm, String frmDesc)
        {
            manage = new Manage.ProductManage();
            this.idForm = idForm;
            this.frmDesc = frmDesc;
        }

        public void ReadAll()
        {
            manage.ReadAllForms();
        }

    }
}
