using HelpDesk.Models;
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

namespace HelpDesk.Views.For_the_Admin.Pages
{
    public partial class DepartmentsPage : Page
    {
        Department _currentDepartment = new Department();

        public DepartmentsPage()
        {
            InitializeComponent();
            DGDepartmentList.ItemsSource = DataBaseEntities.GetContext().Departments.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNewDep.Text))
            {
                MessageBox.Show("Введите название отдела!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (txtNewDep.Text == DataBaseEntities.GetContext().Departments.Where(x => x.DepartmenName == txtNewDep.Text).FirstOrDefault().DepartmenName)
            {
                MessageBox.Show("Отдел с таким название уже имеется!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _currentDepartment.DepartmenName = txtNewDep.Text;
            try
            {
                DataBaseEntities.GetContext().Departments.Add(_currentDepartment);
                DataBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                DGDepartmentList.ItemsSource = DataBaseEntities.GetContext().Departments.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var ItemsForRemoving = DGDepartmentList.SelectedItems.Cast<Department>().ToList();

            if (ItemsForRemoving.Count == 0)
            {
                MessageBox.Show("Выберите элементы для удаления!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (MessageBox.Show($"Вы действительно хотите удалить данные?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DataBaseEntities.GetContext().Departments.RemoveRange(ItemsForRemoving);
                DataBaseEntities.GetContext().SaveChanges();
                DGDepartmentList.ItemsSource = DataBaseEntities.GetContext().Departments.ToList();
            }
        }
    }
}
