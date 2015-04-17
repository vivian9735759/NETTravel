using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    class UndergraduateFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Undergraduate();
        }
    }
}
