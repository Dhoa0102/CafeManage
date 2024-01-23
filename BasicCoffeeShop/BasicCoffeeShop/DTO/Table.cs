using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCoffeeShop
{
    public class Table
    {
        private string status; // trạng thái của bàn 
        private string name;

        private int iD;

        public int ID
        {
            get
            {
                return iD;
            }
            set
            {
                iD = value;
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public Table(int id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }
        public Table(DataRow row)
        {
            this.ID = (int)row["ID"]; // lấy trường id
            this.Name = row["Name"].ToString();
            this.Status = row["Status"].ToString();
        }
        public Table(string name)
        {
            this.Name=name;
            object itemID = DataProvider.Instance.ExecuteScalar("select id from TableDrink where nameTable='"+name+"'");
            if(itemID == null) 
            {
                ID = -1;
                return;
            }
            object itemStatus= DataProvider.Instance.ExecuteScalar("select statusTable from TableDrink where nameTable='" + name + "'");
            if(itemStatus != null )
            {
                Status=itemStatus.ToString();
            }

        }
        public override string ToString() 
        {
            return ID.ToString()+" || "+name+" || "+status;
        }
    }
}
