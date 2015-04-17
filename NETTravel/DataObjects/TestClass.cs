using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    public abstract class ParentClass
    {
        protected string ID;

        public ParentClass(string id) 
        { 
            ID = id;
            GetID();
        }

        public abstract string GetID();
    }

    public class ChildClass : ParentClass
    {
        protected string Name;

        public ChildClass(string id, string name) : base(id) { Name = name; }

        public override string GetID()
        {
            return Name;
        }
    }

    public struct TestStruct
    {
        public string Name;
    }
}
