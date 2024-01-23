using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop.DAO
{
    public class FeedbackDAO
    {
        private static FeedbackDAO instance;
        public static FeedbackDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FeedbackDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private FeedbackDAO()
        {

        }
        public void insertFeedBack(int idBill, string customerName, string detail)
        {
            //      string customerNameInQuotes = "'" + customerName + "'";
             DataProvider.Instance.ExecuteNonQuery("USP_InsertFeedback @IDBill , @CustomerName , @Detail ", new object[] { idBill, customerName , detail});
        }
    }
}
