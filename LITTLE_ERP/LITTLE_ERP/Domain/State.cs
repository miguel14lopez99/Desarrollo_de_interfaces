using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create State objects
    /// </summary>
    class State
    {
        public int id { get; set; }
        public String name { get; set; }

        public Manage.CustomerManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State()
        {
            this.manage = new Manage.CustomerManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        /// <param name="idState">The state identifier.</param>
        public State(int idState)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        /// <param name="idState">The state identifier.</param>
        /// <param name="name">The state name.</param>
        public State(int idState, String name)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idState;
            this.name = name;
        }

        /// <summary>
        /// Reads all states from a determined region.
        /// </summary>
        /// <param name="region">The region.</param>
        public void ReadAll(Region region)
        {
            manage.ReadAllStates(region);
        }

        public override bool Equals(object obj)
        {
            return obj is State state &&
                   id == state.id;
        }

    }
}
