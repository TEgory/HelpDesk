using HelpDesk.Models;
using HelpDesk.Utils;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HelpDesk.Views.For_the_User.Pages
{
    public partial class HelpRequestPage : Page
    {
        private Request _currentRequest = new Request();

        public HelpRequestPage()
        {
            InitializeComponent();
            CBRequestType.ItemsSource = DataBaseEntities.GetContext().RequestTypes.ToList();
            CBDepartmen.ItemsSource = DataBaseEntities.GetContext().Departments.ToList();
            CBPriority.ItemsSource = DataBaseEntities.GetContext().Priorities.ToList();

            DataContext = _currentRequest;
        }

        private void btnSendRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrWhiteSpace(_currentRequest.RequestSubject))
                    errors.AppendLine("Укажите тему заявки!");
                if (_currentRequest.RequestType == null)
                    errors.AppendLine("Укажите тип заявки!");
                if (_currentRequest.Department == null)
                    errors.AppendLine("Укажите отдел!");
                if (_currentRequest.Priority == null)
                    errors.AppendLine("Укажите приоритет заявки!");
                if (string.IsNullOrWhiteSpace(_currentRequest.RequestCabinet))
                    errors.AppendLine("Укажите кабинет!");

                _currentRequest.RequestStatusId = 1;
                _currentRequest.DeviceId = DataBaseEntities.GetContext().Devices.Where(x => x.DeviceName == Environment.MachineName).FirstOrDefault().DeviceId;
                _currentRequest.UserId = DataBaseEntities.GetContext().Users.Where(x => x.UserName == Environment.UserName).FirstOrDefault().UserId;
                _currentRequest.RequestDateOfCreation = DateTime.Now;
                _currentRequest.RequestDateLastUpdate = DateTime.Now;

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (_currentRequest.RequestId == 0)
                    DataBaseEntities.GetContext().Requests.Add(_currentRequest);

                DataBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Заявка отправлена успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.UserFrame.Navigate(new HelpRequestPage());
            }
            catch (Exception ex)
            {
                StringBuilder errors = new StringBuilder();
                errors.AppendLine("Не удалось отправить заявку");
                errors.AppendLine("Подробности: " + MessageBox.Show(ex.Message));
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.UserFrame.Navigate(new HelpRequestPage());
        }
    }
}