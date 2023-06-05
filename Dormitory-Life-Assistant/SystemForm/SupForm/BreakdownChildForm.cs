using Dormitory_Life_Assistant;
using Sunny.UI;
using System.Windows.Forms;

namespace SystemForm
{
    public partial class BreakdownChildForm : UIForm
    {
        RepairServicce repairServicce = new RepairServicce();
        int SelectRepairId;
        List<Repair> bindRepairList = new List<Repair>();

        public BreakdownChildForm(int selectRepairId)
        {
            InitializeComponent();
            this.SelectRepairId = selectRepairId;
            bindRepairList = repairServicce.getRepairListByRepairId(selectRepairId);
            uiDataGridView1.DataSource = bindRepairList;//������
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisPlayImage(int selectRepairId)
        {
            byte[] imageData = null;
            using (var ctx = new SystemContext())
            {
                var result = ctx.Repairs
                    .SingleOrDefault(s => s.ID == selectRepairId);

                if (result != null)
                {
                    var result1 = ctx.SaveImages
                        .SingleOrDefault(s => s.ImageId == result.ImageId);
                    if (result1 != null)
                    {
                        imageData = result1.ImageData;
                    }
                }


            }

            if (imageData != null)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                }
            }
            else
            {
                // ���δ�ҵ���Ӧ��ͼƬ���ݣ�������ʾĬ�ϵ�ռλͼ��������ʾ��Ϣ
                pictureBox1.Image = null;
                MessageBox.Show("�˱�����δ�ṩͼƬ");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DisPlayImage(this.SelectRepairId);
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            uiDataGridView1.AutoGenerateColumns = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}