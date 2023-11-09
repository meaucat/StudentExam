using StudentExam.DB;
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

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для EditDeleteDisciplinePage.xaml
    /// </summary>
    public partial class EditDeleteDisciplinePage : Page
    {
        public static List<Speciality> specialities { get; set; }
        Employee nameZavCaf = new Employee();
        public EditDeleteDisciplinePage(Employee currentUser)
        {
            InitializeComponent();
            specialities = new List<Speciality>(Connection.UchebnayaPracticeEntities.Speciality.ToList());

            nameZavCaf = currentUser;

            ZavCafNameTB.Text += $" {nameZavCaf.Surname}";

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZavKafPage(nameZavCaf));
        }
    }
}
