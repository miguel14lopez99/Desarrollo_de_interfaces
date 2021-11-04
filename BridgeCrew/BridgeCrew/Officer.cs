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

        protected Officer(int officialKey, InterfaceBridge.Graduation graduation, String name)
        {
            this.officialKey = officialKey;
            this.graduation = graduation;
            this.name = name;
        }

        public int OfficialKey { get => officialKey; set => officialKey = value; }
        public string Name { get => name; set => name = value; }
        internal InterfaceBridge.Graduation Graduation { get => graduation; set => graduation = value; }

        public abstract getGraduation();
        public abstract changeGraduation();
    }
}
