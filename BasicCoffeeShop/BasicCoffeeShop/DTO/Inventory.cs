using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop
{
    public class Inventory
    {
        private int iD;
        private string name;
        private int amount;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string Name
        { get { return name; } set {  name = value; } }
        public int Amount
        { get { return amount; } set {  amount = value; } }
        public Inventory(int iD, string name, int amount)
        {
            this.ID = iD;
            this.Name = name;
            this.Amount = amount;
        }
        public Inventory(string name)
        {
            this.Name=name;
            object idItem = DataProvider.Instance.ExecuteScalar("select IDdrink from Inventory where Name='" + name + "'");
            if(idItem != null)
                ID=int.Parse(idItem.ToString());
            else
                ID=-1;
            object AmountItem = DataProvider.Instance.ExecuteScalar("select Amount from Inventory where Name='" + name + "'");
            if(AmountItem != null)
                amount = int.Parse(AmountItem.ToString());
            else
                amount= 0;
        }
        public Inventory(DataRow row) 
        {
            this.ID = (int)row["ID"];
            this.Name = (string)row["Name"];
            this.Amount = (int)row["Amount"];
        }
    }
}
