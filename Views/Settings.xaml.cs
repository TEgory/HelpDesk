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
using System.Windows.Shapes;

namespace HelpDesk.Views
{
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as Grid).Name.ToString())
            {
                case "GridGitHub":
                    System.Diagnostics.Process.Start("https://github.com/TEgory");
                    return;
                case "GridTwitter":
                    System.Diagnostics.Process.Start("https://vk.com/");
                    return;
                case "GridVk":
                    System.Diagnostics.Process.Start("https://twitter.com/");
                    return;
            }
        }
    }
}
