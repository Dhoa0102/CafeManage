using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCoffeeShop
{
    public abstract class Person
    {
        private string name;
        private int personID;
        private string phoneNumber;
        public string Name
        { 
            get { return name; }
            set { name = value; }
        }
        public string PhoneNumber
        { 
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public int PersonID
        {
            get { return personID; }
            set { personID = value; }
        }
        public Person (int personID,string name,string phoneNumber)
        {
            this.personID = personID;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }
        public Person(string name)
        { this.name = name; }
        public virtual string PrintDatail()
        {
            return "Person ID:" + personID.ToString() + "\nName:" + Name + "\nPhone Numer:" + PhoneNumber;
        }

    }
}