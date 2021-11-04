using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    class Vulcan : Officer
    {

        private Boolean isRomulan;

        public Vulcan(int officialKey, InterfaceBridge.Graduation graduation, String name, Boolean isRomulan)
            : base(officialKey, graduation, name)
        {
            this.isRomulan = isRomulan;
        }

    }
}
