using StudentExam.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для AddCafPage.xaml
    /// </summary>
    public partial class AddCafPage : Page
    {
        public static List<Cafedra> cafedras { get; set; }
        Employee nameZavCaf = new Employee();
        Cafedra cafedra = new Cafedra();
        public AddCafPage(Employee currentUser)
        {
            InitializeComponent();
            nameZavCaf = currentUser;
            FacultyComboBox.ItemsSource = Connection.UchebnayaPracticeEntities.Cafedra.ToList();

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZavKafPage(nameZavCaf));
        }

        private void AddCafButton_Click(object sender, RoutedEventArgs e)
        {
            cafedras = new List<Cafedra>(Connection.UchebnayaPracticeEntities.Cafedra.ToList());

            string abbCaf = AbbTextBox.Text.Trim();
            string nameCaf = NameCafTextBox.Text.Trim();
            string facID = (FacultyComboBox.SelectedItem as Faculty).AbbrID;
            try
            {
                if (abbCaf != null && nameCaf != null && facID != null)
                {
                    cafedra.CipherID = abbCaf;
                    cafedra.Name = nameCaf;
                    cafedra.AbbrID = facID;

                    Connection.UchebnayaPracticeEntities.Cafedra.Add(cafedra);
                    Connection.UchebnayaPracticeEntities.SaveChanges();

                    AddCafButton.Background = Brushes.Green;
                }
                else
                    AddCafButton.Background = Brushes.Red;
            }
            catch
            {
                AddCafButton.Background = Brushes.Red;
            }
        }

        private void FacultyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

