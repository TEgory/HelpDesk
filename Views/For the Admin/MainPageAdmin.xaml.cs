﻿using HelpDesk.Utils;
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

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
