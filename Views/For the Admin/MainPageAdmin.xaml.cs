using HelpDesk.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelpDesk.Views.For_the_Admin
{
    public partial class MainPageAdmin : Page
    {
        public MainPageAdmin()
        {
            InitializeComponent();
            Manager.AdminFrame = AdminFrame;
            Manager.AdminFrame.Navigate(new Pages.RequestListPage());
        }

        private void Click_Menu(object sender, MouseButtonEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            if (AdminFrame.GetValue(Grid.ColumnProperty).ToString() == "0")
            {
                AdminFrame.SetValue(Grid.ColumnProperty, 1);
                borderMenu.Visibility = Visibility.Visible;
                SPMenu.Visibility = Visibility.Visible;
            }
            else
            {
                AdminFrame.SetValue(Grid.ColumnProperty, 0);
                borderMenu.Visibility = Visibility.Collapsed;
                SPMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void Click_Request(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Devices(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Departments(object sender, MouseButtonEventArgs e)
        {

        }


        private void Click_Dashboard(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Settings(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
