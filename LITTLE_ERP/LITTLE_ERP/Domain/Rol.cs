using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create Rol objects
    /// </summary>
    class Rol
    {
        public int idRol { get; set; }
        public String description { get; set; }

        public Manage.RolManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rol"/> class.
        /// </summary>
        public Rol()
        {
            manage = new Manage.RolManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rol"/> class.
        /// </summary>
        /// <param name="idRol">The rol identifier.</param>
        public Rol(int idRol)
        {
            manage = new Manage.RolManage();
            this.idRol = idRol;
        }

        /// <summary>
        /// Reads all roles from the database.
        /// </summary>
        public void readAll()
        {
            manage.ReadAll();
        }

        /// <summary>
        /// Reads a specific rol from the database.
        /// </summary>
        public void readRol()
        {
            manage.ReadRol(this);
        }

        public override string ToString()
        {
            return description;
        }

        public override bool Equals(object obj)
        {
            return obj is Rol rol &&
                   idRol == rol.idRol &&
                   description == rol.description;
        }
    }

    
}
