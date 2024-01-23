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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BasicCoffeeShop
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void EmployeeLoginBtn_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord=txbPassWord.Text;
            int status = accountDAO.Instance.Status(userName, passWord);
            if (Login(userName, passWord) == true&&status==1)

            {
                /* fTableManager f = new fTableManager();
                 this.Hide();
                 f.ShowDialog(); //chỉ theo tác với fTableManager chỉ khi nào fTableManger đóng mới thao tác tiếp
                 this.Show(); //DiaLog tắt r mới chạy được dòng này*/
                object perName=accountDAO.Instance.GetNameByUserName(userName);
                string personName;
                if (perName == null)
                    personName = "";
                else personName = perName.ToString();
                Manager userManager = new Manager(personName);
                DataStorage.Manager=userManager;
                Customer userCustomer =new Customer("");
                DataStorage.Customer=userCustomer;
                fManager f = new fManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
             }
            else if(Login(userName, passWord) == true && status == 2)
            {
                object perName = accountDAO.Instance.GetNameByUserName(userName);
                string personName;
                if (perName == null)
                    personName = "";
                else personName = perName.ToString();
                Barista userBarista = new Barista(personName);
                DataStorage.Barista= userBarista;
                //DataStorage.baristaName= personName;
                //MessageBox.Show(DataStorage.baristaName);
                fBaristacs f = new fBaristacs();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }    
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
            bool Login(string UserName, string PassWord)
            {
                if (accountDAO.Instance.Login(UserName, PassWord))
                    return true;
                return false;
            }
        }




        private void continueButton_Click(object sender, EventArgs e)
        {
            //COMMENT GHI CHÚ NẾU MUỐN LƯU THÔNG TIN KHÁCH ĐĂNG NHẬP THÌ BỎ DẤU COMMENT addInforTablePerson()
            //addInforTablePerson();
            if (guestNameTB.Text == "")
            {
                MessageBox.Show("Ban hay nhap ten de chung toi co the phuc vu tot hon.");
                return;
            }
            Customer userCustomer = new Customer(guestNameTB.Text);
            DataStorage.Customer = userCustomer;
            loadTableList();        

        }
        void addInforTablePerson()
        {
            string Name = guestNameTB.Text;

            string query = "EXEC USP_PersonLogin @Name , @Type";
            DataProvider.Instance.ExecuteQuery(query, new object[] { Name,"Khách"});
        }
        void loadTableList()
        {
           fTableList f = new fTableList();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guestNameTB_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
