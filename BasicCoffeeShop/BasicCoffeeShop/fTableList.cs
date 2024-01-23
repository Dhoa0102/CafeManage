using BasicCoffeeShop.DAO;
using BasicCoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCoffeeShop
{
    public partial class fTableList : Form
    {
        public fTableList()
        {
            InitializeComponent();
            if (DataStorage.Customer.Name == "")
                DataStorage.Customer.Name =DataStorage.Manager.Name;
            userNameLb.Text = DataStorage.Customer.Name;
            loadTable();
            loadDrink();
        }

        private void fTableList_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }
        
        void btn_Click(object sender, EventArgs e)
        {
            //lsvBill.Items.Clear();
            lsvBill.Tag = (sender as Button).Tag;
            int tableID = ((sender as Button).Tag as Table).ID;
            Table table = lsvBill.Tag as Table;
            if (table != null)
            {
                TableNamelb.Text = table.Name.ToString();
            }
            showBill(tableID);
        }
        void showBill(int tableID)
        {
            //cần add vô list view
            /* List<BillInfo> listBillInfo = BillInfoDAO.Instance.GetListBillInfo(BillDAO.Instance.GetUncheckBillIDTableID(tableID));

             foreach (BillInfo item in listBillInfo)
             {
                 ListViewItem lsvItem = new ListViewItem(item.IDBill.ToString());
                 lsvItem.SubItems.Add(item.IDdrink.ToString());
                 lsvItem.SubItems.Add(item.DrinkCount.ToString());
                 lsvItem.SubItems.Add(item.BaristaServe);
                 lsvBill.Items.Add(lsvItem);
             }*/
            lsvBill.Items.Clear();
            List<Menu> list = MenuDAO.Instance.GetListMenuByTable(tableID);
            int totalPrice = 0;
            foreach (Menu item in list)
            {
                ListViewItem lsvItem = new ListViewItem(item.DrinkName.ToString());
                lsvItem.SubItems.Add(item.DrinkCount.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                lsvItem.SubItems.Add(item.CustomerName.ToString());
                totalPrice = totalPrice + item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            txbTotalPrice.Text = totalPrice.ToString();
        

        }
        void loadTable()
        {
            flpTable.Controls.Clear();
            List<Table> Tablelist = TableDAO.Instance.LoadTableList();
            foreach (Table item in Tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight};
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Tag = item;
                btn.Click += btn_Click;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        break;
                    case "Có người":
                        btn.BackColor = Color.Green;
                        break;
                }
                flpTable.Controls.Add(btn);
            }

        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void loadDrink()
        {
            List<Drink> list = drinkDAO.Instance.getListDrink();
            cbxDrink.DataSource = list;
            cbxDrink.DisplayMember = "Name";
        }

        void UpdateAmountInventory(int amount,int drinkCount,int IDdrink)
        {
            int idDr;
            object idkho = DataProvider.Instance.ExecuteScalar("select Inventory.IDdrink from Inventory inner join Drink on Inventory.Name=Drink.Name where Drink.IDdrink=" + IDdrink.ToString());
            if (idkho != null)
            {
                idDr = int.Parse(idkho.ToString());
                amount = amount - drinkCount;
                DataProvider.Instance.ExecuteNonQuery("update Inventory set Amount =" + amount.ToString() + " where IDdrink =" + idDr.ToString());

            }
        }

        private void orderDrinkBtn_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                return;
            }
            int IDdrink = (cbxDrink.SelectedItem as Drink).ID;
            int drinkCount = (int)nmDrinkCount.Value;
            if (drinkCount < 1) return;
            object amountFromIVTR = DataProvider.Instance.ExecuteScalar("select Amount from Inventory inner join Drink on Inventory.Name=Drink.Name where Drink.IDdrink="+IDdrink.ToString());
            int amount = 0;
            if(amountFromIVTR != null)
                amount=int.Parse(amountFromIVTR.ToString());
            if(amount<drinkCount)
            {
                MessageBox.Show("So luong hang trong kho la " + amount.ToString() + " khong du");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDTableID(table.ID);
            if (idBill == -1)
            {
                BillDAO.Instance.insertBill(table.ID);
                idBill = BillDAO.Instance.getMaxIDBill();
                BillInfoDAO.Instance.insertBillInfo(idBill, IDdrink, drinkCount);
                UpdateAmountInventory(amount, drinkCount, IDdrink);
            }
           else
           {
                BillInfoDAO.Instance.insertBillInfo(idBill, IDdrink, drinkCount);
                UpdateAmountInventory(amount, drinkCount, IDdrink);
            }
            showBill(table.ID);
            loadTable();    
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int discount = (int)SNUDdiscount.Value;      
            int idBill = BillDAO.Instance.GetUncheckBillIDTableID(table.ID);
            int totalPrice = int.Parse(txbTotalPrice.Text);
            int finalTotalPrice = totalPrice - (totalPrice/100)*discount;
            DataProvider.Instance.ExecuteNonQuery("update Bill set TotalPrice="+finalTotalPrice+ " where IDBill="+ idBill+ " and StatusBill=0");
            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hóa đơn cho bàn {0}\n Tổng tiền -(Tổng tiền/100)xgiảm giá={1}-({1}/100)x{2} = {3}" ,table.Name,totalPrice,discount,finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,discount);
                    showBill(table.ID);
                    loadTable();        
                }
                DateTime datecheck = DateTime.Parse(DataProvider.Instance.ExecuteScalar("select DateCheck from Bill where IDBill=" + idBill).ToString());
                DataTable saleReport = DataProvider.Instance.ExecuteQuery("exec USP_GetSalesReportListByDate @DateCheck ", new object[] { datecheck });
                if (saleReport.Rows.Count == 0)
                {
                    DataProvider.Instance.ExecuteNonQuery("exec USP_InsertSaleReport @Day , @CollectedMoney , @SpendMoney , @TotalMoney , @TotalBill", new object[] { datecheck, finalTotalPrice, 0, finalTotalPrice, 1 });
                }
                else
                {
                    int colectMoney = int.Parse(saleReport.Rows[0].ItemArray[1].ToString()) + finalTotalPrice;
                    int totalMoney = int.Parse(saleReport.Rows[0].ItemArray[3].ToString()) + finalTotalPrice;
                    int totalBill = int.Parse(saleReport.Rows[0].ItemArray[0].ToString()) + 1;
                    DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateSaleReport @Day , @CollectedMoney , @TotalMoney , @TotalBill", new object[] { datecheck, colectMoney, totalMoney, totalBill });
                }
                DataStorage.Bill=new Bill(idBill);
                FeedbackForm f=new FeedbackForm();
                f.Show();
            }
        }

        private void userNameLb_Click(object sender, EventArgs e)
        {

        }
    }
}
