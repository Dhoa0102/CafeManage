using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Core;

namespace BasicCoffeeShop.DTO
{
    public class SaleReport
    {
        private int id;
        public int ID 
        {
            get { return id; }
            set { id = value; }
        }
        private int totalBill;
        public int TotalBill
        {
            get { return totalBill; }
            set { totalBill = value; }
        }
        private int collectedMoney;
        public int CollectedMoney
        {
            get { return collectedMoney; }
            set { collectedMoney = value; }
        }
        private int spendMoney;
        public int SpendMoney
        {
            get { return spendMoney; }
            set { spendMoney = value; }
        }
        private int totalMoney;
        public int TotalMoney
        {
            get { return totalMoney; }
            set { totalMoney = value; }
        }
        private DateTime daySaleReport;
        public DateTime DaySaleReport
        { get { return daySaleReport; } set { daySaleReport = value; } }
        public SaleReport(int id, int totalBill, int collectedMoney, int spendMoney, int totalMoney, DateTime daySaleReport)
        {
            this.id = id;
            TotalBill = totalBill;
            CollectedMoney = collectedMoney;
            SpendMoney = spendMoney;
            TotalMoney = totalMoney;
            DaySaleReport = daySaleReport;
        }
        public SaleReport(DateTime date)
        {
            DaySaleReport= date;
            string query = "exec USP_GetSalesReportListByDate @DateCheck";
            DataTable data= DataProvider.Instance.ExecuteQuery(query, new object[] { date });
            if (data.Rows.Count ==0)
                return;
            DataRow row= data.Rows[0];
            TotalBill = (int)row["Total Bill"];
            CollectedMoney = (int)row["Collected Money"];
            SpendMoney = (int)row["Spend Money"];
            TotalMoney = (int)row["ToTal Money"];

        }
        public SaleReport(int totalBill, int collectedMoney, int spendMoney, int totalMoney)
        {
            TotalBill = totalBill;
            CollectedMoney = collectedMoney;
            SpendMoney = spendMoney;
            TotalMoney = totalMoney;
        }
        public SaleReport(DataGridViewRow dgv)
        {
            TotalBill = (int)dgv.Cells[1].Value;
            CollectedMoney = (int)dgv.Cells[2].Value;
            SpendMoney = (int)dgv.Cells[3].Value;
            TotalMoney = (int)dgv.Cells[4].Value;
        }
        public override string ToString()
        {
            string st = "";
            st += "Total Bill:" + TotalBill.ToString()+"\n";
            st += "Collected Money:" + CollectedMoney.ToString() + "\n";
            st += "Spend Money:" + SpendMoney.ToString() + "\n";
            st += "Total Money:" + TotalMoney.ToString() + "\n";
            return st;
        }
    }
}
