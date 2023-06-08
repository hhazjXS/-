using Dormitory_Life_Assistant;
using Sunny.UI;

namespace SystemForm
{
    public partial class RegisterForm : UIForm
    {
        public RegisterForm()
        {
            InitializeComponent();


        }

        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            char c = new char();
            if (PasswordCheckBox.Checked)
            {
                PasswordTextBox.PasswordChar = c;
            }
            else
            {
                PasswordTextBox.PasswordChar = '*';
            }
        }

        private void RePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            char c = new char();
            if (RePasswordCheckBox.Checked)
            {
                RePasswordTextBox.PasswordChar = c;
            }
            else
            {
                RePasswordTextBox.PasswordChar = '*';
            }
        }

        private void RePasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text != RePasswordTextBox.Text)
            {
                RemindLabel.Text = "������������벻��ȣ�����������";
                RemindLabel.ForeColor = Color.Red;
            }
            else
            {
                RemindLabel.Text = " ";
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text != RePasswordTextBox.Text)
            {
                RemindLabel.Text = "������������벻��ȣ�����������";
                RemindLabel.ForeColor = Color.Red;
            }
            else
            {
                RemindLabel.Text = " ";
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                user auser = new user();    
                if(StudentRadioButton.Checked) { auser = new user(1,IDTextBox.Text, PasswordTextBox.Text); }
                else if (TeacherRadioButton.Checked) { auser = new user(2, IDTextBox.Text, PasswordTextBox.Text); }
                else if(ManagerRadioButton3.Checked) { auser = new user(3, IDTextBox.Text, PasswordTextBox.Text); }
                else
                {
                    RemindLabel.Text = "��ѡ��������";
                    RemindLabel.ForeColor = Color.Red;
                    return;
                }
                using (var ctx = new SystemContext())
                {
                    ctx.Entry(auser).State = System.Data.Entity.EntityState.Added;
                    ctx.SaveChanges();
                }
                RemindLabel.Text = "ע��ɹ�";
                RemindLabel.ForeColor = Color.Green;
            }
            catch
            {
                RemindLabel.Text = "�û��Ѵ���";
                RemindLabel.ForeColor = Color.Red;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}