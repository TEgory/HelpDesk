using HelpDesk.Utils;
using System.Windows;

namespace HelpDesk
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new Views.For_the_User.MainPageUser());
        }
    }
}