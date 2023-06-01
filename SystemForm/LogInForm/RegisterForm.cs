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
    }
}