using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop.DAO
{
    public class InventoryDAO
    {
        private static InventoryDAO instanse;
        public static InventoryDAO Instanse
        {
            get 
            {
                if(instanse == null)
                    instanse = new InventoryDAO();
                return instanse; 
            }
            private set { instanse = value; }
        }
        public InventoryDAO() { }
        public List<Inventory> GetInventoryList()
        {
            List<Inventory> invenList = new List<Inventory>();
            string query = "select IDdrink as Id, Name,Amount from Inventory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Inventory invenItem = new Inventory(row);
                invenList.Add(invenItem);
            }
            return invenList;
        }
        public bool InsertInventory(string name, int Amount)
        {
            string s = string.Format("select IDdrink from Drink where Drink.Name=N'{0}'", name);
            object id = DataProvider.Instance.ExecuteScalar(s);
            if (id == null)
            {
                if (drinkDAO.Instance.InsertDrink(name, 0) == false)
                    return false;
            }
            id = DataProvider.Instance.ExecuteScalar(s);
            string query = string.Format("insert into Inventory values ({0},'{1}',{2})", id, name, Amount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateInventory(string name, int Amount, int id)
        {
            string query = string.Format("update Inventory set Name=N'{0}',Amount={1} where IDdrink={2}", name, Amount, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteInventory(int id)
        {
            string query = string.Format("delete Inventory where IDdrink=" + id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
