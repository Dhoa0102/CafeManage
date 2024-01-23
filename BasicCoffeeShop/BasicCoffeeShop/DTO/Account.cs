using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop.DTO
{
    public class Account
    {
        private string name;
        private string userName;
        //private string password;
        //private int personID;
        private string typeAcc;
        private string phoneNumber;
        public string Name { get { return name; } set { name = value; } }
        public string UserName { get { return userName; } set { userName = value; } }
        //public string Password { get { return password; } set { password = value; } }
        //public int PersonID { get {  return personID; } set {  personID = value; } }
        public string Type {  get { return typeAcc; } set {  typeAcc = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public Account() { }
        public Account(DataRow row)
        {
            this.Name = (string)row["Name"];
            this.UserName = (string)row["UserName"];
            this.Type = (string)row["Type"];
            this.PhoneNumber = (string)row["PhoneNumber"];
        }
        public Account(string name)
        {
            Name= name;
            object perUserName = DataProvider.Instance.ExecuteScalar("select UserName from Account inner join PersonTable on Account.PersonID=PersonTable.PersonID where PersonTable.Name =N'" + name + "' ");
            if (perUserName != null)
            {
                UserName = perUserName.ToString();
            }
            else UserName = "";
            object perType = DataProvider.Instance.ExecuteScalar("select Type from Account inner join PersonTable on Account.PersonID=PersonTable.PersonID where PersonTable.Name =N'" + name + "' ");
            if (perType != null)
                Type = perType.ToString();
            else Type = "";
            object perPhoneNumber = DataProvider.Instance.ExecuteScalar("select PhoneNumber from Account inner join PersonTable on Account.PersonID=PersonTable.PersonID where PersonTable.Name =N'" + name + "' ");
            if (perPhoneNumber != null)
                PhoneNumber = perPhoneNumber.ToString();
            else PhoneNumber = "";

        }
    }
}
