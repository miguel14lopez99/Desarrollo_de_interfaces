using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio16
{
    class Matrix
    {

        //Methods

        public static int[,] addition(int[,] a, int[,] b)
        {
            int[,] result = new int[a.GetLength(0),a.GetLength(1)];

            if (areSameDimension(a, b)) //if the matrices doesn't have the same dimension the method shows an error, on the other hand the terms are added one by one 
            {

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        result[i,j] = a[i,j] + b[i,j];
                    }
                }

            }
            else
            {
                Console.WriteLine("ERROR: the matrices doesn´t have the same dimension");
            }

            return result;
        }

        public static int[,] subtraction(int[,] a, int[,] b) // this method is nearly the same as in the addiction
        {
            int[,] result = new int[a.GetLength(0), a.GetLength(1)];

            if (areSameDimension(a, b))
            {

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        result[i, j] = a[i, j] - b[i, j];
                    }
                }

            }
            else
            {
                Console.WriteLine("ERROR: the matrices doesn´t have the same dimension");
            }

            return result;
        }

        public static int[,] multiplication(int[,] a, int[,] b) // this method multiply the terms in the right order 
        {
            int[,] result = new int[a.GetLength(0), b.GetLength(1)]; // the result is a matrix formed by the width of the first matrix and the height of the second

            if (canMultiply(a, b))
            {

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < a.GetLength(1); k++)
                        {
                            sum += a[i, k] * b[k, j];
                        }
                        result[i, j] = sum;
                    }
                }

            }
            else
            {
                Console.WriteLine("ERROR: the matrices can't multiply");
            }

            return result;
        }

        public static void print(int[,] res) // this method prints the matrix on console
        {
            Console.WriteLine("Result:\n");
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    Console.Write(res[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }

        private static Boolean areSameDimension(int[,] a, int[,] b) // this method check if the height and width of the matrices match
        {
            Boolean sameDimension = false;

            if (a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1))
            {
                sameDimension = true;
            }

            return sameDimension;
        }

        private static Boolean canMultiply(int[,] a, int[,] b) // check if the height of the first and width of the second, as well as the width of the first and the height of the second match
        {
            Boolean canMultiply = false;

            if (a.GetLength(0) == b.GetLength(1) && a.GetLength(1) == b.GetLength(0))
            {
                canMultiply = true;
            }

            return canMultiply;
        }

        /////////////////////DOUBLE VERSION///////////////////////// this methods are the same as above

        public static double[,] addition(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), a.GetLength(1)];

            if (areSameDimension(a, b))
            {

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        result[i, j] = a[i, j] + b[i, j];
                    }
                }

            }
            else
            {
                Console.WriteLine("ERROR: the matrices doesn´t have the same dimension");
            }

            return result;
        }

        public static double[,] subtraction(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), a.GetLength(1)];

            if (areSameDimension(a, b))
            {

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        result[i, j] = a[i, j] - b[i, j];
                    }
                }

            }
            else
            {
                Console.WriteLine("ERROR: the matrices doesn´t have the same dimension");
            }

            return result;
        }

        public static double[,] multiplication(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), b.GetLength(1)];

            if (canMultiply(a, b))
            {

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        double sum = 0;
                        for (int k = 0; k < a.GetLength(1); k++)
                        {
                            sum += a[i, k] * b[k, j];
                        }
                        result[i, j] = sum;
                    }
                }

            }
            else
            {
                Console.WriteLine("ERROR: the matrices can't multiply");
            }

            return result;
        }

        public static void print(double[,] res)
        {
            Console.WriteLine("Result:\n");
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    Console.Write(res[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }

        private static Boolean areSameDimension(double[,] a, double[,] b)
        {
            Boolean sameDimension = false;

            if (a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1))
            {
                sameDimension = true;
            }

            return sameDimension;
        }

        private static Boolean canMultiply(double[,] a, double[,] b)
        {
            Boolean canMultiply = false;

            if (a.GetLength(0) == b.GetLength(1) && a.GetLength(1) == b.GetLength(0))
            {
                canMultiply = true;
            }

            return canMultiply;
        }


    }
}
