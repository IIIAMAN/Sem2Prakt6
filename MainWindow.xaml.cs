using MaterialDesignThemes.Wpf;
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

namespace Prakticheskaya_6
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewChat_Click(object sender, RoutedEventArgs e)
        {
            Validation validation = new Validation();

            if (validation.Validation1(NameUser.Text) == true)
            {
                Host host = new Host(NameUser.Text, IpText.Text);
                host.Show();
                Close();
            }
        }

        private void JoinToChat_Click(object sender, RoutedEventArgs e)
        {
            Validation validation = new Validation();

            if (validation.Validation1(NameUser.Text) == true)
            {
                if (validation.Validation2(IpText.Text) == true)
                {
                    User user = new User(NameUser.Text, IpText.Text);
                    user.Show();
                    Close();
                }
            }
        }
    }
}