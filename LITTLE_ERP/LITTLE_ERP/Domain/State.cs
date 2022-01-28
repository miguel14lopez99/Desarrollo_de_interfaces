using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class State
    {
        public int id { get; set; }
        public String name { get; set; }

        public Manage.CustomerManage manage { get; set; }

        public State()
        {
            this.manage = new Manage.CustomerManage();
        }

        public State(int idState)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idState;
        }

        public State(int idState, String name)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idState;
            this.name = name;
        }

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
