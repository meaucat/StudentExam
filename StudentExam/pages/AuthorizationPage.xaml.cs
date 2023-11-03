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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Employee> employees { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/GuestPage.xaml", UriKind.Relative));
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = LoginTextBox.Text.Trim();

            employees = new List<Employee>(Connection.UchebnayaPracticeEntities.Employee.ToList());
            Employee currentUser = employees.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (currentUser != null)
                NavigationService.Navigate(new GuestPage());
            else
                LoginBtn.Background = Brushes.Red;
                CheckLoginTextBlock.Foreground = Brushes.Red;
                CheckLoginTextBlock.Text = "Что-то введено неверно, попробуйте еще раз";
        }
    }
}
