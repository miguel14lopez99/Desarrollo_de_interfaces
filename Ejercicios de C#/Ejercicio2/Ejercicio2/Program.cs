using System;

namespace Ejercicio2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Type the number : ");
			int number = Convert.ToInt32(Console.ReadLine());

			if ((number % 2) == 0) // if the mod of 2 is equal to 0. The program writes "Even Number"
			{
				Console.WriteLine("Even Number");
			}
			else // otherwise. The program writes "Odd Number"
			{
				Console.WriteLine("Odd Number");
			}
		}
	}
}
