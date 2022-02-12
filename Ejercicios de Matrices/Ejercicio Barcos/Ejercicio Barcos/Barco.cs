using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_Barcos
{
    class Barco
    {
        public const int NORTE = 1;
        public const int SUR = 2;
        public const int ESTE = 3;
        public const int OESTE = 4;

        public Celda celdaI { get; set; }

        public int longi { get; set; }
        public int direccion { get; set; }

        public Celda[] celdas { get; set; }

        public Barco(int longi, int dim)
        {
            this.longi = longi;
            this.celdaI = new Celda(RandomNumber.random_Number(0, dim - 1), RandomNumber.random_Number(0, dim - 1));
            this.direccion = RandomNumber.random_Number(1, 4);            

            while (!checkBarco(dim))
            {
                this.celdaI = new Celda(RandomNumber.random_Number(0, dim - 1), RandomNumber.random_Number(0, dim - 1));
                this.direccion = RandomNumber.random_Number(1, 4);
            }

            celdas = new Celda[longi];
            setCeldas();
        }

        private Boolean checkBarco(int dim)
        {
            //si la ultima coord del barco se sale se crea otro
            Boolean barcoOK = true;

            Celda celdaF = null;

            switch (direccion)
            {
                case NORTE:
                    celdaF = new Celda(celdaI.posX - (longi - 1), celdaI.posY);
                    break;
                case SUR:
                    celdaF = new Celda(celdaI.posX + (longi - 1), celdaI.posY);
                    break;
                case ESTE:
                    celdaF = new Celda(celdaI.posX, celdaI.posY + (longi - 1));
                    break;
                case OESTE:
                    celdaF = new Celda(celdaI.posX, celdaI.posY - (longi - 1));
                    break;
            }

            if(celdaF.posX >=  dim || celdaF.posX < 0 || celdaF.posY >= dim || celdaF.posY < 0)
                barcoOK = false;

            return barcoOK;
        }

        private void setCeldas()
        {
            for (int i = 0; i < longi; i++)
            {
                Celda celda = null;
                switch (direccion)
                {
                    case NORTE:
                        celda = new Celda(celdaI.posX - i, celdaI.posY);
                        break;
                    case SUR:
                        celda = new Celda(celdaI.posX + i, celdaI.posY);
                        break;
                    case ESTE:
                        celda = new Celda(celdaI.posX, celdaI.posY + i);
                        break;
                    case OESTE:
                        celda = new Celda(celdaI.posX, celdaI.posY - i);
                        break;
                }

                celdas[i] = celda;
            }

        }

    }
}
