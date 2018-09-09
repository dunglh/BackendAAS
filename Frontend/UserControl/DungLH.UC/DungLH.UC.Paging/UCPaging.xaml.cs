using DungLH.UC.Paging.ViewModel;
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

namespace DungLH.UC.Paging
{
    /// <summary>
    /// Interaction logic for UCPaging.xaml
    /// </summary>
    public partial class UCPaging : UserControl
    {
        public event EventHandler LoadDataEvent;

        public UCPaging()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                UCPagingViewModel viewModel = this.DataContext as UCPagingViewModel;
                if (viewModel != null)
                {
                    this.LoadDataEvent(viewModel.GetParam(), EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var element = (FrameworkElement)sender;
                UCPagingViewModel viewModel = this.DataContext as UCPagingViewModel;
                if (element.Name == btnFirstPage.Name)
                {
                    viewModel.FirstPage();
                    this.LoadDataEvent(viewModel.GetParam(), EventArgs.Empty);
                }
                else if (element.Name == btnPreviousPage.Name)
                {
                    viewModel.PreviousPage();
                    this.LoadDataEvent(viewModel.GetParam(), EventArgs.Empty);
                }
                else if (element.Name == btnNextPage.Name)
                {
                    viewModel.NextPage();
                    this.LoadDataEvent(viewModel.GetParam(), EventArgs.Empty);
                }
                else if (element.Name == btnLastPage.Name)
                {
                    viewModel.LastPage();
                    this.LoadDataEvent(viewModel.GetParam(), EventArgs.Empty);
                }
                else if (element.Name == btnRefreshPage.Name)
                {
                    this.LoadDataEvent(viewModel.GetParam(), EventArgs.Empty);
                }
                var name = this.Parent;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        private void cboPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                UCPagingViewModel viewModel = this.DataContext as UCPagingViewModel;
                viewModel.PageSize = Convert.ToInt32(this.cboPageSize.SelectedValue);
                CommonParam param = viewModel.GetParam();
                this.LoadDataEvent(viewModel.GetParam(), EventArgs.Empty);
                int rowCount = (param == null ? 0 : (param.Count ?? 0));
                viewModel.TotalCount = rowCount;
                viewModel.RefreshAll();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

    }
}
