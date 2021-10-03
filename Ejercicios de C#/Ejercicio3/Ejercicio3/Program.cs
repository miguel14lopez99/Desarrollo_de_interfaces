using System;

namespace Ejercicio3
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine ("The number is: ");
			int number = Convert.ToInt32(Console.ReadLine());

			int sum = 0;

			int i = 0;
			
			do {
				sum += (i * i);
				i++;
			} while (i <= number) ;

			double avg = (double)sum / (double)number;

			Console.WriteLine ("The sum is: " + sum);
			Console.WriteLine ("The average is: " + avg);

		}
	}
}
