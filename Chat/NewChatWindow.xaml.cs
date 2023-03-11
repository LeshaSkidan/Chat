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
using System.Windows.Shapes;
using Chat.Model;

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для NewChatWindow.xaml
    /// </summary>
    public partial class NewChatWindow : Window
    {
        ChatBDEntities bd = new ChatBDEntities();

        public NewChatWindow()
        {
            InitializeComponent();
        }

        private void CreateChat_Click(object sender, RoutedEventArgs e)
        {
            if (NameChat.Text != "")
            {
                Chatt chat = new Chatt()
                {
                    Name_Chat = NameChat.Text
                };
                bd.Chatt.Add(chat);
                bd.SaveChanges();

                MessageBox.Show("Чат создан!");

                Close();
            }
            else 
            {
                MessageBox.Show("Заполните поле НАЗВАНИЕ ЧАТА!");
            }
        }
    }
}
