using StudentExam.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
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

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        Employee nameEng = new Employee();
        public EditEmployeePage(Employee currentUser)
        {
            InitializeComponent();
            nameEng = currentUser;

            SurnameTextBox.Text = EngineerPage.selectedEmployee.Surname;
            SalaryTextBox.Text = EngineerPage.selectedEmployee.Salary.ToString();
            if (EngineerPage.selectedEmployee.Chief == EngineerPage.selectedEmployee.EmployeeID)
            {
                ChefCheckBox.IsChecked = true;
            }
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EngineerPage(nameEng));
        }

        private void EditEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EngineerPage.selectedEmployee.Surname = SurnameTextBox.Text.Trim();
                EngineerPage.selectedEmployee.Salary = int.Parse(SalaryTextBox.Text.Trim());
                if (ChefCheckBox.IsChecked == true)
                {
                    EngineerPage.selectedEmployee.Chief = EngineerPage.selectedEmployee.EmployeeID;
                }
                else
                {
                    EngineerPage.selectedEmployee.Chief = null;
                }
                Connection.UchebnayaPracticeEntities.SaveChanges();
                InfoTextBox.Text = "Успешно изменено!";
                InfoTextBox.Foreground = Brushes.Green;
            }
            catch
            {
                InfoTextBox.Text = "Вы ввели что-то неверно!";
                InfoTextBox.Foreground = Brushes.Red;
            }

        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
                Connection.UchebnayaPracticeEntities.Employee.Remove(EngineerPage.selectedEmployee);
                Connection.UchebnayaPracticeEntities.SaveChanges();
                NavigationService.Navigate(new EngineerPage(nameEng));
        }
    }
}
