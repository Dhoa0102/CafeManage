using BasicCoffeeShop.DAO;
using System;
using System.Windows.Forms;

namespace BasicCoffeeShop
{
    public partial class FeedbackForm : Form
    {
        public FeedbackForm()
        {
            InitializeComponent();
            labelFeedBack.Text = "Cám ơn khách hàng " + DataStorage.Customer.Name + " đã ủng hộ chúng tôi \n hãy nêu cảm nhận của bạn ";
        }

        private void labelFeedBack_Click(object sender, EventArgs e)
        {

        }

        private void XacNhanBTN_Click(object sender, EventArgs e)
        {
            int idBill = DataStorage.Bill.IDBill;
            string customerName = DataStorage.Customer.Name;
            string detail = feedbackTXB.Text;
            FeedbackDAO.Instance.insertFeedBack(idBill,customerName,detail);
            this.Close();
        }

        private void feedbackTXB_TextChanged(object sender, EventArgs e)
        {

        }

        private void FeedbackForm_Load(object sender, EventArgs e)
        {

        }
    }
}
