using StudentExam.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для ZavKafPage.xaml
    /// </summary>
    public partial class ZavKafPage : Page
    {
        public static List<Cafedra> departaments { get; set; }
        Employee nameZavCaf = new Employee();
        public ZavKafPage(Employee currentUser)
        {
            InitializeComponent();
            departaments = new List<Cafedra>(Connection.UchebnayaPracticeEntities.Cafedra.ToList());

            nameZavCaf = currentUser;

            ZavCafNameTB.Text += $" {nameZavCaf.Surname}";

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }


    }
}
