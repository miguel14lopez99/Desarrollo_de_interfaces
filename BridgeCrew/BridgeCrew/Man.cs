using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    class Man : Officer, InterfaceBridge
    {

        private InterfaceBridge.Planet planet;

        public Man(int officialKey, InterfaceBridge.Graduation graduation, String name, InterfaceBridge.Planet planet)
            : base(officialKey, graduation, name)
        {
            this.planet = planet;
        }
    }
}
