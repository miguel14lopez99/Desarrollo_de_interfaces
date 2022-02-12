using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Barcos
{
    class RandomNumber
    {
        private static readonly Random r = new Random();
        private static readonly object syncLock = new object();
        /**
       * Method that extracts of Sample its amount and increases the number of valid samples
       **/
        public static int random_Number(int min, int max)
        {

            lock (syncLock)
            {
                return r.Next(min, max+1);
            }
        }

    }
}
