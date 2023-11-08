using StudentExam.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для EngineerPage.xaml
    /// </summary>
    public partial class EngineerPage : Page
    {
        public static List<Employee> employees { get; set; }
        Employee nameEngineer = new Employee();

        public EngineerPage(Employee currentUser)
        {
            InitializeComponent();
            employees = new List<Employee>(Connection.UchebnayaPracticeEntities.Employee.ToList());

            nameEngineer = currentUser;

            EngineerNameTB.Text += $" {nameEngineer.Surname}";
            DataContext = this;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
