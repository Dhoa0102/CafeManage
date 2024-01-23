using BasicCoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicCoffeeShop;

namespace BasicCoffeeShop.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return instance;
            }
            private set { instance = value; }
        }
        public BillInfoDAO()
        { }
    
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> BillInfolist = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT *FROM BillInfo WHERE IDBill=" + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);
                BillInfolist.Add(billInfo);
            }
            return BillInfolist;
        }
        public void insertBillInfo(int idBill,int idDrink,int drinkCount)
        {
            string customerName = DataStorage.Customer.Name;
      //      string customerNameInQuotes = "'" + customerName + "'";
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @IDBill , @IDdrink , @DrinkCount , @CustomerName", new object[] { idBill, idDrink, drinkCount, customerName });
        }

    }
}
