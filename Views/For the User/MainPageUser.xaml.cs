using HelpDesk.Utils;
using System.Windows.Controls;

namespace HelpDesk.Views.For_the_User
{
    public partial class MainPageUser : Page
    {
        public MainPageUser()
        {
            InitializeComponent();
            Manager.UserFrame = UserFrame;
        }

        private void Click_Request(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager.UserFrame.Navigate(new Pages.HelpRequestPage());
        }

        private void Click_Chat(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager.UserFrame.Navigate(new Pages.ChatPage());
        }

        private void Click_Profile(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager.UserFrame.Navigate(new Pages.ProfilePage());
        }
    }
}
