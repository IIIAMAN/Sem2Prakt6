using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prakticheskaya_6
{
    public partial class User : Window
    {
        private Socket socket;
        private CancellationTokenSource isWorking;
        string Name_podkl;
        private string ClientId;


        public User(string user, string ip)
        {
            InitializeComponent();
            Name_podkl = user;
            ClientId = Guid.NewGuid().ToString();
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ip, 8888);
                RecieveMessage(user);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения");

            }
            send(" ");
        }

        private async Task RecieveMessage(string user)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(bytes, SocketFlags.None);


                string json = Encoding.UTF8.GetString(bytes);
                Dictionary<string, string> userNames = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach (var kvp in userNames)
                {
                    string userName = kvp.Key;
                    string message_recieve = kvp.Value;
                    List<string> AlU = new List<string>();
                    if (message_recieve == "/AllUsers")
                    {
                        AlU.Add(userName);
                    }
                    else
                    {
                        ChatList.Items.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {userName}: {message_recieve}");
                    }
                    if (message_recieve == "/disconnect")
                    {
                        MessageBox.Show("Сервер завершил сессию");
                        this.Close();
                    }
                    foreach (var item in AlU)
                    {
                        UserList.Items.Add(item);
                    }
                    AlU.Clear();
                    foreach (var item in UserList.Items)
                    {
                        if (item != userName)
                        {

                            break;
                        }
                    }
                }
            }
        }

        private async Task send(string msg)
        {
            Dictionary<string, string> messageData = new Dictionary<string, string>();
            messageData.Add(Name_podkl, msg);

            string json = JsonConvert.SerializeObject(messageData);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            await socket.SendAsync(bytes, SocketFlags.None);
            messageData.Clear();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageText.Text = "/disconnect";
            MainWindow mainWindow = new MainWindow();
            send(MessageText.Text);
            this.Close();

            return;
        }

        private void OtpravitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageText.Text == "/disconnect")
            {
                MainWindow mainWindow = new MainWindow();

                send(MessageText.Text);
                MessageText.Text = "";
                this.Close();
                return;
            }
            else
            {
                send(MessageText.Text);
            }


        }

        private void Client_window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow dd = new MainWindow();

            send("/disconnect");

            e.Cancel = false;
            dd.Show();
            return;

        }
    }
}