using Sunny.UI;
using Dormitory_Life_Assistant;

namespace SystemForm
{
    public partial class StudentForm : UIForm
    {
        public StudentForm()
        {
            InitializeComponent();
            //�ȴ���һ��ѧ��������������,�������ݿ����һ��������������
            Student stu = new Student("2021302111113", "C4-308");
            /*using (var ctx = new SystemContext())
            {
                ctx.Dorms.Add(new Dorm("C4-308"));
                ctx.SaveChanges();
            }*/

            Choice.TabControl = MainContainer;
            //����ҳ�浽Main
            AddPage(new stuMain(), 1001);
            AddPage(new StuLifePay(stu), 1002);
            AddPage(new stuRepair(stu), 1003);
            AddPage(new StuTreeHole(), 1004);
            AddPage(new StuPunch(), 1005);
            AddPage(new StuMessage(), 1006);
            AddPage(new StuComplaint(), 1008);
            AddPage(new Setting(), 1009);


            //����Header�ڵ�����
            Choice.CreateNode("�ҵ���ҳ", 1001);
            Choice.CreateNode("����ɷ�", 1002);
            Choice.CreateNode("���ϱ���", 1003);
            Choice.CreateNode("����", 1004);
            Choice.CreateNode("��", 1005);
            Choice.CreateNode("��Ϣ", 1006);
            Choice.CreateNode("Ͷ�߾ٱ�", 1008);
            Choice.CreateNode("�û�����", 1009);


            //��ʾĬ�Ͻ���
            Choice.SelectFirst();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}