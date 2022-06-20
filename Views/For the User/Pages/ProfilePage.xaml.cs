using HelpDesk.Utils;
using System.Windows.Controls;
using System.Windows.Input;

namespace HelpDesk.Views.For_the_User.Pages
{
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            Manager.DisplayDeviceAttributes(txtCurrentUser, txtDeviceName, txtPublicIP, txtLocalIP, txtOS, txtDurationOnline, txtDeviceStatus);
        }

        private void imgSettings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}