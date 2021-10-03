using System;

namespace Ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type a palindrome: ");
            String text = Console.ReadLine();

            if (isPalindrome(text))
            {
                Console.WriteLine("The text \"" + text + "\" is a palindrome");
            } 
            else
            {
                Console.WriteLine("The text \"" + text + "\" isn't a palindrome");
            }

        }

        static Boolean isPalindrome(String text)
        {
            text = text.Trim().ToLower();
            Boolean palindrome = true;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                char a = ' ', b = ' ';

                if (Char.IsLetter(text[i]))
                {
                    a = text[i];
                }

                if (Char.IsLetter(text[text.Length - (i + 1)]))
                {
                    b = text[text.Length - (i + 1)];
                }
                

                if (!a.Equals(b))
                {
                    palindrome = false;
                }
            }

            return palindrome;
        }
    }
}
