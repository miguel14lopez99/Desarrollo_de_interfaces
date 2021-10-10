using System;

namespace Ejercicio8
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the radius (m): ");
            double radius = Convert.ToDouble(Console.ReadLine());

            double volume = (4 / 3) * Math.PI * Math.Pow(radius, 3); // I use this methods of the Math class to calculate the volume and area of ​​the sphere
            double area = 4 * Math.PI * Math.Pow(radius, 2);

            Console.WriteLine("The volume is: " + volume +"m3");
            Console.WriteLine("The area is: " + area +"m2");

        }
    }
}
