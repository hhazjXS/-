using Sunny.UI;
using Dormitory_Life_Assistant;
using Dormitory_Life_Assistant.Service;
using System.Xml.Linq;

namespace SystemForm
{
    public partial class StudentEdit : UIForm
    {
        public Student student { get; set; }
        public StudentService studentService { get; set; }
        public StudentEdit(Student student, StudentService studentService)
        {
            InitializeComponent();
            this.student = student;
            if (student != null)
            {
                IdBox.Text = student.StudentId;
                nameBox.Text = student.Name;
                gradeBox.Text = student.Grade;
                genderBox.Text = student.Gender;
                dormBox.Text = student.DormNumber;
                departmentBox.Text = student.Department;
                passwordBox.Text = student.Password;
                buildingNameBox.Text = student.BuildingName;
                classBox.Text = student.Class;
            }
            this.studentService = studentService;
        }
        public bool checkStu(Student student)
        {
            if (student.StudentId != " " && student.Name != " " && student.Department != " " && student.Grade != " " && student.Class != " " &&
                student.DormNumber != " " && student.BuildingName != " " && student.Password != " " && student.Gender != " ") { }
            return true;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            Student newStudent = new Student(IdBox.Text, nameBox.Text, gradeBox.Text, departmentBox.Text, dormBox.Text, classBox.Text, genderBox.Text, passwordBox.Text, buildingNameBox.Text);
            UIMessageBox.Show("�Ƿ�ȷ�����Ĳ���");

            using (var ctx = new SystemContext())
            {
                var student = ctx.Students
                    .SingleOrDefault(s => s.StudentId == newStudent.StudentId);

                if (student == null)
                {
                    if (checkStu(newStudent))
                    {
                        studentService.AddStudent(newStudent);
                        UIMessageBox.Show("��ӳɹ�");
                        this.Close();
                    }
                    else { UIMessageBox.Show("ѧ����Ϣ�������п�ֵ������������"); }
                }
                else
                {
                    UIMessageBox.Show("��ѧ���Ѵ��ڣ�����������");
                }
            }

        }
    }
}