using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    abstract class Officer : InterfaceBridge
    {

        private int officialKey;
        InterfaceBridge.Graduation graduation;
        String name;
        InterfaceBridge.Planet planet;

        protected Officer(int officialKey, InterfaceBridge.Graduation graduation, string name, InterfaceBridge.Planet planet)
        {
            this.officialKey = officialKey;
            this.graduation = graduation;
            this.name = name;
            this.Planet = planet;
        }


        public int OfficialKey { get => officialKey; set => officialKey = value; }
        public string Name { get => name; set => name = value; }
        internal InterfaceBridge.Graduation Graduation { get => graduation; set => graduation = value; }
        internal InterfaceBridge.Planet Planet { get => planet; set => planet = value; }

        public abstract void getGraduation();
        public abstract void changeGraduation();

    }
}
