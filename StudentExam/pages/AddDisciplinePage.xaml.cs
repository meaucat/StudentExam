using StudentExam.DB;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для AddDisciplinePage.xaml
    /// </summary>
    public partial class AddDisciplinePage : Page
    {
        Employee nameZavCaf = new Employee();
        public Speciality speciality = new Speciality();
        public AddDisciplinePage(Employee currentUser)
        {
            InitializeComponent();
            nameZavCaf = currentUser;

            DataContext = this;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IDDisciplineTextBox != null && NameDisciplineTextBox != null)
                {
                    speciality.SpecialityID = IDDisciplineTextBox.Text;
                    speciality.Name = NameDisciplineTextBox.Text;
                    Connection.UchebnayaPracticeEntities.Speciality.Add(speciality);
                    Connection.UchebnayaPracticeEntities.SaveChanges();
                    InfoTextBox.Text = "Запись дисциплины успешна!";
                    InfoTextBox.Foreground = Brushes.Green;
                }
                else
                {
                    InfoTextBox.Text = "Заполните все поля!";
                    InfoTextBox.Foreground = Brushes.Red;
                }
            }
            catch
            {
                InfoTextBox.Text = "Заполните все поля!";
                InfoTextBox.Foreground = Brushes.Red;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditDeleteDisciplinePage(nameZavCaf));
        }
    }
}
