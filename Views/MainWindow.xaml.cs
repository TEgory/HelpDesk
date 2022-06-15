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
                Manager.AddDevice();

                if (Manager.IsAdministrator())
                    Manager.MainFrame.Navigate(new Views.For_the_Admin.MainPageAdmin());
                Manager.MainFrame.Navigate(new Views.For_the_User.MainPageUser());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}