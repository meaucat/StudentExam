using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
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
using System.Data.Common;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        Employee nameEng = new Employee();

        public static List<Employee> Employees { get; set; }
        public static List<Employee> Position { get; set; }
        public static List<Speciality> Speciality { get; set; }
        public AddEmployee(Employee currentUser)
        {
            InitializeComponent();
            nameEng = currentUser;

            Employees = Connection.UchebnayaPracticeEntities.Employee.ToList();
            Speciality = Connection.UchebnayaPracticeEntities.Speciality.ToList();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EngineerPage(nameEng));
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Salary = int.Parse(SalaryTextBox.Text);
            employee.Surname = SurnameTextBox.Text;
            employee.Chief = (ChefComboBox.SelectedItem as Employee).Chief;
            employee.Cafedra = CafedraComboBox.SelectedItem as Cafedra;
            Connection.UchebnayaPracticeEntities.Employee.Add(employee);
            Connection.UchebnayaPracticeEntities.SaveChanges();
            NavigationService.Navigate(new EngineerPage(nameEng));
        }
    }
}
