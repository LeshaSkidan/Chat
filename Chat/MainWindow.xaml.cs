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
using Chat.Model;

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChatBDEntities bd = new ChatBDEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            var a = bd.User.Where(z => z.Name_User == NameUser.Text && z.Password_User == PasswordUser.Password).FirstOrDefault();
            if (a == null)
            {
                User user = new User()
                {
                    Name_User = NameUser.Text,
                    Password_User = PasswordUser.Password
                };
                bd.User.Add(user);
                bd.SaveChanges();

                MessageBox.Show("Вы зарегистрировались!");

                Window chatWindow = new ChatWindow();
                chatWindow.Show();
            }
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            var a = bd.User.Where(z => z.Name_User == NameUser.Text && z.Password_User == PasswordUser.Password).FirstOrDefault();
            if (a != null)
            {
                MessageBox.Show("Вы авторизовались!");

                Window chatWindow = new ChatWindow();
                chatWindow.Show();
            }
        }
    }
}
