﻿using HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace HelpDesk.Views.For_the_Admin.Pages
{
    public partial class RequestListPage : Page
    {
        public RequestListPage()
        {
            InitializeComponent();
            DGRequestList.ItemsSource = DataBaseEntities.GetContext().Requests.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
