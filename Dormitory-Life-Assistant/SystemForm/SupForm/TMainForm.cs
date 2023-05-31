using Dormitory_Life_Assistant;
using Sunny.UI;

namespace SystemForm

{
    public partial class TMainForm : UIForm
    {
        // supervisor�ǵ�¼������supervisor��Ҫһֱ��Ϊ�����������н���
        private Supervisor supervisor = new Supervisor("1", "BBT��������");
        public TMainForm()
        {
            InitializeComponent();

            Choice.TabControl = MainContainer;
            //����ҳ�浽Main
            AddPage(new TMySelfForm(), 1001);
            AddPage(new TStudentForm(supervisor), 1002);
            AddPage(new TBreakdownForm(), 1003);
            AddPage(new TCostForm(), 1004);
            AddPage(new TComplaintForm(), 1005);
            AddPage(new TInformationForm(supervisor), 1006);
            AddPage(new Setting(), 1007);



            //����Header�ڵ�����
            Choice.CreateNode("�ҵ���Ϣ", 1001);
            Choice.CreateNode("ѧ����Ϣ", 1002);
            Choice.CreateNode("������Ϣ", 1003);
            Choice.CreateNode("Ƿ����Ϣ", 1004);
            Choice.CreateNode("�ٱ���Ϣ", 1005);
            Choice.CreateNode("֪ͨ����", 1006);
            Choice.CreateNode("�û�����", 1007);



            //��ʾĬ�Ͻ���
            Choice.SelectFirst();
        }
    }
}