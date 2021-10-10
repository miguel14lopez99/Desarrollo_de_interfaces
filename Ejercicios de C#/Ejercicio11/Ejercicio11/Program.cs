using System;

namespace Ejercicio11
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a Binary string: ");
            String binNumber = Console.ReadLine(); // this variable represent the binary number

            if (binCheck(binNumber)) // check if the number is made up of zeros or ones
            {
                Console.WriteLine("The equivalent decimal number for binary \"" + binNumber + "\" is " + binString_to_decimal(binNumber));
            }
            else // if the number isn't binnary the program prints an error
            {
                Console.WriteLine("Error: Invalid Binary String \""+ binNumber + "\"");
            }

        }

        static Boolean binCheck(String binNumber)
        {
            Boolean isBinary = true;

            for (int i = 0; i < binNumber.Length; i++) //goes through the string checking that it is made up of zeros or ones
            {
                if(!(binNumber[i].Equals('1') || binNumber[i].Equals('0')))
                {
                    isBinary = false;
                }
            }

            return isBinary; // it returns if the string is a binary number or not
        }

        static int binString_to_decimal(String binNumber)
        {
            int num = Convert.ToInt32(binNumber); // it transform the binary string into integers

            Console.WriteLine("sol: " + num);

            int decimal_num = 0;
            int _base = 1;
            int rem;

            while (num > 0)
            {
                rem = num % 10; // divide the binary number by 10 and store the remainder in rem variable. 
                decimal_num = decimal_num + rem * _base; // adds the decimal value to the reminder value by the base and it's stored into decimal number variable
                num = num / 10; // divide the number by 10, and repeat the proccess
                _base = _base * 2;
            }

            return decimal_num;
        }
    }
}
