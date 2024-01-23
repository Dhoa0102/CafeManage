using BasicCoffeeShop.DAO;
using BasicCoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCoffeeShop
{
    public class accountDAO
    {
        private static accountDAO instance;
        public static accountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new accountDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        DataTable data = new DataTable();
        public bool Login(string userName, string passWord)
        {
            // nếu có bảng trả về thì return true
            //NÊN DÙNG PROC ĐỂ ĐĂNG NHẬP
            string query = "EXEC USP_Login @userName , @passWord"; // ĐÂY LÀ CÂU LỆNH PROC SELECT * FROM Account
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            if (result.Rows.Count > 0)
                return true;
            return false;

        }
        public int Status(string userName, string passWord)
        {
            string query = "EXEC USP_STATUS @userName , @passWord"; //ĐÂY LÀ CÂU LỆNH PROC SELECT * id FROM Account 
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { userName, passWord });
            if(result==null)
                return 0;
            int status = int.Parse(result.ToString());
            return status;
        }
        public object GetNameByUserName(string userName)
        {
            string query = "select PersonTable.Name from PersonTable inner join Account on PersonTable.PersonID=Account.PersonID where Account.UserName=N'" + userName + "'";
            object perName = DataProvider.Instance.ExecuteScalar(query);
            return perName;
        }
        public bool InsertAccount(string username, string name, string phoneNumber, string password, string position, int positionValue, string confirmPassword)
        {
            int idPerson = -1;
            if (password != confirmPassword)
            {
                MessageBox.Show("Xac nhan mat khau khong dung\nXin hay thu lai");
                return false;
            }

            bool checkUserName = true;
            object getId = ManageDAO.Instance.GetPersonIDByUserName(username);
            if (getId == null)
                checkUserName = false;
            if (checkUserName == true)
            {
                MessageBox.Show("Ten tai khoan da ton tai");
                return false;
            }
            int insertPersonInfo = DataProvider.Instance.ExecuteNonQuery("INSERT INTO PersonTable\r\nVALUES (N'" + name + "','" + position + "','" + phoneNumber + "')");
            idPerson = ManageDAO.Instance.getMaxPersonID();
            int insertAccount = DataProvider.Instance.ExecuteNonQuery("INSERT INTO Account\r\nVALUES ('" + username + "','" + password + "'," + idPerson + "," + positionValue + ")");
            if (insertAccount > 0 && insertPersonInfo > 0)
                return true;
            else
                return false;
        }
        public bool UpdateAccount(string username, string name, string phoneNumber, string password, string position, int positionValue, string confirmPassword)
        {
            bool checkUserName = true;
            int idPerson = -1;
            object getId = DataProvider.Instance.ExecuteScalar(" select PersonID from Account where UserName='" + username + "' and PassWord='" + confirmPassword + "'");
            if (getId == null)
                checkUserName = false;
            else idPerson = int.Parse(getId.ToString());
            int updateAccount = DataProvider.Instance.ExecuteNonQuery("update Account set PassWord='" + password + "',TypeAcc='" + positionValue + "'where UserName='" + username + "'");
            int updatePersonInfo = DataProvider.Instance.ExecuteNonQuery("update PersonTable set Name=N'" + name + "',Type=N'" + position + "', PhoneNumber='" + phoneNumber + "' where PersonID=" + idPerson);
            if (checkUserName && updateAccount > 0 && updatePersonInfo > 0)
                return true;
            else return false;
        }
        public bool deleteAccount(string username, string confirmPassword)
        {
            int idPerson = -1;
            object getId = DataProvider.Instance.ExecuteScalar(" select PersonID from Account where UserName='"+username+"' and PassWord='"+confirmPassword+"'");
            if (getId == null)
                return false;
            else idPerson = int.Parse(getId.ToString());
            int deleteAccount = DataProvider.Instance.ExecuteNonQuery("delete Account where UserName='" + username + "'");
            int deletePersonInfo = DataProvider.Instance.ExecuteNonQuery("delete PersonTable where PersonID=" + idPerson);
            if (deleteAccount > 0 && deletePersonInfo > 0)
                return true;
            else return false;
        }
        public List<Account> GetAccountList()
        {
            List<Account> list = new List<Account>();
            string query = "select Name, UserName, Type, PhoneNumber from Account inner join PersonTable on Account.PersonID=PersonTable.PersonID";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Account accountItem = new Account(row);
                list.Add(accountItem);
            }
            return list;
        }
    }
}

