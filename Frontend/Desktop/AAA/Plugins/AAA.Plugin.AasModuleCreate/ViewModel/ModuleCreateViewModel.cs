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

namespace AAA.Plugin.AasModuleCreate.ViewModel
{
    class ModuleCreateViewModel : ViewModelBase
    {
        public RelayCommand CreateNewCommand { get; internal set; }
        public RelayCommand CloseWindowCommand { get; internal set; }
        public AAS.EFMODEL.DataModels.Module NewModule { get; set; }

        public ModuleCreateViewModel()
        {
            this.CreateNewCommand = new RelayCommand(this.CreateNewModule, null);
            this.CloseWindowCommand = new RelayCommand(this.CancelWindow, null);
            this.NewModule = new AAS.EFMODEL.DataModels.Module();
        }

        public void CreateNewModule(object data)
        {
            try
            {
                WaitingManager.Show();
                bool success = false;
                CommonParam commonParam = new CommonParam();
                if (this.CheckValidData(commonParam))
                {
                    AAS.EFMODEL.DataModels.Module rs = new DungLH.Util.Adapter.BackendAdapter(commonParam).Post<AAS.EFMODEL.DataModels.Module>(AasModule.CREATE, ApiConsumerStore.AasConsumer, commonParam, this.NewModule, null);
                    if (rs != null)
                    {
                        success = true;
                        this.NewModule.Id = rs.Id;
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
                valid = valid && this.NewModule != null;
                valid = valid && !String.IsNullOrWhiteSpace(this.NewModule.ModuleCode);
                valid = valid && !String.IsNullOrWhiteSpace(this.NewModule.ModuleName);
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
                this.NewModule = null;
                CloseWindow = false;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }
    }
}
