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
    /// Логика взаимодействия для ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        ChatBDEntities bd = new ChatBDEntities();
        MainWindow f1 = (MainWindow)Application.Current.MainWindow;

        public ChatWindow()
        {
            InitializeComponent();
            NameUser.Text = f1.NameUser.Text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var c = bd.Chatt.Where(z => z.Name_Chat != null).ToArray().Reverse().ToArray();
            int n = c.Count();
            if (n != 0)
            {
                do
                {
                    Button NameChat = new Button();
                    NameChat.Margin = new Thickness(0, 0, 0, 5);
                    NameChat.Height = 35;
                    NameChat.Padding = new Thickness(5, 0, 5, 0);
                    NameChat.FontSize = 17;
                    NameChat.Content = c[n - 1].Name_Chat.ToString();
                    NameChat.Click += NameChat_Click;

                    ChatSP.Children.Add(NameChat);

                    n--;
                } while (n > 0);
            }

            var u = bd.User.Where(z => z.Name_User != null).ToArray().Reverse().ToArray();
            int nU = u.Count();
            if (nU != 0)
            {
                do
                {
                    Button nameUser = new Button();
                    nameUser.Margin = new Thickness(0, 0, 10, 0);
                    nameUser.Height = 35;
                    nameUser.Padding = new Thickness(5, 0, 5, 0);
                    nameUser.FontSize = 17;
                    nameUser.Content = u[nU - 1].Name_User.ToString();
                    nameUser.Click += NameUser_Click;

                    UserSP.Children.Add(nameUser);

                    nU--;
                } while (nU > 0);
            }
        }

        private void NameUser_Click(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            NameUser.Text = but.Content.ToString();

            MainSP.Children.Clear();

            var a = bd.Message.Where(z => z.Name_Chat == NameChat.Text).ToArray().Reverse().ToArray();
            int b = a.Count();
            if (b != 0)
            {
                do
                {
                    Border bor = new Border();
                    bor.BorderBrush = Brushes.Black;
                    bor.BorderThickness = new Thickness(1);
                    bor.CornerRadius = new CornerRadius(5);
                    bor.Margin = new Thickness(0, 10, 0, 10);
                    bor.MaxWidth = 400;
                    if (a[b - 1].Name_User == NameUser.Text)
                    {
                        bor.HorizontalAlignment = HorizontalAlignment.Right;
                        bor.Background = Brushes.LightBlue;
                    }
                    else
                    {
                        bor.HorizontalAlignment = HorizontalAlignment.Left;
                        bor.Background = Brushes.LightGreen;
                    }

                    Grid gri = new Grid();
                    gri.Margin = new Thickness(10);

                    TextBlock nameUser = new TextBlock();
                    nameUser.Text = a[b - 1].Name_User.ToString();
                    nameUser.FontSize = 15;
                    nameUser.VerticalAlignment = VerticalAlignment.Top;

                    TextBlock TextMessage = new TextBlock();
                    TextMessage.Text = a[b - 1].Text_Message.ToString();
                    TextMessage.FontSize = 19;
                    TextMessage.TextWrapping = TextWrapping.Wrap;
                    TextMessage.VerticalAlignment = VerticalAlignment.Top;
                    TextMessage.Margin = new Thickness(0, 30, 0, 0);

                    MainSP.Children.Add(bor);
                    bor.Child = gri;
                    gri.Children.Add(nameUser);
                    gri.Children.Add(TextMessage);

                    b--;
                } while (b > 0);
            }
        }

        private void NameChat_Click(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;

            NameChat.Text = but.Content.ToString();

            MainSP.Children.Clear();

            var a = bd.Message.Where(z => z.Name_Chat == but.Content.ToString()).ToArray().Reverse().ToArray();
            int b = a.Count();
            if (b != 0)
            {
                do
                {
                    Border bor = new Border();
                    bor.BorderBrush = Brushes.Black;
                    bor.BorderThickness = new Thickness(1);
                    bor.CornerRadius = new CornerRadius(5);
                    bor.Margin = new Thickness(0, 10, 0, 10);
                    bor.MaxWidth = 400;
                    if (a[b - 1].Name_User == NameUser.Text)
                    {
                        bor.HorizontalAlignment = HorizontalAlignment.Right;
                        bor.Background = Brushes.LightBlue;
                    }
                    else
                    {
                        bor.HorizontalAlignment = HorizontalAlignment.Left;
                        bor.Background = Brushes.LightGreen;
                    }

                    Grid gri = new Grid();
                    gri.Margin = new Thickness(10);

                    TextBlock nameUser = new TextBlock();
                    nameUser.Text = a[b - 1].Name_User.ToString();
                    nameUser.FontSize = 15;
                    nameUser.VerticalAlignment = VerticalAlignment.Top;

                    TextBlock TextMessage = new TextBlock();
                    TextMessage.Text = a[b - 1].Text_Message.ToString();
                    TextMessage.FontSize = 19;
                    TextMessage.TextWrapping = TextWrapping.Wrap;
                    TextMessage.VerticalAlignment = VerticalAlignment.Top;
                    TextMessage.Margin = new Thickness(0, 30, 0, 0);

                    MainSP.Children.Add(bor);
                    bor.Child = gri;
                    gri.Children.Add(nameUser);
                    gri.Children.Add(TextMessage);

                    b--;
                } while (b > 0);
            }
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            Message message = new Message()
            {
                Text_Message = TextMessage.Text,
                Name_User = NameUser.Text,
                Name_Chat = NameChat.Text
            };
            bd.Message.Add(message);
            bd.SaveChanges();

            TextMessage.Text = "";

            MainSP.Children.Clear();

            var a = bd.Message.Where(z => z.Name_Chat == NameChat.Text).ToArray().Reverse().ToArray();
            int b = a.Count();
            if (b != 0)
            {
                do
                {
                    Border bor = new Border();
                    bor.BorderBrush = Brushes.Black;
                    bor.BorderThickness = new Thickness(1);
                    bor.CornerRadius = new CornerRadius(5);
                    bor.Margin = new Thickness(0, 10, 0, 10);
                    bor.MaxWidth = 400;
                    if (a[b - 1].Name_User == NameUser.Text)
                    {
                        bor.HorizontalAlignment = HorizontalAlignment.Right;
                        bor.Background = Brushes.LightBlue;
                    }
                    else
                    {
                        bor.HorizontalAlignment = HorizontalAlignment.Left;
                        bor.Background = Brushes.LightGreen;
                    }

                    Grid gri = new Grid();
                    gri.Margin = new Thickness(10);

                    TextBlock nameUser = new TextBlock();
                    nameUser.Text = a[b - 1].Name_User.ToString();
                    nameUser.FontSize = 15;
                    nameUser.VerticalAlignment = VerticalAlignment.Top;

                    TextBlock TextMessage = new TextBlock();
                    TextMessage.Text = a[b - 1].Text_Message.ToString();
                    TextMessage.FontSize = 19;
                    TextMessage.TextWrapping = TextWrapping.Wrap;
                    TextMessage.VerticalAlignment = VerticalAlignment.Top;
                    TextMessage.Margin = new Thickness(0, 30, 0, 0);

                    MainSP.Children.Add(bor);
                    bor.Child = gri;
                    gri.Children.Add(nameUser);
                    gri.Children.Add(TextMessage);

                    b--;
                } while (b > 0);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MainSP.Children.Clear();

            var a = bd.Message.Where(z => z.Name_Chat == NameChat.Text).ToArray().Reverse().ToArray();
            int b = a.Count();
            if (b != 0)
            {
                do
                {
                    Border bor = new Border();
                    bor.BorderBrush = Brushes.Black;
                    bor.BorderThickness = new Thickness(1);
                    bor.CornerRadius = new CornerRadius(5);
                    bor.Margin = new Thickness(0, 10, 0, 10);
                    bor.MaxWidth = 400;
                    if (a[b - 1].Name_User == f1.NameUser.Text)
                    {
                        bor.HorizontalAlignment = HorizontalAlignment.Right;
                        bor.Background = Brushes.LightBlue;
                    }
                    else
                    {
                        bor.HorizontalAlignment = HorizontalAlignment.Left;
                        bor.Background = Brushes.LightGreen;
                    }

                    Grid gri = new Grid();
                    gri.Margin = new Thickness(10);

                    TextBlock NameUser = new TextBlock();
                    NameUser.Text = a[b - 1].Name_User.ToString();
                    NameUser.FontSize = 15;
                    NameUser.VerticalAlignment = VerticalAlignment.Top;

                    TextBlock TextMessage = new TextBlock();
                    TextMessage.Text = a[b - 1].Text_Message.ToString();
                    TextMessage.FontSize = 19;
                    TextMessage.TextWrapping = TextWrapping.Wrap;
                    TextMessage.VerticalAlignment = VerticalAlignment.Top;
                    TextMessage.Margin = new Thickness(0, 30, 0, 0);

                    MainSP.Children.Add(bor);
                    bor.Child = gri;
                    gri.Children.Add(NameUser);
                    gri.Children.Add(TextMessage);

                    b--;
                } while (b > 0);
            }

            ChatSP.Children.Clear();

            var c = bd.Chatt.Where(z => z.Name_Chat != null).ToArray().Reverse().ToArray();
            int n = c.Count();
            if (n != 0)
            {
                do
                {
                    Button NameChat = new Button();
                    NameChat.Margin = new Thickness(0, 0, 0, 5);
                    NameChat.Height = 35;
                    NameChat.Padding = new Thickness(5, 0, 5, 0);
                    NameChat.FontSize = 17;
                    NameChat.Content = c[n - 1].Name_Chat.ToString();
                    NameChat.Click += NameChat_Click;

                    ChatSP.Children.Add(NameChat);

                    n--;
                } while (n > 0);
            }
        }

        private void NewChat_Click(object sender, RoutedEventArgs e)
        {
            Window newChat = new NewChatWindow();
            newChat.Show();
        }
    }
}
