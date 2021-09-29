using System;

namespace Ejercicio1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("The mark is: ");
			int mark = Convert.ToInt32(Console.ReadLine());

			if (mark >= 50)
			{
				Console.WriteLine("PASS");
			}
			else
			{
				Console.WriteLine("FAIL");
			}
		}
	}
}
