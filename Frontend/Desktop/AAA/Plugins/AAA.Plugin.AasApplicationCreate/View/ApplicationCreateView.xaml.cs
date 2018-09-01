using Common.Utility;
using DungLH.Util.CommonLogging;
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
using System.Windows.Shapes;

namespace AAA.Plugin.AasApplicationCreate.View
{
    /// <summary>
    /// Interaction logic for ApplicationCreateView.xaml
    /// </summary>
    public partial class ApplicationCreateView : Window
    {
        public ApplicationCreateView()
        {
            InitializeComponent();
            this.txtApplicationCode.Focus();
            this.txtApplicationCode.SelectAll();
        }

        private void Txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    var element = sender as FrameworkElement;
                    if (element.Name == "txtApplicationCode")
                    {
                        this.txtApplicationName.Focus();
                        this.txtApplicationName.SelectAll();
                    }
                    else if (element.Name == "txtApplicationName")
                    {
                        SendKeys.Send(Key.Tab);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }
    }
}
