using System;

namespace Ejercicio14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a Hexadecimal string: ");
            String hexNumber = Console.ReadLine().ToLower();

            if (hexCheck(hexNumber))
            {
                Console.WriteLine("The equivalent decimal number for hexadecimal \"" + hexNumber + "\" is " + hexToBin(hexNumber));
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

            char[] characters = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            int number = -1;

            for (int i = 0; i < characters.Length; i++)
            {
                if (hexChar.Equals(characters[i]))
                {
                    number = i + 1;
                }
            }

            return number;
        }

        static String hexToBin(String hexNumber)
        {

            char[] hex =   {'0',    '1',    '2',    '3',    '4',    '5',    '6',    '7',    '8',    '9',    'a',    'b',    'c',    'd',    'e',    'f' };
            String[] bin = {"0000 ", "0001 ", "0010 ", "0011 ", "0100 ", "0101 ", "0110 ", "0111 ", "1000 ", "1001 ", "1010 ", "1011 ", "1100 ", "1101 ", "1110 ", "1111 " };
            String[] sol = new String[hexNumber.Length];

            for (int i = 0; i < hexNumber.Length; i++)
            {
                for (int j = 0; j < hex.Length; j++)
                {
                    if (hexNumber[i].Equals(hex[j]))
                    {
                        sol[i] = bin[j];
                        
                    }
                }
            }

            String result = String.Concat(sol);

            return result;
        }
    }
}
