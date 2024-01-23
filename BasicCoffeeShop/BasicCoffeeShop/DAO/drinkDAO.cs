using BasicCoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop.DAO
{
    public class drinkDAO
    {
        private static drinkDAO instance;
        public static drinkDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new drinkDAO();
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public drinkDAO()
        {

        }
        public List<Drink> getListDrink ()
        {
            List<Drink> listDrink = new List<Drink>();
            string query = "select IDdrink as [ID], Name as [Name],Price from Drink";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Drink drk = new Drink(row);
                listDrink.Add(drk);     
            }        
            return listDrink;    
        }
        List<Drink> SearchDrinkByName(string name)
        {
            List<Drink> listDrink = new List<Drink>();
            string query = "SELECT * FROM Drink where Name='" + name + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Drink drk = new Drink(row);
                listDrink.Add(drk);
            }
            return listDrink;
        }
        public bool InsertDrink(string name, int price)
        {
            string query = string.Format("insert into Drink values ('{0}',{1})", name, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDrink(string name, int price, int id)
        {
            string query = string.Format("update Drink set Name=N'{0}',Price={1} where IDdrink={2}", name, price, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDrink(int id)
        {
            string query = string.Format("delete Drink where IDdrink=" + id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
