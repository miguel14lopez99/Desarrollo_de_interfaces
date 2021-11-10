using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    abstract class Officer : InterfaceBridge
    {

        private int officialKey;
        private InterfaceBridge.Graduation graduation;
        private String name;
        private InterfaceBridge.Planet planet;
        private String imgSource;

        protected Officer(int officialKey, InterfaceBridge.Graduation graduation, string name, InterfaceBridge.Planet planet, String imgSource)
        {
            this.officialKey = officialKey;
            this.graduation = graduation;
            this.name = name;
            this.Planet = planet;
            this.ImgSource = imgSource;
        }


        public int OfficialKey { get => officialKey; set => officialKey = value; }
        public string Name { get => name; set => name = value; }
        internal InterfaceBridge.Graduation Graduation { get => graduation; set => graduation = value; }
        internal InterfaceBridge.Planet Planet { get => planet; set => planet = value; }
        public string ImgSource { get => imgSource; set => imgSource = value; }

        public abstract void getGraduation();
        public abstract void changeGraduation();

    }
}
