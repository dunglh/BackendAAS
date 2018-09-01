using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace DungLH.Util.Message
{
    public enum NotiEnum
    {
        Info = 1,
        Success = 2,
        Warn = 3,
        Error = 4
    }
    public class MessageManager
    {
        public static int AutoFormDelay = 1000;
        public const int DefaultFontSize = 12;
        private static Notifier _notifier;
        private static bool isInit = false;

        public static void Show(CommonParam param, bool? success)
        {
            try
            {
                if (success.HasValue)
                {
                    MessageUtil.SetResultParam(param, success.Value);
                }
                string message = MessageUtil.GetMessageAlert(param);
                if (!String.IsNullOrEmpty(message))
                    Show(message);

            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public static void Show(string message)
        {
            try
            {
                MessageBox.Show(message, "Thông báo");
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public static void ShowAlert(CommonParam param, bool? success)
        {
            if (success.HasValue)
            {
                MessageUtil.SetResultParam(param, success.Value);
            }
            string message = MessageUtil.GetMessageAlert(param);
            if (!success.HasValue)
            {
                ShowAlert(message, NotiEnum.Info);
            }
            else if (success.Value)
            {
                ShowAlert(message, NotiEnum.Success);
            }
            else
            {
                ShowAlert(message, NotiEnum.Error);
            }
        }

        public static void ShowAlert(string message, NotiEnum notiEnum)
        {
            InitNotifier();
            _notifier.ClearMessages();
            switch (notiEnum)
            {
                case NotiEnum.Info:
                    _notifier.ShowInformation(message);
                    break;
                case NotiEnum.Success:
                    _notifier.ShowSuccess(message);
                    break;
                case NotiEnum.Warn:
                    _notifier.ShowWarning(message);
                    break;
                case NotiEnum.Error:
                    _notifier.ShowError(message);
                    break;
                default:
                    break;
            }
        }

        private static void InitNotifier()
        {
            if (isInit) return;
            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.BottomRight,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(2),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }
    }
}
