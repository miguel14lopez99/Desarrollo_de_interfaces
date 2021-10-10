using System;

namespace Ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type a palindrome: ");
            String text = Console.ReadLine();

            if (isPalindrome(text)) // I use the isPalindrome method to know if the text is a palindrome
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
            text = text.Trim().ToLower(); // the spaces are removed and make it lowercase
            Boolean palindrome = true;

            for (int i = text.Length - 1; i >= 0; i--) //the letters are inserted in two characters, one from right to left and the other to the opposite
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
                

                if (!a.Equals(b)) // if all the characters are the same, the text is a palindrome
                {
                    palindrome = false;
                }
            }

            return palindrome;
        }
    }
}
