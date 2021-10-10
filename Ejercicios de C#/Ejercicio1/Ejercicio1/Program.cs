using System;

namespace Ejercicio1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("The mark is: ");
			int mark = Convert.ToInt32(Console.ReadLine());

			if (mark >= 50) //if the grade is greater than or equal to 50. The program writes PASS
			{
				Console.WriteLine("PASS");
			}
			else // otherwise write FAIL
			{
				Console.WriteLine("FAIL");
			}
		}
	}
}
