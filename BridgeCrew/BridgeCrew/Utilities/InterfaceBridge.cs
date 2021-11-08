using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCrew
{

    interface InterfaceBridge
    {

        

        enum TypeG
        {
            Combat = 0, Comunication = 1
        }

        enum Planet
        {
            Mercury = 0, Venus = 1, Earth = 2, Mars = 3, Jupiter = 4, Saturn = 5, Uranus = 6, Neptune = 7, Vulcan = 8
        }

        enum Graduation
        {
            Captain = 0, Major = 1, Colonel = 2, General = 3, Major_General = 4, Army_General = 5
        }
    }
}
