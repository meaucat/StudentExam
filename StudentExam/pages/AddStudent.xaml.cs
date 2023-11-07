using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentExam.DB;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        Employee nameTeacher = new Employee();
        public AddStudent(Employee currentUser, Exam exam)
        {
            InitializeComponent();
            nameTeacher = currentUser;
            ExamNameTB.Text = exam.Discipline.Name;
            ExamDateTB.Text = exam.ExamDate; 
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherPage(nameTeacher));
        }

        
    }
}
