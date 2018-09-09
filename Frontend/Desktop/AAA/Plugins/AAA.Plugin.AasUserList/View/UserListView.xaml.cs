using AAA.Plugin.AasUserList.ViewModel;
using Common.Utility;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
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

namespace AAA.Plugin.AasUserList.View
{
    /// <summary>
    /// Interaction logic for UserListView.xaml
    /// </summary>
    public partial class UserListView : UserControl
    {
        public UserListView()
        {
            InitializeComponent();
            Common.Consumer.BaseUri.LoadConfig();
        }

        private void Txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    var element = sender as FrameworkElement;
                    if (element != null)
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

        private void ucPaging_LoadDataEvent(object sender, EventArgs e)
        {
            try
            {
                if (sender != null && sender is CommonParam)
                {
                    UserListViewModel viewModel = this.DataContext as UserListViewModel;
                    viewModel.LoadPaging((CommonParam)sender);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }
    }
}
