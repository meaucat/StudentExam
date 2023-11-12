using StudentExam.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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

        private void addButtonDiscipline_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDisciplinePage(nameZavCaf));
        }

        private void DisciplineListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new EditDisciplinePage(DisciplineListView.SelectedItem as Speciality, nameZavCaf));
        }
    }
}
