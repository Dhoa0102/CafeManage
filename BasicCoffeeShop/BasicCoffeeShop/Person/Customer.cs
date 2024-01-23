using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BasicCoffeeShop
{
    public class Customer:Person
    {
        public Customer(int personID, string name, string phoneNumber) : base(personID, name, phoneNumber)
        {
        }
        public Customer(string name):base(name) { }
        public override string PrintDatail()
        {
            return base.PrintDatail();
        }
    }
}