using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
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
using System.Xml.Linq;

namespace Prakticheskaya_6
{
    public partial class Host : Window
    {
        private Socket socket;
        private List<Socket> clients = new List<Socket>();
        public string adress;
        public string server_name;
        List<string> AllMessage_Logs = new List<string>();
        Dictionary<string, string> Name_IP = new Dictionary<string, string>();

        public Host(string user, string ip)
        {
            server_name = user;
            InitializeComponent();
            ListLogs.Visibility = Visibility.Hidden;
            ListUser.Items.Add(user);
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(20);
            ListenerToUsers();
        }

        private async Task ListenerToUsers()
        {
            while (true)
            {

                var client = await socket.AcceptAsync();
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string name = Encoding.UTF8.GetString(bytes);
                Dictionary<string, string> messageData = JsonConvert.DeserializeObject<Dictionary<string, string>>(name);
                string userName = null;
                string message = null;
                foreach (var kvp in messageData)
                {
                    userName = kvp.Key;
                    message = kvp.Value;
                }
                string ip = ((IPEndPoint)client.RemoteEndPoint).Address.ToString();
                Name_IP[ip] = userName;
                ListLogs.Items.Add(userName + " - пользователь подключился!");
                ListUser.Items.Add(userName);
                clients.Add(client);
                Recieved(client);

                foreach (var item in clients)
                {
                    foreach (var item2 in ListUser.Items)
                    {

                        SendMessage(item, "/AllUsers", item2.ToString());
                    }

                }

            }
        }

        private async Task Recieved(Socket client)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string name = Encoding.UTF8.GetString(bytes);
                Dictionary<string, string> messageData = JsonConvert.DeserializeObject<Dictionary<string, string>>(name);
                string userName = null;
                string message = null;
                foreach (var kvp in messageData)
                {
                    userName = kvp.Key;
                    message = kvp.Value;

                }
                if (message == "/disconnect")
                {
                    string ip = ((IPEndPoint)client.RemoteEndPoint).Address.ToString();
                    string disconnectedUser = Name_IP[ip];
                    ListLogs.Items.Add(disconnectedUser + " - пользователь отключился!");
                    ListUser.Items.Remove(disconnectedUser);
                    clients.Remove(client);
                    Name_IP.Remove(ip);
                }
                ChatList.Items.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {userName}: {message}");
                foreach (var item in clients)
                {
                    SendMessage(item, message, userName);
                }
            }
        }

        private async Task send(string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            await socket.SendAsync(bytes, SocketFlags.None);
        }
        private async Task SendMessage(Socket UsEr, string soobsh, string Name)
        {
            Dictionary<string, string> messageData = new Dictionary<string, string>();
            messageData.Add(Name, soobsh);
            string json = JsonConvert.SerializeObject(messageData);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            await UsEr.SendAsync(bytes, SocketFlags.None);
        }

        private void OtpravitButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in clients)
            {
                SendMessage(item, MessageText.Text, server_name);
            }
            ChatList.Items.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}[{server_name}]: {MessageText.Text}");

            if (MessageText.Text == "/disconnect")
            {
                MainWindow mainWindow = new MainWindow();
                send("/disconnect");
                socket.Close();
            }
            MessageText.Text = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var item in clients)
            {
                SendMessage(item, "/disconnect", server_name);
            }
            MainWindow dd = new MainWindow();
            dd.Show();
            e.Cancel = false;
        }

        private void ExitButton_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            send("/disconnect");
            socket.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ListUser.Visibility = Visibility.Collapsed;
            ChatList.Visibility = Visibility.Collapsed;
            ListLogs.Visibility = Visibility.Visible;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ListUser.Visibility = Visibility.Visible;
            ChatList.Visibility = Visibility.Visible;
            ListLogs.Visibility = Visibility.Collapsed;
        }
    }
}