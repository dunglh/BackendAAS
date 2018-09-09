using AAS.URI;
using Common.Consumer;
using Common.LibraryMessage;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Message;
using DungLH.Util.WpfCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.AasUserCreate.ViewModel
{
    class UserCreateViewModel : ViewModelBase, IDataErrorInfo
    {
        public RelayCommand CreateNewCommand { get; internal set; }
        public RelayCommand CloseWindowCommand { get; internal set; }
        public AAS.EFMODEL.DataModels.User NewUser { get; set; }

        public UserCreateViewModel()
        {
            this.NewUser = new AAS.EFMODEL.DataModels.User();
            this.CreateNewCommand = new RelayCommand(this.CreateNewUser, null);
            this.CloseWindowCommand = new RelayCommand(this.CancelWindow, null);
        }

        public void CreateNewUser(object data)
        {
            try
            {
                WaitingManager.Show();
                bool success = false;
                CommonParam commonParam = new CommonParam();

                AAS.EFMODEL.DataModels.User rs = new DungLH.Util.Adapter.BackendAdapter(commonParam).Post<AAS.EFMODEL.DataModels.User>(AasUser.CREATE, ApiConsumerStore.AasConsumer, commonParam, this.NewUser, null);
                if (rs != null)
                {
                    success = true;
                    this.NewUser.Id = rs.Id;
                }
                WaitingManager.Close();
                if (success)
                {
                    MessageManager.ShowAlert(commonParam, success);
                    CloseWindow = true;
                }
                else
                {
                    MessageManager.Show(commonParam, success);
                }

            }
            catch (Exception ex)
            {
                WaitingManager.Close();
                LogSystem.Error(ex);
            }
        }

        private bool CheckValidData(CommonParam commonParam)
        {
            bool valid = true;
            try
            {
                valid = valid && this.NewUser != null;
                valid = valid && !String.IsNullOrWhiteSpace(this.NewUser.Loginname);
                valid = valid && !String.IsNullOrWhiteSpace(this.NewUser.Username);
                valid = valid && !String.IsNullOrWhiteSpace(this.NewUser.Password);
                if (!valid)
                {
                    MessageUtil.SetMessage(commonParam, Message.Enum.Common_ThieuTruongThongTinBatBuoc);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
            }
            return valid;
        }

        public void CancelWindow(object data)
        {
            try
            {
                this.NewUser = null;
                CloseWindow = false;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public string Password
        {
            get
            {
                return NewUser.Password;
            }
            set
            {
                this.NewUser.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Password")
                {
                    if (String.IsNullOrWhiteSpace(NewUser.Password))
                    {
                        return MessageUtil.GetMessage(Message.Enum.Common_TruongDuLieuBatBuoc);
                    }
                }
                return null;
            }
        }

    }
}
