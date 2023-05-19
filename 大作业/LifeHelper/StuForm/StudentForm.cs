using Sunny.UI;

namespace LifeHelper
{
    public partial class FCustomMain : UIForm
    {
        public FCustomMain()
        {
            InitializeComponent();

            Choice.TabControl = MainContainer;
            //����ҳ�浽Main
            AddPage(new stuMain(), 1001);
            AddPage(new StuLifePay(), 1002);
            AddPage(new stuRepair(), 1003);
            AddPage(new StuTreeHole(), 1004);
            AddPage(new StuPunch(), 1005);
            AddPage(new StuMessage(), 1006);
            AddPage(new StuTrade(), 1007);
            AddPage(new StuComplaint(), 1008);
            AddPage(new Setting(), 1009);
            

            //����Header�ڵ�����
            Choice.CreateNode("�ҵ���ҳ", 1001);
            Choice.CreateNode("����ɷ�", 1002);
            Choice.CreateNode("���ϱ���", 1003);
            Choice.CreateNode("����", 1004);
            Choice.CreateNode("��", 1005);
            Choice.CreateNode("��Ϣ", 1006);
            Choice.CreateNode("���轻��", 1007);
            Choice.CreateNode("Ͷ�߾ٱ�", 1008);
            Choice.CreateNode("�û�����", 1009);


            //��ʾĬ�Ͻ���
            Choice.SelectFirst();
        }
    }
}