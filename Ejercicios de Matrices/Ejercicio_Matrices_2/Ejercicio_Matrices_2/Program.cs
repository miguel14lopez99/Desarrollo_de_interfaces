using System;

namespace Ejercicio_Matrices_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //nombres de los operarios guardados en un array
            int n_operarios = 4;
            String[] operarios = new String[4]; 
            for (int k = 0; k < n_operarios; k++)
            {
                Console.WriteLine("Introduzca el nombre del operario " + (k+1) + ": ");
                operarios[k] = Console.ReadLine();
            }

            Console.WriteLine("\nIntroduzca los ingresos de cada operario.\n");

            //ingresos de cada persona en una matriz
            int meses = 3;
            double[,] ingresos = new double[operarios.Length, meses];
            int i = 0, j = 0;
            while (i < ingresos.GetLength(0))
            {
                Console.WriteLine(operarios[i] + " - mes " + (j+1) + ": ");
                ingresos[i, j] = Convert.ToDouble(Console.ReadLine());

                if (j == ingresos.GetLength(1) - 1)
                {
                    Console.WriteLine();
                    i++;
                    j = 0;
                } else
                {
                    j++;
                }

            }

            Console.WriteLine("\nIngresos totales.\n");

            //ingresos totales de cada operario en un vector
            double[] ingresos_totales = new double[n_operarios];
            i = 0; j = 0; 
            double suma = 0;
            while (i < ingresos.GetLength(0))
            {
                suma += ingresos[i, j];

                if (j == ingresos.GetLength(1) - 1)
                {
                    ingresos_totales[i] = suma;
                    Console.WriteLine(operarios[i] + " - " + ingresos_totales[i]);
                    suma = 0;
                    i++;
                    j = 0;
                }
                else
                {
                    j++;
                }

            }

            //nombre del operario con mas ingresos
            double max_ingresos = 0;
            int pos = -1;

            for (int l = 0; l < ingresos_totales.Length; l++)
            {
                if (ingresos_totales[l] > max_ingresos)
                {
                    max_ingresos = ingresos_totales[l];
                    pos = l;
                }
            }

            Console.WriteLine("\nEl empleado con más ingresos es: " + operarios[pos] + " con " + ingresos_totales[pos]);

        }
    }
}
