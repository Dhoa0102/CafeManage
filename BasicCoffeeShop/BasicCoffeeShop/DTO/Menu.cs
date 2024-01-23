using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop
{
    public class Menu
    {
        private string drinkName;
        private int drinkCount;
  
        private int price;
        private int totalPrice;
  

         public string DrinkName
        {
            get { return drinkName; }       
            set { drinkName = value; }  
        }
        public int DrinkCount
        {
            get { return drinkCount; }          
            set
            {
                drinkCount = value;     
            }
        }
      
        public int Price
        {
            get
            {
                return price;       
            }
            set
            {
                price = value;      
            }
        }
        public int TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;     
            }
        }
        private string customerName;
        public string CustomerName
        {
            get { return customerName; }        
            set
            {
                customerName = value;           
            }
        }
       
       
        /*public Menu(string drinkName,int count,int price,int totalPrice=0,string nameBarista,int payment)
        {
            this.DrinkName = drinkName ;
            this.Price = price;
            this.DrinkCount= count;
            this.TotalPrice = totalPrice;
            this.NameBarista = nameBarista;
            this.PayMent = payment;
        }*/
        public Menu(string drinkName,int drinkCount,int price,int totalPrice,string customerName)
        {
            this.DrinkName = drinkName;     
            this.DrinkCount = drinkCount;
            this.Price = price;
            this.TotalPrice=totalPrice;
            this.CustomerName=customerName; 
     
        }
        public Menu(DataRow row)
        {
            this.DrinkName = row["Name"].ToString();
            this.Price = (int)row["Price"];
            this.DrinkCount= (int)row["DrinkCount"];
            this.CustomerName = (string)row["CustomerName"];
            this.TotalPrice = (int)row["TotalPrice"]; // số tiền mà bàn đó phải thanh toán 
        }

    }
}
