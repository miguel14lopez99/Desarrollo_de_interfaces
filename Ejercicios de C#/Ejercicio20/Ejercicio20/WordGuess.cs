using System;

namespace Ejercicio20
{
    class WordGuess
    {
        static void Main(string[] args)
        {

            String word = "teacher";
            String toLowerWord = word.ToLower();
            String result = createResult(word); // I have changed this variable to lowercase so that any letter can be entered
            int cont = 0;
            Boolean isCorrect = false;

            while (!(result.Equals(toLowerWord)) && !isCorrect)
            {
                Console.WriteLine("Key in one character or your guess word: ");
                String _try = Console.ReadLine().ToLower(); // I have changed this variable to lowercase so that any letter can be insert

                //the program asks you to enter letter or word
                if (isLetter(_try)) // check if the string is a Letter
                {
                    char tryChar = _try[0];

                    result = updateResult(tryChar, toLowerWord, result);

                    if (result.Equals(toLowerWord))
                    {
                        Console.WriteLine("Trail " + cont + ": Congratulations!");
                    }
                    else
                    {
                        Console.WriteLine("Trail " + cont + ": " + result);
                    }

                    cont++;
                }
                else // if the string isn't a letter it's a word
                {
                    if (_try.Equals(toLowerWord))
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

        static String createResult(String word) // this method creates an empty String (with "_") with the same length of the word 
        {
            char[] chars = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                chars[i]= '_';
            }

            string charsStr = new string(chars);

            return charsStr;
        }

        static Boolean isLetter(String _try) // this method checks if the inserted string is only a letter
        {
            Boolean isLetter = false;

            if(_try.Length == 1)
            {
                isLetter = true;
            }

            return isLetter;
        }

        static String updateResult(char _try, String word, String result) // this method updates the result with the succesfull trials
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
