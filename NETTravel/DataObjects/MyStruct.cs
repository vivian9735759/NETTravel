using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    public class MyStruct
    {
        public string ID;
        public string Name { get; set; }
        public int Age;
        public int Number { get; set; }
    }

    public class MyClass
    {
        public string ID;
        public string Name { get; set; }
        public int Age;
        public int Number { get; set; }
    }

    internal struct Point : IComparable
    {
        private int m_x, m_y;

        public Point(int x, int y) { m_x = x; m_y = y; }

        public override string ToString()
        {
            return string.Format("{0} {1}", m_x, m_y);
        }

        public int CompareTo(object obj)
        {
            if (GetType() != obj.GetType())
                throw new ArgumentException("o is not a Point. ");

            return CompareTo((Point)obj);
        }

        public int CompareTo(Point other)
        {
            return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
                - Math.Sqrt(other.m_x * other.m_x + m_y * m_y));
        }
    }
}
