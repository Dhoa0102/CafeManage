using BasicCoffeeShop.DAO;
using BasicCoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BasicCoffeeShop
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MenuDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private MenuDAO()
        {

        }
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> list = new List<Menu>();
            string query = "SELECT Name,DrinkCount,Price,DrinkCount* Price as TotalPrice,CustomerName FROM Drink,(SELECT Bill.IDBill,TableNumber,IDDrink,DrinkCount,StatusBill,CustomerName FROM Bill,BillInfo WHERE Bill.IDBill = BillInfo.IDBill)AS A where Drink.IDdrink = A.IDdrink and TableNumber = " + id+" and A.StatusBill = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item); 
                list.Add(menu);     
            }
            return list;
        }
    }
}
