using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    public class MyEnum
    {
        public enum Actions
        {
            Read,
            Write,
            ReadOnly,
            Protected
        }

        public static void Test()
        {
            Actions at = (Actions)Enum.Parse(typeof(Actions), "protected", true);
            System.Windows.Forms.MessageBox.Show(at.ToString());
        }
    }
}
