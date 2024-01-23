using BasicCoffeeShop.DAO;
using BasicCoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TheArtOfDev.HtmlRenderer.Core;

namespace BasicCoffeeShop
{
    public partial class fManager : Form
    {
        BindingSource drinkList = new BindingSource();
        BindingSource inventoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource accountList= new BindingSource();
        string managerName;
        public fManager()
        {
            InitializeComponent();
            loadManage();

        }
        void loadManage()
        {
            managerName = DataStorage.Manager.Name;
            LoadListDrink();
            LoadInventory();
            LoadTableList();
            LoadAccountList();
            dgvDrink.DataSource = drinkList;
            dgvInventory.DataSource = inventoryList;
            dgvTable.DataSource = tableList;
            dgvAccount.DataSource = accountList;
            addTableBinding();
            addDrinkBinding();
            addInventoryBinding();
            addAccountBinding();
            dtpkBill.Value = DateTime.Now;
            dtpkSalesReport.Value = DateTime.Now;
            LoadListSalesReportByDate(dtpkSalesReport.Value.Date);
            LoadListBillByDate(dtpkBill.Value.Date);
        }
        void LoadAccountList()
        {
            List<Account> list = ManageDAO.Instance.GetAccountList();
            accountList.DataSource= list;
            //accountList.DataSource = DataProvider.Instance.ExecuteQuery("select Name, UserName, Type, PhoneNumber from Account inner join PersonTable on Account.PersonID=PersonTable.PersonID");
        }
        void LoadInventory()
        {
            List<Inventory> inventory = new List<Inventory>();
            inventory = ManageDAO.Instance.GetInventoryList();
            inventoryList.DataSource = inventory;
        }
        void LoadTableList()
        {
            List<Table> tables = new List<Table>();
            tables = ManageDAO.Instance.GetTableList();
            tableList.DataSource = tables;
        }
        void LoadListBillByDate(DateTime date)
        {
            dgvBill.DataSource = ManageDAO.Instance.GetBillListByDateCheck(date);
        }
        void LoadListSalesReportByDate(DateTime date) 
        {
            SaleReport saleReport = new SaleReport(date);
            List<SaleReport> sales = new List<SaleReport>();
            sales.Add(saleReport);
            dgvSalesReport.DataSource= sales;
        }
        void LoadListDrink()
        {
            List<Drink> drinks = drinkDAO.Instance.getListDrink();
            drinkList.DataSource = drinks;
        }
        void addInventoryBinding()
        {
            drinkNameInventoryTb.DataBindings.Add(new Binding("Text", dgvInventory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            amountInventoryTb.DataBindings.Add(new Binding("Text", dgvInventory.DataSource, "Amount", true, DataSourceUpdateMode.Never));
            idInventoryTb.DataBindings.Add(new Binding("Text", dgvInventory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            for (int i = 0; i < dgvInventory.Rows.Count; i++)
            {
                if(dgvInventory.Rows[i].Cells[1].Value!= null)
                    auto1.Add(dgvInventory.Rows[i].Cells[1].Value.ToString());
            }
            findInventoryTb.AutoCompleteCustomSource = auto1;
        }
        void addDrinkBinding()
        {
            drinkNameDrinkTb.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "Name", true, DataSourceUpdateMode.Never));
            priceDrinkTb.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "Price", true, DataSourceUpdateMode.Never));
            idDrinkTb.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "ID", true, DataSourceUpdateMode.Never));
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            for (int i = 0; i < dgvDrink.Rows.Count; i++)
            {
                if(dgvDrink.Rows[i].Cells[1].Value!=null)
                    auto1.Add(dgvDrink.Rows[i].Cells[1].Value.ToString());
            }
            findDrinkTb.AutoCompleteCustomSource = auto1;
        }
        void addTableBinding()
        {
            idTableTb.DataBindings.Add(new Binding("Text",dgvTable.DataSource, "ID", true,DataSourceUpdateMode.Never));
            tableNameTb.DataBindings.Add(new Binding("Text",dgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            for (int i = 0; i < dgvTable.Rows.Count; i++)
            {
                if(dgvTable.Rows[i].Cells[1].Value!=null)
                    auto1.Add(dgvTable.Rows[i].Cells[1].Value.ToString());
            }
            findTableTb.AutoCompleteCustomSource = auto1;
        }
        void addAccountBinding()
        {
            personNametb.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Name", true, DataSourceUpdateMode.Never));
            userNameTb.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            phoneNumberTb.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "PhoneNumber", true, DataSourceUpdateMode.Never));
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            for (int i = 0; i < dgvAccount.Rows.Count; i++)
            {
                if(dgvAccount.Rows[i].Cells[0].Value!=null)
                    auto1.Add(dgvAccount.Rows[i].Cells[0].Value.ToString());
            }
            findAccountTb.AutoCompleteCustomSource = auto1;
        }
        private void siticoneButton2_Click(object sender, EventArgs e)// delete drink button
        {
            if(idDrinkTb.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi xoa mon\nHay chon mon an can xoa");
                return;
            }
            int id = int.Parse(idDrinkTb.Text);
            ManageDAO.Instance.deleteBillInfoByDrinkID(id);
            bool deleteInventory=ManageDAO.Instance.DeleteInventory(id);
            if (ManageDAO.Instance.DeleteDrink(id))
            {
                MessageBox.Show("Xoa mon thanh cong");
                LoadListDrink();
                LoadInventory();
            }
            else
                MessageBox.Show("Da xay ra loi khi xoa mon");
        }

        private void siticoneDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkBill.Value.Date);
        }

        private void addDrinkBtn_Click(object sender, EventArgs e)
        {
            string name = drinkNameDrinkTb.Text;
            if (name == "" || priceDrinkTb.Text == "")
            {
                MessageBox.Show("Da xay ra loi khi them mon\nHay dien day du thong tin");
                return;
            }
            int price = int.Parse(priceDrinkTb.Text);
            if (ManageDAO.Instance.InsertDrink(name, price))
            {
                MessageBox.Show("Them mon thanh cong");
                LoadListDrink();
            }
            else
                MessageBox.Show("Da xay ra loi khi them mon");
        }

        private void updateDrinkBtn_Click(object sender, EventArgs e)
        {
            if(drinkNameDrinkTb.Text == "" || priceDrinkTb.Text == ""||idDrinkTb.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi cap nhat mon\nHay dien day du thong tin");
                return;
            }
            string name = drinkNameDrinkTb.Text;
            int price = int.Parse(priceDrinkTb.Text);
            int id = int.Parse(idDrinkTb.Text);
            if (ManageDAO.Instance.UpdateDrink(name, price, id))
            {
                MessageBox.Show("Cap nhat mon thanh cong");
                LoadListDrink();
            }
            else
                MessageBox.Show("Da xay ra loi khi cap nhat mon");
        }

        private void addInventoryBtn_Click(object sender, EventArgs e)
        {
            if(drinkNameInventoryTb.Text==""||amountInventoryTb.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi them vao kho\nHay dien day du thong tin");
                return;
            }
            string name = drinkNameInventoryTb.Text;
            int Amount = int.Parse(amountInventoryTb.Text);
            if (ManageDAO.Instance.InsertInventory(name, Amount))
            {
                MessageBox.Show("Them thanh cong");
                LoadInventory();
                LoadListDrink();
            }
            else
                MessageBox.Show("Da xay ra loi khi them");
        }

        private void deleteInventoryBtn_Click(object sender, EventArgs e)
        {
            if(idInventoryTb.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi xoa\nHay chon vat pham can xoa");
                return;
            }
            int id = int.Parse(idInventoryTb.Text);
            if (ManageDAO.Instance.DeleteInventory(id))
            {
                MessageBox.Show("Xoa thanh cong");
                LoadInventory();
            }
            else
                MessageBox.Show("Da xay ra loi khi xoa");
        }

        private void updateInventoryBtn_Click(object sender, EventArgs e)
        {
            if(drinkNameInventoryTb.Text=="" || amountInventoryTb.Text==""|| idInventoryTb.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi cap nhat kho\nHay dien day du thong tin");
                return;
            }
            string name = drinkNameInventoryTb.Text;
            int Amount = int.Parse(amountInventoryTb.Text);
            int id = int.Parse(idInventoryTb.Text);
            if (ManageDAO.Instance.UpdateInventory(name, Amount, id))
            {
                MessageBox.Show("Cap nhat thanh cong");
                LoadInventory();
            }
            else
                MessageBox.Show("Da xay ra loi khi cap nhat mon");
        }

        private void idTableTb_TextChanged(object sender, EventArgs e)
        {
            int id = -1;
            if(Int32.TryParse(idTableTb.Text, out id))
            {
                object st = ManageDAO.Instance.getStatusTableByID(id);
                if (st != null)
                    cbStatusTable.SelectedItem = st;
            }
            
        }

        private void addTableBtn_Click(object sender, EventArgs e)
        {
            if(tableNameTb.Text == "" || cbStatusTable.Text == "")
            {
                MessageBox.Show("Da xay ra loi khi them ban\nHay dien day du thong tin");
                return;
            }
            string name = tableNameTb.Text;
            string status=cbStatusTable.Text;
            if (ManageDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Them ban thanh cong");
                LoadTableList();
            }
            else
                MessageBox.Show("Da xay ra loi khi them ban");
        }

        private void deleteTableBtn_Click(object sender, EventArgs e)
        {
            if(idTableTb.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi xoa ban\nHay chon ban can xoa");
                return;
            }
            int id = int.Parse(idTableTb.Text);
            if (ManageDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xoa thanh cong");
                LoadTableList();
            }
            else
                MessageBox.Show("Da xay ra loi khi xoa");
        }

        private void updateTableBtn_Click(object sender, EventArgs e)
        {
            if(tableNameTb.Text == "" || cbStatusTable.Text == "" ||idTableTb.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi cap nhat ban\nHay dien day du thong tin");
                return;
            }
            string name = tableNameTb.Text;
            string status= cbStatusTable.Text;
            int id = int.Parse(idTableTb.Text);
            if (ManageDAO.Instance.UpdateTable(name, status, id))
            {
                MessageBox.Show("Cap nhat ban thanh cong");
                LoadTableList();
            }
            else
                MessageBox.Show("Da xay ra loi khi cap nhat ban");
        }

        private void dtpkSalesReport_ValueChanged(object sender, EventArgs e)
        {
            LoadListSalesReportByDate(dtpkSalesReport.Value.Date);
        }

        private void managerTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(managerTab.SelectedIndex==5)
            {
                fTableList fTable = new fTableList();
                this.Hide();
                fTable.ShowDialog();
                this.Show();
            }
        }

        private void dgvBill_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBill.CurrentRow.Cells[0].Value.ToString() =="" ) return;
            int id=int.Parse(dgvBill.CurrentRow.Cells[0].Value.ToString());
            idBillLb.Text = id.ToString();
            //dgvBillInfor.DataSource=ManageDAO.Instance.GetBillInfo(id);
            dgvBillInfor.DataSource=ManageDAO.Instance.GetBillInforByIDBill(id);
            object money=ManageDAO.Instance.GetToTalMoneyByID(id);
            if (money != null)
                paymentLabel.Text = money.ToString();
            else
                paymentLabel.Text = "0";
        }
        private void printBillBtn_Click(object sender, EventArgs e)
        { 
            if(idBillLb.Text=="")
            {
                MessageBox.Show("Hay chon Bill truoc khi in");
                return;
            }
            string filePath=@"D:\OOP\BillInforFile\BillID-" + idBillLb.Text + ".txt";
            int id = int.Parse(idBillLb.Text);
            string s = "";
            object tableName = ManageDAO.Instance.getTableNameByIDBill(id);
            if (tableName != null)
                s = "Table: " + tableName.ToString() + "\n";
            Feedback customerFb = new Feedback(id);
            s += customerFb.ToString();
            s += "\nDrink \t||\t Price \t||\t Amount \t||\t Barista Serve \t||\t Customer\n";
            Bill BillPrint = new Bill(id);
            s = s + BillPrint.ToString();
             s += "ToTal Money : " + paymentLabel.Text + "\n";
            File.WriteAllText(filePath, s);
            MessageBox.Show("In Bill Thanh Cong");
        }

        private void siticoneButton9_Click(object sender, EventArgs e)
        {
            string sDay = dtpkSalesReport.Value.Day.ToString();
            string sMonth = dtpkSalesReport.Value.Month.ToString();
            string sYear = dtpkSalesReport.Value.Year.ToString();
            string filePath = @"D:\OOP\SaleReport\SaleReportDay"+sDay+"-"+sMonth+"-"+sYear+".txt";

            string s = "Day Create: "+ DateTime.Now.ToShortDateString()+"\n";
            s += "Create By: ";
            s += managerName;
            s += "\n";
            s += "Day Sale: " + dtpkSalesReport.Value.ToShortDateString() + "\n";
            SaleReport reportPrint = new SaleReport(dgvSalesReport.Rows[0]);
            s += reportPrint.ToString();
            File.WriteAllText(filePath, s);
            MessageBox.Show("In Thanh Cong");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userNameTb_TextChanged(object sender, EventArgs e)
        {
            string userName = userNameTb.Text;
            if (userName!="")
            {
                object st = ManageDAO.Instance.GetTypeAccByUserName(userName);
                if (st == null)
                    cbPositionAccount.SelectedIndex=3;
                else
                {
                    int position=int.Parse(st.ToString());
                    cbPositionAccount.SelectedIndex = position-1;
                }

            }
        }

        private void siticoneTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void addAccountBtn_Click(object sender, EventArgs e)
        {
            if(userNameTb.Text==""||personNametb.Text==""||phoneNumberTb.Text ==""||passwordTb.Text==""||cbPositionAccount.Text=="" || confirmPasswordTb.Text=="" )
            {
                MessageBox.Show("Da xay ra loi khi them tai khoan\nHay dien day du thong tin");
                return;
            }
            string username = userNameTb.Text;
            string name=personNametb.Text;
            string phoneNumber=phoneNumberTb.Text;
            string password=passwordTb.Text;
            string position = cbPositionAccount.Text;
            int positionValue = cbPositionAccount.SelectedIndex + 1;
            string confirmPassword = confirmPasswordTb.Text;
            bool insertAccount=ManageDAO.Instance.InsertAccount(username,name,phoneNumber,password,position,positionValue,confirmPassword);
            if (insertAccount)
            {
                MessageBox.Show("Them tai khoan thanh cong");
                LoadAccountList();
            }
            else
                MessageBox.Show("Da xay ra loi khi them tai khoan");
            passwordTb.Text = "";
            confirmPasswordTb.Text = "";
        }

        private void updateAccountBtn_Click(object sender, EventArgs e)
        {
            if (userNameTb.Text == "" || personNametb.Text == "" || phoneNumberTb.Text == "" || passwordTb.Text == "" || cbPositionAccount.Text == ""||confirmPasswordTb.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi them tai khoan\nHay dien day du thong tin");
                return;
            }
            string username = userNameTb.Text;
            string name = personNametb.Text;
            string phoneNumber = phoneNumberTb.Text;
            string password = passwordTb.Text;
            string position = cbPositionAccount.Text;
            string confirmPassword = confirmPasswordTb.Text;
            int positionValue = cbPositionAccount.SelectedIndex + 1;
            bool checkUpdate=ManageDAO.Instance.UpdateAccount(username, name,phoneNumber,password,position, positionValue,confirmPassword);
            if (checkUpdate)
            {
                MessageBox.Show("Cap nhat tai khoan thanh cong");
                LoadAccountList();
            }
            else
                MessageBox.Show("Da xay ra loi khi cap nhat tai khoan");
            passwordTb.Text = "";
            confirmPasswordTb.Text = "";
        }

        private void deleteAccountBtn_Click(object sender, EventArgs e)
        {
            if (userNameTb.Text == "")
            {
                MessageBox.Show("Da xay ra loi khi them tai khoan\nHay dien day du thong tin");
                return;
            }
            string confirmPassword = confirmPasswordTb.Text;
            string username = userNameTb.Text;
            bool checkDelete = ManageDAO.Instance.deleteAccount(username, confirmPassword);
            if(checkDelete) 
            {
                MessageBox.Show("Xoa tai khoan thanh cong");
                LoadAccountList();
            }
            else
                MessageBox.Show("Da xay ra loi khi xoa tai khoan");
            passwordTb.Text = "";
            confirmPasswordTb.Text = "";

        }

        private void findInventoryBtn_Click(object sender, EventArgs e)
        {
            string Itemfind=findInventoryTb.Text;
            Inventory item = new Inventory(Itemfind);
            if (item.ID == -1)
            {
                MessageBox.Show("Ten can tim khong ton tai\nHay nhap lai");
                return;
            }
            idInventoryTb.Text = item.ID.ToString();
            amountInventoryTb.Text = item.Amount.ToString();
            drinkNameInventoryTb.Text = item.Name;
            findInventoryTb.Text = "";
        }

        private void fManager_Load(object sender, EventArgs e)
        {

        }

        private void findDrinkBtn_Click(object sender, EventArgs e)
        {
            string itemFind=findDrinkTb.Text;
            Drink item = new Drink(itemFind);
            if(item.ID == -1) 
            {
                MessageBox.Show("Do uong can tim khong ton tai\nHay thu lai ");
                return;
            }
            idDrinkTb.Text = item.ID.ToString();
            drinkNameDrinkTb.Text = item.Name;
            priceDrinkTb.Text=item.Price.ToString();
            findDrinkTb.Text = "";
        }

        private void findTableBtn_Click(object sender, EventArgs e)
        {
            string itemFind = findTableTb.Text;
            Table item = new Table(itemFind);
            if(item.ID == -1) 
            {
                MessageBox.Show("Ban can tim khong ton tai\nHay thu lai");
                return;
            }
            idTableTb.Text = item.ID.ToString();
            tableNameTb.Text=item.Name;
            cbStatusTable.Text = item.Status.ToString();
            findTableTb.Text = "";
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            string perFind=findAccountTb.Text;
            Account per = new Account(perFind);
            if(per.Name=="")
            {
                MessageBox.Show("Tai khoan khong ton tai\nHay thu lai");
                return;
            }
            userNameTb.Text = per.UserName;
            personNametb.Text = per.Name;
            phoneNumberTb.Text = per.PhoneNumber;
            cbPositionAccount.Text=per.Type.ToString();
            findAccountTb.Text = "";
        }

        private void showFeedbackBtn_Click(object sender, EventArgs e)
        {
            if (idBillLb.Text == "")
            {
                MessageBox.Show("Hay chon bill de xem feedback");
                return;
            }
            Feedback customerfb = new Feedback(int.Parse(idBillLb.Text));
            MessageBox.Show(customerfb.ToString());
        }
    }
}
