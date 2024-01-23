using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop
{
    public class Bill
    {
        private int iDBill;
        private int tableNumber;
        private DateTime? dateCheck;
        private int statusBill;
        //   private int discount;

        //  public int Discount
        // {
        //     get { return discount; }        
        //    set { discount = value; }       
        // }
        private int discount;
        public int Discount
        {
            get { return discount; }    
            set { discount = value; }       
        }
        public int TableNumber
        {
            get { return tableNumber; } 
            set { tableNumber = value; }    
        }
        public int IDBill
        {
            get { return iDBill; }  
            set { iDBill = value; }     
        }
        public DateTime? DateCheck
        {
            get { return dateCheck; } set { dateCheck = value; }    
        }
        
        public int StatusBill
        {
            get { return statusBill; }      
            set
            {
                statusBill = value;     
            }
        }
        public Bill(int idBill)
        {
            this.iDBill = idBill;
        }
        public Bill(int idBill,int tablenumber,DateTime? dateCheck, int totalMoney,int statusBill,int disCount=0)
        {
            this.IDBill = idBill;
            this.TableNumber = tablenumber;     
            this.DateCheck = dateCheck;
            this.Discount=disCount; 
            this.StatusBill = statusBill;
  
        }
        public Bill(DataRow row)
        {
            this.IDBill = (int)row["IDBill"];
            this.TableNumber = (int)row["TableNumber"];
            this.DateCheck = (DateTime?)row["DateCheck"];
            this.Discount = (int)row["discount"];
            this.StatusBill = (int)row["StatusBill"];
        }
        public override string ToString()
        {
            string s = "";
            string query = "exec USP_GetBillInfoByIDBill @IDBill";
            DataTable data= DataProvider.Instance.ExecuteQuery(query, new object[] { iDBill });
            foreach (DataRow row in data.Rows)
            {
                s += row["Drink"] + " \t||\t " + row["Price"] + " \t||\t " + row["Amount"] + " \t||\t " + row["Barista Serve"] + " \t||\t " + row["Customer Name"]+"\n";
            }
            return s;
        }
    }
}
