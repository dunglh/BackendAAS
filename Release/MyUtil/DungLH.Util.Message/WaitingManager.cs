using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DungLH.Util.Message
{
    public class WaitingManager
    {
        private static WaitWindow waitWindow;

        public static void Show()
        {
            try
            {
                if (waitWindow != null && IsWindowOpen<WaitWindow>(waitWindow.Name))
                {
                    return;
                }

                waitWindow = new WaitWindow();
                waitWindow.Show();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public static void Close()
        {
            try
            {
                if (waitWindow == null)
                {
                    return;
                }
                if (IsWindowOpen<WaitWindow>(waitWindow.Name))
                {
                    waitWindow.Close();
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                CloseByName("waitWindow");
            }
        }

        private static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return String.IsNullOrWhiteSpace(name) ? Application.Current.Windows.OfType<T>().Any() :
                Application.Current.Windows.OfType<T>().Any(a => a.Name.Equals(name));
        }

        private static void CloseByName(string name)
        {
            if (Application.Current.Windows != null)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window == null || window.GetType() != typeof(WaitWindow))
                    {
                        continue;
                    }
                    if (window.Name == name)
                    {
                        window.Close();
                    }
                }
            }
        }
    }
}
