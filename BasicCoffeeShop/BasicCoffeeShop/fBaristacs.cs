using BasicCoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCoffeeShop
{
    public partial class fBaristacs : Form
    {
        public fBaristacs()
        {
            InitializeComponent();
            baristaNameLb.Text = DataStorage.Barista.Name;
            LoadListBillInfo();
        }

        void LoadListBillInfo()
        {
            dgvBillInfoBarista.DataSource = DataProvider.Instance.ExecuteQuery("select IDBillInfo as[ID Bill Infor],TableNumber as[Table Number],Name as[Drink Name], Drinkcount as [Count] from BillInfo inner join Bill on Bill.IDBill=BillInfo.IDBill inner join Drink on Drink.IDdrink=BillInfo.IDdrink where StatusBillInfo=0");
        }

        private void findTableBtn_Click(object sender, EventArgs e)
        {
            if (dgvBillInfoBarista.CurrentRow.Cells[0].Value.ToString() == "")
                return;
            int id= int.Parse(dgvBillInfoBarista.CurrentRow.Cells[0].Value.ToString());
            string baristaName = baristaNameLb.Text;
            string query = "update BillInfo set BaristaServe=N'" + baristaName + "' where IDBillInfo=" + id.ToString();
            DataProvider.Instance.ExecuteNonQuery(query);
            query = "update BillInfo set StatusBillInfo= 1 where IDBillInfo=" + id.ToString();
            DataProvider.Instance.ExecuteNonQuery(query);
            LoadListBillInfo();
            MessageBox.Show(baristaNameLb.Text + " has served this bill.");
            if (dgvBillInfoBarista.RowCount > 1)
            {
                int ifAfter = int.Parse(dgvBillInfoBarista.Rows[0].Cells[0].Value.ToString());
                IDBillBarista.Text = ifAfter.ToString();
            }
            else 
            {
                IDBillBarista.Text ="";
            }

        }

        private void dgvBillInfoBarista_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show(dgvBillInfoBarista.CurrentRow.Cells[0].Value.ToString());
            if (dgvBillInfoBarista.CurrentRow.Cells[0].Value.ToString() == "")
                return;
            int id = int.Parse(dgvBillInfoBarista.CurrentRow.Cells[0].Value.ToString());
            IDBillBarista.Text = id.ToString();
        }

        private void fBaristacs_Load(object sender, EventArgs e)
        {

        }
    }
}
