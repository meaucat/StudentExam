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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public static List<Exam> exams { get; set; }
        
        public TeacherPage(Employee currentUser)
        {
            InitializeComponent();
            exams = new List<Exam>(Connection.UchebnayaPracticeEntities.Exam.ToList());
            DataContext = this;
            TeacherNameTB.Text = currentUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/AuthorizationPage.xaml", UriKind.Relative));
        }


    }
}
