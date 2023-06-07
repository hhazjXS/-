using System.Data;
using System.Data.Entity;
using System.Windows.Forms;
using Dormitory_Life_Assistant;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using Sunny.UI;


namespace SystemForm
{
    public partial class LogInForm : UIForm
    {
        public LogInForm()
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
        public List<user> QueryuserByusername(int number,string ausername)
        {
            using (var ctx = new SystemContext())
            {
                if(number == 1)
                {
                    return ctx.Users
                    .Where(message => message.studentusername.Equals(ausername))
                    .ToList();
                }
                else if (number == 2)
                {
                    return ctx.Users
                    .Where(message => message.tmainusername.Equals(ausername))
                    .ToList();
                }
                else
                {
                    return ctx.Users
                    .Where(message => message.adminusername.Equals(ausername))
                    .ToList();
                }
            }
        }
        public List<Student> QueryStudentByusername(string ausername)
        {
            using (var ctx = new SystemContext())
            {
                return ctx.Students
                  .Where(message => message.StudentId.Equals(ausername))
                  .ToList();
            }
        }
        public List<Supervisor> QuerySupervisorByusername(string ausername)
        {
            using (var ctx = new SystemContext())
            {
                return ctx.Supervisors
                  .Where(message => message.SupervisorId.Equals(ausername))
                  .ToList();
            }
        }
        public List<Administrator> QueryAdministratorByusername(string ausername)
        {
            using (var ctx = new SystemContext())
            {
                return ctx.Administrators
                  .Where(message => message.AdministratorId.Equals(ausername))
                  .ToList();
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {

            if (IDTextBox.Text == "")
            {
                RemindLabel.Text = "�û���/ID����Ϊ��";
                RemindLabel.ForeColor = Color.Red;
            }
            else if (PasswordTextBox.Text == "")
            {
                RemindLabel.Text = "���벻��Ϊ��";
                RemindLabel.ForeColor = Color.Red;
            }
            else
            {
                List<user> users = new List<user>();
                if (StudentRadioButton.Checked) { users = QueryuserByusername(1,IDTextBox.Text); }
                else if (TeacherRadioButton.Checked) { users = QueryuserByusername(2,IDTextBox.Text); }
                else if (ManagerRadioButton3.Checked) { users = QueryuserByusername(3,IDTextBox.Text); }
                else
                {
                    RemindLabel.Text = "��ѡ��������";
                    RemindLabel.ForeColor = Color.Red;
                    return;
                }

                
                if (users.Count == 0)
                {
                    RemindLabel.Text = "��½ʧ�ܣ��û���������";
                    RemindLabel.ForeColor = Color.Red;
                }
                else if ((StudentRadioButton.Checked&&users[0].studentpassword != PasswordTextBox.Text)||
                    (TeacherRadioButton.Checked && users[0].tmainpassword != PasswordTextBox.Text)||
                    (ManagerRadioButton3.Checked && users[0].adminpassword != PasswordTextBox.Text)
                    )
                {
                    RemindLabel.Text = "��½ʧ�ܣ������������������";
                    RemindLabel.ForeColor = Color.Red;
                }
                else
                {
                    
                    RemindLabel.Text = "��½�ɹ�";
                    RemindLabel.ForeColor = Color.Green;
                    if (StudentRadioButton.Checked)
                    {
                        List<Student> students = QueryStudentByusername(IDTextBox.Text);
                        if (students.Count != 0)
                        {
                            
                            StudentForm studentForm = new StudentForm(students[0]);
                            this.Hide();
                            studentForm.ShowDialog();
                            
                        }
                        else
                        {
                            Student student = new Student(IDTextBox.Text);
                            using (var ctx = new SystemContext())
                            {
                                ctx.Entry(student).State = System.Data.Entity.EntityState.Added;
                                ctx.SaveChanges();
                            }
                            
                            StudentForm studentForm = new StudentForm(student);
                            this.Hide();
                            studentForm.ShowDialog();
                            
                        }
                    }
                    else if(TeacherRadioButton.Checked)
                    {
                        List<Supervisor> supervisors = QuerySupervisorByusername(IDTextBox.Text);
                        if (supervisors.Count != 0)
                        {
                            this.Hide();
                            TMainForm tmainForm = new TMainForm(supervisors[0]);
                            tmainForm.ShowDialog();
                        }
                        else
                        {
                            Supervisor supervisor = new Supervisor(IDTextBox.Text);
                            using (var ctx = new SystemContext())
                            {
                                ctx.Entry(supervisor).State = System.Data.Entity.EntityState.Added;
                                ctx.SaveChanges();
                            }
                            this.Hide();
                            TMainForm tmainform = new TMainForm(supervisor);
                            tmainform.ShowDialog();
                        }
                    }
                    else if (ManagerRadioButton3.Checked)
                    {
                        List<Administrator> administrators = QueryAdministratorByusername(IDTextBox.Text);
                        if (administrators.Count != 0)
                        {
                            this.Hide();
                            AdminForm adminForm = new AdminForm(administrators[0]);
                            adminForm.ShowDialog();
                        }
                        else
                        {
                            Administrator administrator = new Administrator(IDTextBox.Text);
                            using (var ctx = new SystemContext())
                            {
                                ctx.Entry(administrator).State = System.Data.Entity.EntityState.Added;
                                ctx.SaveChanges();
                            }
                            this.Hide();
                            AdminForm adminForm = new AdminForm(administrator);
                            adminForm.ShowDialog();
                        }
                    }
                 
                }

                //RemindLabel.Text = "�˺Ų����ڻ��˺������벻ƥ��";
                //RemindLabel.ForeColor = Color.Red;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}