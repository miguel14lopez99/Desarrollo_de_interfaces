using System;

namespace Ejercicio12
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a Hexadecimal string: ");
            String hexNumber = Console.ReadLine();

            if (hexCheck(hexNumber))
            {
                Console.WriteLine("The equivalent decimal number for hexadecimal \"" + hexNumber + "\" is " + hexString_to_decimal(hexNumber));
            }
            else
            {
                Console.WriteLine("Error: Invalid Hexadecimal String \"" + hexNumber + "\"");
            }

        }

        static Boolean hexCheck(String hexNumber)
        {
            Boolean isHexadecimal = true;

            for (int i = 0; i < hexNumber.Length; i++)
            {
                if (Char.IsLetterOrDigit(hexNumber[i]))
                {
                    if (getHexNumber(hexNumber[i]) == -1)
                    {
                        isHexadecimal = false;
                    }
  
                }
                else
                {
                    isHexadecimal = false;
                }
            }

            return isHexadecimal;
        }

        static int getHexNumber(char hexChar)
        {
            char[] characters = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            int number = -1;

            for (int i = 0; i < characters.Length; i++)
            {
                if (hexChar.Equals(characters[i]))
                {
                    number = i+1;
                }
            }


            return number;
        }

        static int hexString_to_decimal(String hexNumber)
        {
            int num = 0;

            int div = 16;

            for (int i = 0; i < hexNumber.Length; i++)
            {

                num += (int)Math.Pow(div, (hexNumber.Length - (i+1))) * getHexNumber(hexNumber[i]);

            }

            return num;
        }
    }
}

