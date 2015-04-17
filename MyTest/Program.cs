using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace MyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> list = new List<DateTime>();
            list.Add(new DateTime(2014, 1, 1));
            list.Add(new DateTime(2014, 3, 1));
            list.Add(new DateTime(2014, 2, 1));
            list.Sort();

            Console.Write(string.Compare("C", "B"));
            Console.ReadLine();
        }
    }


}
