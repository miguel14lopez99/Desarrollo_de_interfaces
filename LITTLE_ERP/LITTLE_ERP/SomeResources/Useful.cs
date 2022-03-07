using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.SomeResources
{
    class Useful
    {
        private static readonly Random r = new Random();
        private static readonly object syncLock = new object();
        /**
        * Method that extracts of Sample its amount and increases the number of valid samples
        **/
        public int random_Number(int min, int max)
        {

            lock (syncLock)
            {
                return r.Next(min, max + 1);
            }
        }

        /// <summary>
        /// Gets the hash sha256 for encripting the user's password.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }





    }
}
