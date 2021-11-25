using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Barcos
{
    class Barco
    {

        public Cell startCell;
        public int length;
        public int direction;
        public Cell[] cells { get; set;}

        public Barco (Cell startCell, int length, int direccion)
        {
            this.startCell = startCell;
            this.length = length;
            this.direction = direction;
            this.cells = calculateCells();

        }

        private Cell[] calculateCells()
        {
            Cell[] cells = new Cell[length];

            for (int i = 0; i < length; i++)
            {
                int x = startCell.posX; //0
                int y = startCell.posY; //0

                switch (direction)
                {
                    //UP
                    case 1:
                        x-=i;
                        break;
                    //DOWN
                    case 2:
                        x+=i;
                        break;
                    //LEFT
                    case 3:
                        y-=i;
                        break;
                    //RIGHT
                    case 4:    // i=2
                        y+=i;  // x=0, y=0
                        break;
                }

                cells[i] = new Cell(x,y); // 0.0 0.1 0.2
            }

            return cells;
        }
             
    }
}
