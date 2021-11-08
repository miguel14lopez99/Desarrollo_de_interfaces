using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    class Useful
    {

        public static Queue<Officer> initOfficerQueue()
        {
            Queue<Officer> list = new Queue<Officer>();



            for (int i = 0; i < 30; i++)
            {
                Officer officer = createRandomOfficer();
                list.Enqueue(officer);
            }

            return list;
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
                Man man = new Man(officialKey, graduation, name, planet);
                return man;
            }
            else
            {
                Boolean isRomulan;
                num = RandomNumber.random_Number(0, 2);
                if (num != 0)
                    isRomulan = true;
                else
                    isRomulan = false;
                InterfaceBridge.Planet planet = InterfaceBridge.Planet.Vulcan;

                Vulcan vulcan = new Vulcan(officialKey, graduation, name, planet, isRomulan);
                return vulcan;
            }
        }

    }
}
