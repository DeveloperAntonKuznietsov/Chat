using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace Chat_0._7
{
  
    public partial class MainWindow : Window
    {

        public static IChattingService Server;
        private static DuplexChannelFactory<IChattingService> channelFactory;

        public MainWindow()
        {
            InitializeComponent();
            channelFactory = new DuplexChannelFactory<IChattingService>(new ClientCallback(), "ChattingServiceEndPoint");
            Server = channelFactory.CreateChannel();

        }

       public void TakeMessage( string message, string userName)
        {
            txtChat.Text += userName + ": " + message + "\n";
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Server.SendMessageToAll(txtsend.Text, txtUserName.Text);
            TakeMessage(txtsend.Text, txtUserName.Text);
            txtsend.Text = "";

        }

        private void bntLogin_Click(object sender, RoutedEventArgs e)
        {
            int returnValue = Server.Login(txtUserName.Text);

            if (returnValue == 1)
            {

                MessageBox.Show("You are already logged in. Try again");
               
            }
            else if(returnValue == 0)
            {
                MessageBox.Show("You logged in");
                txtUserName.IsEnabled = false;
                bntLogin.IsEnabled = false;
            }
        }
    }
}
