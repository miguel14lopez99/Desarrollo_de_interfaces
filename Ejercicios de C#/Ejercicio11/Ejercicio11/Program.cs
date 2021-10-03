using System;

namespace Ejercicio11
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a Binary string: ");
            String binNumber = Console.ReadLine();

            if (binCheck(binNumber))
            {
                Console.WriteLine("The equivalent decimal number for binary \"" + binNumber + "\" is " + binString_to_decimal(binNumber));
            }
            else
            {
                Console.WriteLine("Error: Invalid Binary String \""+ binNumber + "\"");
            }

        }

        static Boolean binCheck(String binNumber)
        {
            Boolean isBinary = true;

            for (int i = 0; i < binNumber.Length; i++)
            {
                if(!(binNumber[i].Equals('1') || binNumber[i].Equals('0')))
                {
                    isBinary = false;
                }
            }

            return isBinary;
        }

        static int binString_to_decimal(String binNumber)
        {
            int num = Convert.ToInt32(binNumber);

            Console.WriteLine("sol: " + num);

            int decimal_num = 0;
            int _base = 1;
            int rem;

            while (num > 0)
            {
                rem = num % 10; /* divide the binary number by 10 and store the remainder in rem variable. */
                decimal_num = decimal_num + rem * _base;
                num = num / 10; // divide the number with quotient  
                _base = _base * 2;
            }

            return decimal_num;
        }
    }
}
