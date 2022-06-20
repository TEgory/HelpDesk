using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Management;
using System.Linq;
using System.Security.Principal;
using HelpDesk.Models;
using System.Windows;
using System.Data.SqlClient;

namespace HelpDesk.Utils
{
    internal class Manager
    {
        public static Frame MainFrame;
        public static Frame UserFrame;
        public static Frame AdminFrame;

        //public static void ConnectionToServer()
        //{
        //    string connectionString = null;
        //    var sb = new SqlConnectionStringBuilder()
        //    {
        //        DataSource = "PK",
        //        InitialCatalog = "HelpDesk",
        //        UserID = "sa",
        //        Password = "sa2022",
        //    };
        //    connectionString = sb.ConnectionString;
        //}

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void AddUser()
        {
            try
            {
                User _currentUser = new User();

                if (Environment.UserName == DataBaseEntities.GetContext().Users.Where(x => x.UserName == Environment.UserName).FirstOrDefault().UserName)
                    return;

                _currentUser.UserName = Environment.UserName;
                DataBaseEntities.GetContext().Users.Add(_currentUser);
                DataBaseEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Ошибка занесения пользователя в базу данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void AddEditDevice(bool condition)
        {
            try
            {
                User _currentUser = new User();
                _currentUser = DataBaseEntities.GetContext().Users.Where(x => x.UserName == Environment.UserName).FirstOrDefault();

                Device _currentDevice = new Device();
                Device _checkdub = new Device();
                _checkdub = DataBaseEntities.GetContext().Devices.Where(x => x.DeviceName == Environment.MachineName).FirstOrDefault();

                // Проверка на повторную запись устройства 
                if (Environment.MachineName == _checkdub.DeviceName)
                {
                    _checkdub.Condition = condition;
                    if (!condition)
                    {
                        _checkdub.DurationOnline = TimeSpan.Zero;
                    }
                    else
                    {
                        _checkdub.DurationOnline = GetDurationOnline();
                    }

                    DataBaseEntities.GetContext().SaveChanges();
                    return;
                }

                _currentDevice.DeviceName = Environment.MachineName;
                _currentDevice.PublicIP = GetPublicIP();
                _currentDevice.LocalIP = GetLocalIPAddress();
                _currentDevice.OperatingSystem = GetOS();
                _currentDevice.Condition = condition;
                _currentDevice.DurationOnline = GetDurationOnline();
                _currentDevice.Status = 1;
                _currentDevice.LastUserId = _currentUser.UserId;

                DataBaseEntities.GetContext().Devices.Add(_currentDevice);
                DataBaseEntities.GetContext().SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка занесения устройства в базу данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Использование кортежей для вывода нескольких значений
        public static (TextBlock _CurrentUser, TextBlock _DeviceName, TextBlock _PublicIP, TextBlock _LocalIP, TextBlock _OS, TextBlock _DurationOnline, TextBlock _DeviceStatus) DisplayDeviceAttributes(TextBlock CurrentUser, TextBlock DeviceName, TextBlock PublicIP, TextBlock LocalIP, TextBlock OS, TextBlock DurationOnline, TextBlock DeviceStatus)
        {
            CurrentUser.Text = Environment.UserName;
            DeviceName.Text = Environment.MachineName;
            PublicIP.Text = GetPublicIP();
            LocalIP.Text = GetLocalIPAddress();
            OS.Text = GetOS();
            DurationOnline.Text = GetDurationOnline().ToString();
            DeviceStatus.Text = "OK";
            return (CurrentUser, DeviceName, PublicIP, LocalIP, OS, DurationOnline, DeviceStatus);
        }

        private static string GetPublicIP()
        {
            try
            {
                return new WebClient().DownloadString("http://ipinfo.io/ip").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            }
            catch
            {
                return "Подключение к Интернету отсутствует";
            }
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var user_ip in host.AddressList)
            {
                if (user_ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return user_ip.ToString();
                }
            }
            throw new Exception("В системе нет сетевых адаптеров с адресом IPv4!");
        }

        private static string GetOS()
        {
            string bit = Environment.Is64BitOperatingSystem != true ? " x32" : " x64";
            object name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()select x.GetPropertyValue("Caption")).FirstOrDefault();
           
            return name != null ? name.ToString().Remove(0, name.ToString().IndexOf(" ") + 1) + bit : "Unknown";
        }

        private static TimeSpan GetDurationOnline()
        {
            int days, hours, minutes;
            days = (Environment.TickCount / 86400000);
            hours = (Environment.TickCount / 3600000 % 24);
            minutes = (Environment.TickCount / 120000 % 60);

            return TimeSpan.Parse(string.Format("{0:00}:{1:00}:{2:00}", days, hours, minutes)); ;
        }
    }
}