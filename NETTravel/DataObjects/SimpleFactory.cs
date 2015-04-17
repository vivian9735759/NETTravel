using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    class SimpleFactory
    {
        public static LeiFeng CreateLeiFeng(string type)
        {
            LeiFeng result = null;
            switch (type)
            {
                case "Volunteer":
                    result = new Volunteer();
                    break;
                case "Undergraduate":
                    result = new Undergraduate();
                    break;
                default:
                    break;
            }
            return result;
        }

        public static void Test()
        {
            LeiFeng studentA = SimpleFactory.CreateLeiFeng("Undergraduate");
            studentA.BuyRice();

            LeiFeng studentB = SimpleFactory.CreateLeiFeng("Undergraduate");
            studentB.Sweep();

            LeiFeng studentC = SimpleFactory.CreateLeiFeng("Undergraduate");
            studentC.Wash();
        }
    }
}
