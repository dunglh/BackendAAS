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

namespace AAA.Plugin.AasRoleCreate.View
{
    /// <summary>
    /// Interaction logic for RoleCreateView.xaml
    /// </summary>
    public partial class RoleCreateView : Window
    {
        public RoleCreateView()
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
                    if (element.Name == txtRoleCode.Name)
                    {
                        this.txtRoleName.Focus();
                        this.txtRoleName.SelectAll();
                    }
                    else if (element.Name == txtRoleName.Name)
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
