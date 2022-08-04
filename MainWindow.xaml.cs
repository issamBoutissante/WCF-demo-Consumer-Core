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

namespace WCFConsumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SayHiServiceReference.SayHiServiceClient SayHIClient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.SayHIClient = new SayHiServiceReference.SayHiServiceClient(SayHiServiceReference.SayHiServiceClient.EndpointConfiguration.NetTcpBinding_ISayHiService);
        }

        private async void CallWCFService_Click(object sender, RoutedEventArgs e)
        {
            this.ServiceReturnMessage.Text = await this.SayHIClient.SayHiAsync(this.UserName.Text);
        }
    }
}
