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

namespace AAA.Plugin.AasModuleCreate.View
{
    /// <summary>
    /// Interaction logic for ModuleCreateView.xaml
    /// </summary>
    public partial class ModuleCreateView : Window
    {
        public ModuleCreateView()
        {
            InitializeComponent();
        }

        private void Txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    var element = sender as FrameworkElement;
                    if (element.Name == txtModuleCode.Name)
                    {
                        this.txtModuleName.Focus();
                        this.txtModuleName.SelectAll();
                    }
                    else if (element.Name == txtModuleName.Name)
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
