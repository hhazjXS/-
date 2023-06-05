using Dormitory_Life_Assistant;
using Sunny.UI;

namespace SystemForm
{
    public partial class CostChildForm : UIForm
    {
        string SelectedDormID;
        PaymentService paymentService = new PaymentService();
        List<Payment> bindingPaymentList = new List<Payment>();

        public CostChildForm(string selectedDormID)
        {
            InitializeComponent();
            SelectedDormID = selectedDormID;//��ѡ����Ҫ��ѯ�Ľɷ���Ϣ���������Ϊ��������
            bindingPaymentList = paymentService.getPaymentListByDorm(selectedDormID);
            uiDataGridView1.DataSource = bindingPaymentList;//������
        }

        private void uiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RemindButton_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel5_Click(object sender, EventArgs e)
        {

        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //ɾ���ɷѵ�
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (SelectedDormID != null)
            {
                paymentService.deleteBill(SelectedDormID);
            }
            bindingPaymentList = paymentService.getPaymentListByDorm(SelectedDormID);
            uiDataGridView1.DataSource = bindingPaymentList;//������
            uiDataGridView1.Refresh();

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (SelectedDormID != null)
            {
                paymentService.modifyBill(SelectedDormID);
            }
            bindingPaymentList = paymentService.getPaymentListByDorm(SelectedDormID);
            uiDataGridView1.DataSource = bindingPaymentList;//������
            uiDataGridView1.Refresh();

        }
    }
}