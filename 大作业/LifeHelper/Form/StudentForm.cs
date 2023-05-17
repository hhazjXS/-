using Sunny.UI;

namespace LifeHelper
{
    public partial class FCustomMain : UIForm
    {
        public FCustomMain()
        {
            InitializeComponent();

            Choice.TabControl = MainContainer;
            //增加页面到Main
            AddPage(new stuMain(), 1001);
            AddPage(new StuLifePay(), 1002);
            AddPage(new stuRepair(), 1003);
            AddPage(new StuTreeHole(), 1004);
            AddPage(new StuPunch(), 1005);
            AddPage(new StuMessage(), 1006);
            AddPage(new StuComplaint(), 1007);
            AddPage(new Setting(), 1008);
            

            //设置Header节点索引
            Choice.CreateNode("我的主页", 1001);
            Choice.CreateNode("生活缴费", 1002);
            Choice.CreateNode("故障报修", 1003);
            Choice.CreateNode("树洞", 1004);
            Choice.CreateNode("打卡", 1005);
            Choice.CreateNode("消息", 1006);
            Choice.CreateNode("投诉举报", 1007);
            Choice.CreateNode("用户设置", 1008);


            //显示默认界面
            Choice.SelectFirst();
        }
    }
}