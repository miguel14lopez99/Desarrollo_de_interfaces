using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_Barcos2
{
    class Celda
    {
        public int posX { get; set; }
        public int posY { get; set; }

        public Celda(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
    }
}
