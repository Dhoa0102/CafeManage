using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCoffeeShop
{
    public class Manager:Person
    {
        public Manager(int personID, string name, string phoneNumber):base(personID, name, phoneNumber) 
        {
        }
        public Manager(string name):base(name) { }
        public override string PrintDatail()
        {
            return "Person ID:" + PersonID.ToString() + "\nName:" + Name + "\nPhone Numer:" + PhoneNumber + "\nPosition:Manager";
        }
    }
}