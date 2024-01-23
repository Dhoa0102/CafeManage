using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop
{
    public class Drink
    {
        private int iDDrink;
        public int ID
        {
            get { return iDDrink; }
            set { iDDrink = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
      
        
        public Drink(int idDrink,string name,int price)
        {
            this.ID = idDrink;
            this.Name = name;
            this.Price = price;     
        }
        public Drink(string name)
        {
            this.Name = name;
            object itemID = DataProvider.Instance.ExecuteScalar("select IDdrink from Drink where Name='" + name + "'");
            if (itemID != null)
                ID = int.Parse(itemID.ToString());
            else ID= -1;
            object itemPrice= DataProvider.Instance.ExecuteScalar("select IDdrink from Drink where Name='" + name + "'");
            if(itemPrice!=null)
                price=int.Parse(itemPrice.ToString());
            else price= -1;
        }
        public Drink(DataRow row)
        {
            this.ID=(int)row["ID"];
            this.Name = (string)row["Name"];
            this.Price = (int)row["Price"];
        
        }
    }

         
}
