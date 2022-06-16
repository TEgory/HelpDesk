using HelpDesk.Models;
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
using System.Windows.Threading;

namespace HelpDesk.Views.For_the_Admin.Pages
{
    public partial class RequestListPage : Page
    {
        List<Request> _products = new List<Request>();
        private string _FindedName;

        public RequestListPage()
        {
            InitializeComponent();
            DGRequestList.ItemsSource = DataBaseEntities.GetContext().Requests.ToList();
            DataContext = DataBaseEntities.GetContext().Requests.ToList();
            CBRequestType.ItemsSource = DataBaseEntities.GetContext().RequestTypes.ToList();
            CBRequestPriority.ItemsSource = DataBaseEntities.GetContext().Priorities.ToList();
            CBRequestStatus.ItemsSource = DataBaseEntities.GetContext().RequestStatus.ToList();

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            _FindedName = txtSearch.Text;

            if (_FindedName == "Поиск....." || string.IsNullOrWhiteSpace(_FindedName))
                return;

            _products = _products.OrderBy(x => x.RequestSubject).Where(x => x.RequestSubject.ToLower().Contains(_FindedName) ||
                x.PriorityId.ToString().Contains(_FindedName) ||
                x.RequestType.RequestTypeName.ToLower().Contains(_FindedName) ||
                x.RequestDescription.ToLower().ToString().Contains(_FindedName) ||
                x.Department.DepartmenName.ToLower().Contains(_FindedName) ||
                x.User.UserName.ToLower().Contains(_FindedName) ||
                x.Device.DeviceName.ToLower().Contains(_FindedName) ||
                x.RequestCabinet.Contains(_FindedName) ||
                x.Department.DepartmenName.ToLower().Contains(_FindedName) ||
                x.RequestStatus.RequestStatusName.ToLower().Contains(_FindedName.ToLower())).ToList();

            DGRequestList.ItemsSource = _products;

            if (_products.Count < 0)
                MessageBox.Show("Ничего не найдено!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                                                                                                    
        }

        private void DGRequestList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                ListCollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource) as ListCollectionView;
                if (view.IsAddingNew || view.IsEditingItem)
                {
                    Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                    {
                        try
                        {
                            DataBaseEntities.GetContext().SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        return null;
                    }), DispatcherPriority.Background, new object[] { null });
                }
            }
        }

    }
}
