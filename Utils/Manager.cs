using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Management;
using System.Linq;

namespace HelpDesk.Utils
{
    internal class Manager
    {
        public static Frame MainFrame;
        public static Frame UserFrame;
        public static Frame AdminFrame;

        public static (TextBlock _CurrentUser, TextBlock _DeviceName, TextBlock _PublicIP, TextBlock _LocalIP, TextBlock _OS, TextBlock _DurationOnline) DisplayDeviceAttributes(TextBlock CurrentUser, TextBlock DeviceName, TextBlock PublicIP, TextBlock LocalIP, TextBlock OS, TextBlock DurationOnline)
        {
            CurrentUser.Text = "Admin";
            DeviceName.Text = Environment.MachineName;
            PublicIP.Text = new WebClient().DownloadString("http://ipinfo.io/ip").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            LocalIP.Text = GetLocalIPAddress();
            OS.Text = GetOS();
            DurationOnline.Text = GetDurationOnline();
            return (CurrentUser, DeviceName, PublicIP, LocalIP, OS, DurationOnline);
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

        private static string GetDurationOnline()
        {
            int days, hours, minutes;
            days = (Environment.TickCount / 86400000);
            hours = (Environment.TickCount / 3600000 % 24);
            minutes = (Environment.TickCount / 120000 % 60);

            string totalTime = string.Format("{0:00}:{1:00}:{2:00}", days, hours, minutes);
            return totalTime;
        }
    }
}
