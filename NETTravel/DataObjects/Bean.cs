using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    public class Bean
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime ValueDate { get; set; }
        public bool IsExpired { get; set; }
        public bool IsActive { get; set; }
        public readonly double Rate = 2;

        public Bean(string id, string name, double amount, double rate)
        {
            ID = id;
            Name = name;
            Amount = amount;
            //ValueDate = DateTime.Today;
            IsExpired = false;
            IsActive = false;
            Rate = rate;
        }

        public Bean() { }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Bean))
                return false;

            return this.ID.Equals(((Bean)obj).ID);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
