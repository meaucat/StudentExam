using StudentExam.DB;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

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
            NavigationService.Navigate(new GuestPage());
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            employees = new List<Employee>(Connection.UchebnayaPracticeEntities.Employee.ToList());
            Employee currentUser = employees.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (currentUser != null)
            {
                if (currentUser.Position == "зав. кафедрой")
                    NavigationService.Navigate(new ZavKafPage(currentUser));
                if (currentUser.Position == "преподаватель")
                    NavigationService.Navigate(new TeacherPage(currentUser));
                if (currentUser.Position == "инженер")
                    NavigationService.Navigate(new EngineerPage(currentUser));

            }
            else
                LoginBtn.Background = System.Windows.Media.Brushes.Red;
            CheckLoginTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            CheckLoginTextBlock.Text = "Что-то введено неверно, попробуйте еще раз";
        }

        private void QRcodeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Ссылка на XL таблицу
            string soucer_xl = "https://www.youtube.com/watch?v=8Zn89VJ01jQ";
            // Создание переменной библиотеки QRCoder
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            // Присваеваем значиения
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
            // переводим в Qr
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            /// Создание картинки
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                imageQr.Source = bitmapimage;
            }
        }
    }
}
