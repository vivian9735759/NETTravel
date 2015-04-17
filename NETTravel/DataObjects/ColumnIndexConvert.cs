using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    public class ColumnIndexConvert
    {
        public int StringToNumber(string str)
        {
            int r = 0;
            for (int i = 0; i < str.Length; i++)
            {
                r = r * 26 + str[i] - 'A' + 1;
            }

            return r;
        }

        public string NumberToString(int n)
        {
            string result = "";
            while (n != 0)
            {
                if (n % 26 == 0)
                    result = "Z" + result;
                else
                    result = ((char)(n % 26 - 1 + 'A')).ToString() + result;

                if (result[0] == 'Z')
                    n = n / 26 - 1;
                else
                    n /= 26;
            }

            return result;
        }
    }
}
