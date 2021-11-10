using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    class Cell
    {

        private int idSquare;

        private Boolean damaged = false;

        public void destroy()
        {
            this.damaged = true;
        }

    }
}
