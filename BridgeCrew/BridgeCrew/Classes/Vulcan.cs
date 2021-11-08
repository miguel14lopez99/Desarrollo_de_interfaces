using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{
    class Vulcan : Officer
    {

        private Boolean isRomulan;

        public Vulcan(int officialKey, InterfaceBridge.Graduation graduation, String name, InterfaceBridge.Planet planet, Boolean isRomulan)
            : base(officialKey, graduation, name, planet)
        {
            this.isRomulan = isRomulan;
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
