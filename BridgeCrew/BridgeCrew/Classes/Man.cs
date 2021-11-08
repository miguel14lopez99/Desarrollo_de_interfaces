using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    class Man : Officer, InterfaceBridge
    {


        public Man(int officialKey, InterfaceBridge.Graduation graduation, String name, InterfaceBridge.Planet planet)
            : base(officialKey, graduation, name, planet)
        {
        }

        public override void getGraduation()
        {
            /*TO DO*/
        }
        public override void changeGraduation()
        {
            /*TO DO*/
        }

    }
}
