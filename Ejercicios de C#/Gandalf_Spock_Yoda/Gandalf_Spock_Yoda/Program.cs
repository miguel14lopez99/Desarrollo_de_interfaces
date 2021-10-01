using System;
using System.Threading;

namespace Gandalf_Spock_Yoda
{
    class Program
    {
        static void Main(string[] args)
        {
            int max_time = 30;
            int time = 1;

            do
            {
                if (time % 1 == 0)
                    Console.WriteLine("Every second");

                if (time % 2 == 0)
                    Console.WriteLine("Every 2 seconds");


                Thread.Sleep(1000);
                time += 1;


            } while (time <= max_time);
        }
    }
}
