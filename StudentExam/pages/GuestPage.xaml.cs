using StudentExam.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        public static List<Speciality> specialities { get; set; }
        public GuestPage()
        {
            InitializeComponent();
            specialities = new List<Speciality>(Connection.UchebnayaPracticeEntities.Speciality.ToList());
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
