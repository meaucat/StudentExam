using StudentExam.DB;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для EditDisciplinePage.xaml
    /// </summary>
    public partial class EditDisciplinePage : Page
    {
        Employee nameZavCaf = new Employee();
        public Speciality selectedSpecialization;
        public EditDisciplinePage(Speciality speciality, Employee currentUser)
        {
            InitializeComponent();
            nameZavCaf = currentUser;
            selectedSpecialization = speciality;
            NameDisciplineTextBox.Text = selectedSpecialization.Name;
            IDDisciplineTextBox.Text = selectedSpecialization.SpecialityID;
            DataContext = this;
        }

        private void AddDisciplineButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameDisciplineTextBox != null && IDDisciplineTextBox != null)
                {
                    selectedSpecialization.Name = NameDisciplineTextBox.Text;
                    selectedSpecialization.SpecialityID = IDDisciplineTextBox.Text;
                    Connection.UchebnayaPracticeEntities.SaveChanges();
                    InfoTextBox.Text = "Дисциплина успешно изменена!";
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Connection.UchebnayaPracticeEntities.Speciality.Remove(selectedSpecialization);
            Connection.UchebnayaPracticeEntities.SaveChanges();
            InfoTextBox.Text = "Удаление успешно!";
            InfoTextBox.Foreground = Brushes.Green;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditDeleteDisciplinePage(nameZavCaf));
        }
    }
}
