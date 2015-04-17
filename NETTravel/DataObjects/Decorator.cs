using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    public abstract class Component
    {
        public abstract void Operation();
    }

    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            System.Windows.Forms.MessageBox.Show("Operation");
        }
    }

    public abstract class Decorator : Component
    {
        protected Component component;
        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
                component.Operation();
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        private string addedState;
        public override void Operation()
        {
            base.Operation();
            addedState = "New State";
            System.Windows.Forms.MessageBox.Show("Concrete A");
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            System.Windows.Forms.MessageBox.Show("Concrete B");
        }

        private void AddedBehavior()
        {
            System.Windows.Forms.MessageBox.Show("Behavior");
        }
    }

    public class Person
    {
        public Person() { }

        private string name;
        public Person(string name)
        {
            this.name = name;
        }

        public virtual void Show()
        {
            System.Windows.Forms.MessageBox.Show("Show Person");
        }
    }

    public class Finery : Person
    {
        protected Person component;
        public void Decorate(Person component)
        {
            this.component = component;
        }

        public override void Show()
        {
            if (component != null)
                component.Show();
        }
    }

    public class TShirts : Finery
    {
        public override void Show()
        {
            System.Windows.Forms.MessageBox.Show("TShirts");
            base.Show();
        }
    }

    public class BigTrouser : Finery
    {
        public override void Show()
        {
            System.Windows.Forms.MessageBox.Show("BigTrouser");
            base.Show();
        }
    }

    public class Sneakers : Finery
    {
        public override void Show()
        {
            System.Windows.Forms.MessageBox.Show("Sneakers");
            base.Show();
        }
    }
}
