using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    class Useful
    {

        public static Queue<Officer> initOfficerQueue()
        {
            Queue<Officer> queue = new Queue<Officer>();

            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Head_of_Atreides, "Paul Atreides", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Paul.jpg"));
            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Head_of_Atreides, "Duke Leto", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Leto.jpg"));
            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.BenneGesserit, "Lady Jessica", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Jessica.jpg"));
            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Head_of_Atreides, "Alia Atreides", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Alia.jpg"));
            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Warrior, "Duncan Idaho", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Duncan.png"));

            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Head_of_Harkonnens, "Vladimir Harkonnen", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Vladimir.jpg"));
            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Warrior, "Feyd-Rautha", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Feyd.jpg"));

            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Emperor, "Shaddam IV", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Shaddam.jpg"));

            queue.Enqueue(new Man(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.BenneGesserit, "Reverend Mother Gaius Helen", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), "imgOfficers/Gaius.jpg"));

            queue.Enqueue(new Vulcan(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Leader_of_Fremen, "Stilgar", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), isRomulan(), "imgOfficers/Stilgar.jpg"));
            queue.Enqueue(new Vulcan(RandomNumber.random_Number(1000, 9999), InterfaceBridge.Graduation.Warrior, "Chani", (InterfaceBridge.Planet)RandomNumber.random_Number(0, 7), isRomulan(), "imgOfficers/Chani.jpg"));

            return queue;
        }

        public static Officer createRandomOfficer()
        {
            String[] names = {"Jeremy Cowan",
                            "Giselle Cooke",
                            "Matilda Vincent",
                            "Axel Eaton",
                            "Camron Montoya",
                            "Graham Maynard",
                            "Miya Patrick",
                            "Aden Griffith",
                            "Nathaniel Figueroa",
                            "Jessica Duncan",
                            "Ellen Hooper",
                            "Ezekiel Kemp",
                            "Izabelle Morgan",
                            "Alio Li",
                            "Hugo Chang",
                            "Makhi Bailey",
                            "Kingston Bullock",
                            "Dakota Nielsen",
                            "Miguel",
                            "Luis"};

            int num = RandomNumber.random_Number(0, 2);

            int officialKey = RandomNumber.random_Number(1000, 9999);
            InterfaceBridge.Graduation graduation = (InterfaceBridge.Graduation)RandomNumber.random_Number(0, 6);
            String name = names[RandomNumber.random_Number(0, names.Length - 1)];

            if (num != 0)
            {
                InterfaceBridge.Planet planet = (InterfaceBridge.Planet)RandomNumber.random_Number(0, 8);
                //Man man = new Man(officialKey, graduation, name, planet);
                //return man;
            }
            else
            {
                Boolean isRomulan;
                num = RandomNumber.random_Number(0, 2);
                if (num != 0)
                    isRomulan = true;
                else
                    isRomulan = false;
                //InterfaceBridge.Planet planet = InterfaceBridge.Planet.Vulcan;

                //Vulcan vulcan = new Vulcan(officialKey, graduation, name, planet, isRomulan);
                //return vulcan;
            }
            return null;
        }

        private static Boolean isRomulan()
        {
            Boolean isRomulan;
            int num = RandomNumber.random_Number(0, 2);
            if (num != 0)
                isRomulan = true;
            else
                isRomulan = false;

            return isRomulan;
        }


    }
}
