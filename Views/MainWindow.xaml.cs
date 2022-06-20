using HelpDesk.Utils;
using System;
using System.Windows;

namespace HelpDesk
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            try
            {
                Manager.AddUser();
                Manager.AddEditDevice(true);
                //Manager.MainFrame.Navigate(new Views.For_the_Admin.MainPageAdmin());

                if (Manager.IsAdministrator())
                {
                    Manager.MainFrame.Navigate(new Views.For_the_Admin.MainPageAdmin());
                    return;
                }
                else
                {
                    Manager.MainFrame.Navigate(new Views.For_the_User.MainPageUser());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Manager.AddEditDevice(false);
        }
    }
}