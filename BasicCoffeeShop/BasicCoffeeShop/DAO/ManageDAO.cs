using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Siticone.Desktop.UI.WinForms.Helpers.GraphicsHelper;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BasicCoffeeShop.DTO;

namespace BasicCoffeeShop
{
    public class ManageDAO
    {
        private static ManageDAO instance;
        public static ManageDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ManageDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        public ManageDAO() { }
        //Bill
        public DataTable GetBillListByDateCheck(DateTime date)
        {
            return BillDAO.Instance.GetBillListByDateCheck(date);
        }
        public DataTable GetBillInforByIDBill(int id)
        {
            string query = "exec USP_GetBillInfoByIDBill @IDBill";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        // Sale report
        public DataTable GetSalesReportListByDateCheck(DateTime date)
        {
            string query = "exec USP_GetSalesReportListByDate @DateCheck";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { date });
        }
        //insert
        public bool InsertDrink(string name, int price)
        {
            return drinkDAO.Instance.InsertDrink(name, price);
        }
        public bool InsertInventory(string name, int Amount)
        {
            return InventoryDAO.Instanse.InsertInventory(name, Amount);
        }
        public bool InsertTable(string name, string status)
        {
            return TableDAO.Instance.InsertTable(name, status);
        }
        public bool InsertAccount(string username,string name, string phoneNumber, string password, string position,int positionValue, string confirmPassword)
        {
            return accountDAO.Instance.InsertAccount(username, name, phoneNumber, password, position, positionValue, confirmPassword);
        }
        //update
        public bool UpdateDrink(string name, int price, int id)
        {
            return drinkDAO.Instance.UpdateDrink(name, price, id);
        }
        public bool UpdateInventory(string name, int Amount, int id)
        {
            return InventoryDAO.Instanse.UpdateInventory(name, Amount, id);
        }
        public bool UpdateTable(string name, string status, int id)
        {
            return TableDAO.Instance.UpdateTable(name, status, id);
        }
        public bool UpdateAccount(string username, string name, string phoneNumber, string password, string position, int positionValue, string confirmPassword)
        {
            return accountDAO.Instance.UpdateAccount(username,name, phoneNumber, password, position,positionValue, confirmPassword);
        }
        //delete
        public bool DeleteDrink(int id)
        {
            return drinkDAO.Instance.DeleteDrink(id);
        }
        public bool DeleteInventory(int id)
        {
            return InventoryDAO.Instanse.DeleteInventory(id);
        }
        public bool DeleteTable(int id)
        {
            return TableDAO.Instance.DeleteTable(id);
        }
        public void deleteBillInfoByDrinkID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete BillInfo where IDdrink=" + id);
        }
        public bool deleteAccount(string username, string confirmPassword)
        {
            return accountDAO.Instance.deleteAccount(username, confirmPassword);
        }
        //find
        /*List<Drink> SearchDrinkByName(string name)
        {
            List<Drink> listDrink= new List<Drink>();

        }*/
        //Table
        public object getStatusTableByID(int id)
        {
            return TableDAO.Instance.getStatusTableByID(id);
        }
        public object getTableNameByIDBill(int id)
        {
            return DataProvider.Instance.ExecuteScalar("select nameTable from TableDrink inner join Bill on TableDrink.id=Bill.TableNumber Where Bill.IDBill=" + id);
        }
        public object GetToTalMoneyByID(int id)
        {
            return DataProvider.Instance.ExecuteScalar("select Bill.TotalPrice from Bill where IDBill=" + id);
        }
        public object GetTypeAccByUserName(string userName)
        {
            return DataProvider.Instance.ExecuteScalar("select TypeAcc from Account where UserName='" + userName + "'");
        }
        public object GetPersonIDByUserName(string username)
        {
            return DataProvider.Instance.ExecuteScalar(" select PersonID from Account where UserName='" + username + "'");
        }
        
        public int getMaxPersonID()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT max(PersonID) from PersonTable");
            }
            catch
            {
                return 1;
            }
        }
        public List<Drink> getListDrink()
        {
            return drinkDAO.Instance.getListDrink();
        }
        public List<Inventory> GetInventoryList()
        {
            return InventoryDAO.Instanse.GetInventoryList();
        }
        public List<Table> GetTableList() 
        {
            return TableDAO.Instance.LoadTableList();
        }
        public List<BillInfo> GetBillInfo(int id)
        {
            return BillInfoDAO.Instance.GetListBillInfo(id);
        }
        public List<Account> GetAccountList()
        {
            return accountDAO.Instance.GetAccountList();
        }
    }
}
