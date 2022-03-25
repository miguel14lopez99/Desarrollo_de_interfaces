using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Barcos
{
    class Cell
    {

        public int posX { get; set; }
        public int posY { get; set; }
        public Boolean asigned { get; set; }

        public Cell (int posX, int posY) {

            this.posX = posX;
            this.posY = posY;
            this.asigned = false;

        }

    }
}
