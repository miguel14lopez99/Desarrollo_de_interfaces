using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    class Man : Officer, InterfaceBridge
    {


        public Man(int officialKey, InterfaceBridge.Graduation graduation, String name, InterfaceBridge.Planet planet, String imgSource)
            : base(officialKey, graduation, name, planet, imgSource)
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
