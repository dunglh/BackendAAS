using AAA.Plugin.AasUserCreate.ViewModel;
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

namespace AAA.Plugin.AasUserCreate.View
{
    /// <summary>
    /// Interaction logic for UserCreateView.xaml
    /// </summary>
    public partial class UserCreateView : Window
    {
        public UserCreateView()
        {
            InitializeComponent();
            this.txtLoginname.Focus();
            this.txtLoginname.SelectAll();
        }

        private void Txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    var element = sender as FrameworkElement;
                    if (element.Name == txtLoginname.Name)
                    {
                        this.txtUsername.Focus();
                        this.txtUsername.SelectAll();
                    }
                    else if (element.Name == txtUsername.Name)
                    {
                        this.txtPassword.Focus();
                        this.txtPassword.SelectAll();
                    }
                    else if (element.Name == txtPassword.Name)
                    {
                        this.txtEmail.Focus();
                        this.txtEmail.SelectAll();
                    }
                    else if (element.Name == txtEmail.Name)
                    {
                        this.txtPhone.Focus();
                        this.txtPhone.SelectAll();
                    }
                    else if (element.Name == txtPhone.Name)
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
