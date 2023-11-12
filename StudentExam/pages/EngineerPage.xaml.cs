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
        public static Employee selectedEmployee;
        Employee nameEng = new Employee();

        public EngineerPage(Employee currentUser)
        {
            InitializeComponent();
            employees = new List<Employee>(Connection.UchebnayaPracticeEntities.Employee.ToList());

            nameEng = currentUser;

            EngineerNameTB.Text += $" {nameEng.Surname}";
            DataContext = this;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void AddButtonEmployee_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployee(nameEng));
        }

        private void DisciplineListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEmployee = DisciplineListView.SelectedItem as Employee;
            NavigationService.Navigate(new EditEmployeePage(nameEng));
        }
    }
}
