using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private BillDAO()
        {

        }
        //lấy id của bàn chưa check
        /// <summary>
        /// Thành công sẽ lấy được BilLID thất bại sẽ nhận -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetUncheckBillIDTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE TableNumber =" + id + "AND StatusBill =0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.IDBill;
            }
            return -1;

        }
        public void insertBill(int tableNumber)
        {
            DataProvider.Instance.ExecuteScalar("USP_InsertBill @TableNumber , @StatusBill",new object[] {tableNumber,0});
        }
        public int getMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT max(IDBill) from Bill");
            }
            catch
            {
                return 1;
            }
        }
        public void CheckOut(int id,int discount)
        {
            string query = "UPDATE Bill SET StatusBill =1,"+"discount= "+discount+" WHERE IDBill = " + id;
            DataProvider.Instance.ExecuteScalar(query);
        }
        public DataTable GetBillListByDateCheck(DateTime date)
        {
            string query = "exec USP_GetBillListByDate @DateCheck";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { date });
        }
    }
}
