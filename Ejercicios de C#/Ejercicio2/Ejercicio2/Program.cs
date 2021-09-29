using System;

namespace Ejercicio2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("The number is: ");
			int number = Convert.ToInt32(Console.ReadLine());

			if ((number % 2) == 0)
			{
				Console.WriteLine("Even Number");
			}
			else
			{
				Console.WriteLine("Odd Number");
			}
		}
	}
}
