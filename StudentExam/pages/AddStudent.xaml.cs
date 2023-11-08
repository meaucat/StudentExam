using StudentExam.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        Employee nameTeacher = new Employee();
        public static List<Student> students { get; set; }

        public AddStudent(Employee currentUser, Exam exam)
        {
            InitializeComponent();
            students = new List<Student>(Connection.UchebnayaPracticeEntities.Student.ToList());

            nameTeacher = currentUser;

            ExamNameTB.Text = exam.Discipline.Name;
            ExamDateTB.Text = exam.ExamDate.ToString();



            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherPage(nameTeacher));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
