using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop
{
    public class TableDAO
    {
        private static int tableWidth=100;
        private static int tableHeight=100;
        /*public static int TableWidth = 100;
        public static int TableHeight = 100;*/
        public static int TableWidth
        { get { return tableWidth; } }
        public static int TableHeight
        { get { return tableHeight; } }
        //tạo SingleTon
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAO();
                return instance;
            }
            private set
            {
                TableDAO.instance = value;
            }
        }
        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            string query = "SELECT id as [ID], nameTable as [Name], statusTable as[Status] FROM TableDrink";
            DataTable data = DataProvider.Instance.ExecuteQuery(query); ; // lấy TABLE danh sách bàn ăn
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public bool InsertTable(string name, string status)
        {
            string query = string.Format("insert into TableDrink values (N'{0}',N'{1}')", name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(string name, string status, int id)
        {
            string query = string.Format("update TableDrink set nameTable=N'{0}',statusTable=N'{1}' where id={2}", name, status, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int id)
        {
            string query = string.Format("delete TableDrink where id=" + id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public object getStatusTableByID(int id)
        {
            return DataProvider.Instance.ExecuteScalar("select statusTable from TableDrink where id=" + id);
        }

    }
}
