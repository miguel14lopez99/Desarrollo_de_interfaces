using System;

namespace ejemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int year = cientificDate / 10000;
            int month_day = cientificDate % 10000;
            int month = month_day / 100;
            int day = month_day % 100;

            DateTime date = new DateTime(year, month, day);
        }
    }
}
