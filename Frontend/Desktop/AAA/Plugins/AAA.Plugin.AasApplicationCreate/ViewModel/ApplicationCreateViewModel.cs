using AAS.URI;
using Common.Consumer;
using Common.LibraryMessage;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Message;
using DungLH.Util.WpfCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.AasApplicationCreate.ViewModel
{
    class ApplicationCreateViewModel : ViewModelBase
    {
        public RelayCommand CreateNewCommand { get; internal set; }
        public RelayCommand CloseWindowCommand { get; internal set; }
        public AAS.EFMODEL.DataModels.Application NewApplication { get; set; }

        public ApplicationCreateViewModel()
        {
            this.NewApplication = new AAS.EFMODEL.DataModels.Application();
            this.CreateNewCommand = new RelayCommand(this.CreateNewApplication, null);
            this.CloseWindowCommand = new RelayCommand(this.CancelWindow, null);
        }

        public void CreateNewApplication(object data)
        {
            try
            {
                WaitingManager.Show();
                bool success = false;
                CommonParam commonParam = new CommonParam();

                if (this.CheckValidData(commonParam))
                {
                    AAS.EFMODEL.DataModels.Application rs = new DungLH.Util.Adapter.BackendAdapter(commonParam).Post<AAS.EFMODEL.DataModels.Application>(AasApplication.CREATE, ApiConsumerStore.AasConsumer, commonParam, this.NewApplication, null);
                    if (rs != null)
                    {
                        success = true;
                        this.NewApplication.Id = rs.Id;
                    }
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
                valid = valid && this.NewApplication != null;
                valid = valid && !String.IsNullOrWhiteSpace(this.NewApplication.ApplicationCode);
                valid = valid && !String.IsNullOrWhiteSpace(this.NewApplication.ApplicationName);
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
                this.NewApplication = null;
                CloseWindow = false;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

    }
}
