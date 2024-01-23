using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop.DTO
{
     public class Feedback
    {
        private int idBill;
        private string customerName;
        private string detail;
        public int IdBill
        {
            get { return idBill; }          
            set { idBill = value; }     
        }
        public string CustomerName
        {
            get { return customerName; }        
            set { customerName = value; }       
        }
        public string Detail
        {
            get { return detail; }      
            set { detail = value; }         
        }
        public Feedback(int IDBill) 
        {
            IdBill= IDBill;
            object FbCustomerName = DataProvider.Instance.ExecuteScalar("Select CustomerName from Feedback where IDBill=" + IDBill);
            if (FbCustomerName == null)
                idBill = -1;
            else CustomerName=FbCustomerName.ToString();
            object FbDetail = DataProvider.Instance.ExecuteScalar("Select Detail from Feedback where IDBill=" + IDBill);
            if (FbDetail == null) idBill = -1;
            else Detail=FbDetail.ToString();
        }
        public override string ToString()
        {
            return "Customer name:" + CustomerName + "\nFeedback:" + Detail;
        }
    }
}
