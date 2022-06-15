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

namespace HelpDesk.Views.For_the_User.Pages
{
    public partial class HelpRequestPage : Page
    {
        public HelpRequestPage()
        {
            InitializeComponent();
        }

        private void btnSendRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Заявка отправлена успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                StringBuilder errors = new StringBuilder();
                errors.AppendLine("Не удалось отправить заявку");
                errors.AppendLine("Подробности: " + "Не удалось подключиться к SQL серверу");
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
