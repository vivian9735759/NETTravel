using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    public class ReflectClass<T> where T : class
    {
        private T _pam;
        public ReflectClass(T pam) { _pam = pam; }

        public bool GetProperties(ref string messages)
        {
            bool success = true;

            // Get All the Public and Instance Properties
            System.Reflection.PropertyInfo[] properties = _pam.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            foreach (var item in properties)
            {
                // Validate ValueType
                if (item.PropertyType.IsValueType)
                {
                    // Validate PropertyType: double and double?
                    if (item.PropertyType.Equals(typeof(double)) || item.PropertyType.Equals(typeof(double?)))
                    {
                        // Get Property Value
                        double dblTemp = Convert.ToDouble(item.GetValue(_pam, null));
                        if (double.IsNegativeInfinity(dblTemp) || double.IsPositiveInfinity(dblTemp) || double.IsNaN(dblTemp))
                        {
                            success = false;

                            // Set Property Value
                            item.SetValue(_pam, 0d, null);

                            if (double.IsNegativeInfinity(dblTemp))
                            {
                                messages += string.Format("{0} is Negative Infinity\n", item.Name);
                            }
                            else if (double.IsPositiveInfinity(dblTemp))
                            {
                                messages += string.Format("{0} is Positive Infinity\n", item.Name);
                            }
                            else if (double.IsNaN(dblTemp))
                            {
                                messages += string.Format("{0} is NaN\n", item.Name);
                            }
                        }
                    }
                }
            }

            return success;
        }
    }
}
