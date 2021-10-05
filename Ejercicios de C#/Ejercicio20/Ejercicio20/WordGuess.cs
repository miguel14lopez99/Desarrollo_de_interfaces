using System;

namespace Ejercicio20
{
    class WordGuess
    {
        static void Main(string[] args)
        {

            String word = "tonacho";
            String result = createResult(word);
            int cont = 0;
            Boolean isCorrect = false;

            while (!(result.Equals(word)) && !isCorrect)
            {
                Console.WriteLine("Key in one character or your guess word: ");
                String _try = Console.ReadLine();

                if (isLetter(_try))
                {
                    char tryChar = _try[0];

                    result = updateResult(tryChar, word, result);

                    if (result.Equals(word))
                    {
                        Console.WriteLine("Trail " + cont + ": Congratulations!");
                    }
                    else
                    {
                        Console.WriteLine("Trail " + cont + ": " + result);
                    }

                    cont++;
                }
                else
                {
                    if (_try.Equals(word))
                    {
                        isCorrect = true;
                        Console.WriteLine("Trail " + cont + ": Congratulations!");
                    }
                    cont++;
                }
            }   
            
            
                
                //crear el string result de las mismas dimensiones que la palabra   

            // while (!(result equals word)){ primero comprueba en null y pide que introduzca letra o palabra }

                //comprueba si result equals word

                // 

                //metodos isLetter y isWord

                // si isLetter -> //comprueba si la letra esta dentro del string -> si ok la descubre

                // (else)si isWord ->   //comprueba si la palabra equals word

                // 







        }

        static String createResult(String word)
        {
            char[] chars = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                chars[i]= '_';
            }

            string charsStr = new string(chars);

            return charsStr;
        }

        static Boolean isLetter(String _try)
        {
            Boolean isLetter = false;

            if(_try.Length == 1)
            {
                isLetter = true;
            }

            return isLetter;
        }

        static String updateResult(char _try, String word, String result)
        {
            char[] resultChars = result.ToCharArray();

            for (int i = 0; i < word.Length; i++)
            {
                if (_try.Equals(word[i]))
                {
                    resultChars[i] = _try;
                }
            }

            result = new string(resultChars);

            return result;
        }
        
    }
}
