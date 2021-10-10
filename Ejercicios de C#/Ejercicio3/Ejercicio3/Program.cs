using System;

namespace Ejercicio3
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine ("Type the number: ");
			int number = Convert.ToInt32(Console.ReadLine());

			int sum = 0;

			int i = 0;
			
			do {
				sum += (i * i);
				i++;
			} while (i <= number); // using a do while loop. The program adds all the numbers from 0 to the inserted number

			double avg = (double)sum / (double)number; // also casting the variables to doubles is able to calculate the average

			Console.WriteLine ("The sum is: " + sum);
			Console.WriteLine ("The average is: " + avg);

		}
	}
}
