using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BasicCoffeeShop
{
    public class Barista:Person
    {
        public Barista(int personID, string name, string phoneNumber) : base(personID, name, phoneNumber)
        { }
        public Barista(string name):base(name) { }
        public override string PrintDatail()
        {
            return "Person ID:" + PersonID.ToString() + "\nName:" + Name + "\nPhone Numer:" + PhoneNumber+"\nPosition:Barista";
        }
    }
}