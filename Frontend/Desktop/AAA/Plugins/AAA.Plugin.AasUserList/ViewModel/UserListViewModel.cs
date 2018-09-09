using AAA.Plugin.AasUserList.Model;
using AAS.EFMODEL.DataModels;
using AAS.Filter;
using AAS.URI;
using AutoMapper;
using Common.Consumer;
using Common.LibraryMessage;
using Common.Utility;
using DungLH.Util.Adapter;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Message;
using DungLH.Util.WpfCommon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.AasUserList.ViewModel
{
    class UserListViewModel : ViewModelBase, IDataErrorInfo
    {
        public RelayCommand BtnFindCommand { get; internal set; }
        public RelayCommand BtnChangeLockCommand { get; internal set; }
        public RelayCommand BtnAddCommand { get; internal set; }
        public RelayCommand BtnRefreshCommand { get; internal set; }
        public RelayCommand BtnEditCommand { get; internal set; }

        private ObservableCollection<AasUserADO> _listUser = new ObservableCollection<AasUserADO>();
        private AasUserADO _currentUser;
        private string _keyWord;
        private int _limit = 0;
        private int _start = 0;
        private int _total = 0;
        private int _count = 0;

        public UserListViewModel()
        {
            this.BtnAddCommand = new RelayCommand(this.BtnAdd_Click, null);
            this.BtnChangeLockCommand = new RelayCommand(this.BtnChangeLock_Click, null);
            this.BtnEditCommand = new RelayCommand(this.BtnEdit_Click, null);
            this.BtnFindCommand = new RelayCommand(this.BtnFind_Click, null);
            this.BtnRefreshCommand = new RelayCommand(this.BtnRefresh_Click, null);
            this._currentUser = new AasUserADO();
        }

        public AasUserADO CurrentUser
        {
            get { return this._currentUser; }
            set
            {
                this._currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        public ObservableCollection<AasUserADO> ListUser
        {
            get { return this._listUser; }
            internal set
            {
                this._listUser = value;
                OnPropertyChanged("ListUser");
            }
        }

        public string Password
        {
            get
            {
                return CurrentUser.Password;
            }
            set
            {
                this.CurrentUser.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public string KeyWord
        {
            get { return this._keyWord; }
            set
            {
                this._keyWord = value;
                OnPropertyChanged("KeyWord");
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Password")
                {
                    if (String.IsNullOrWhiteSpace(CurrentUser.Password) && this.CurrentUser.Id <= 0)
                    {
                        return MessageUtil.GetMessage(Message.Enum.Common_TruongDuLieuBatBuoc);
                    }
                }
                return null;
            }
        }

        #region DataGrid
        public void BtnFind_Click(object parameters)
        {
            try
            {
                WaitingManager.Show();
                CommonParam commonParam = new CommonParam();
                commonParam.Start = this._start;
                commonParam.Limit = this._limit;
                this.LoadPaging(commonParam);
                WaitingManager.Close();
            }
            catch (Exception ex)
            {
                WaitingManager.Close();
                LogSystem.Error(ex);
            }
        }

        public void BtnChangeLock_Click(object parameters)
        {
            try
            {
                if (parameters != null && parameters is AasUserADO)
                {
                    WaitingManager.Show();
                    bool success = false;
                    CommonParam commonParam = new CommonParam();
                    AasUserADO data = parameters as AasUserADO;
                    if (data.IsActive == Constant.IS_TRUE)
                    {
                        User rs = new BackendAdapter(commonParam).Post<User>(AasUser.LOCK, ApiConsumerStore.AasConsumer, commonParam, data, null);
                        if (rs != null)
                        {
                            data.IsActive = rs.IsActive;
                            success = true;
                        }
                    }
                    else
                    {
                        User rs = new BackendAdapter(commonParam).Post<User>(AasUser.UNLOCK, ApiConsumerStore.AasConsumer, commonParam, data, null);
                        if (rs != null)
                        {
                            data.IsActive = rs.IsActive;
                            success = true;
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
            }
            catch (Exception ex)
            {
                WaitingManager.Close();
                LogSystem.Error(ex);
            }
        }

        #endregion

        #region CreateOrUpdate

        public void BtnAdd_Click(object parameters)
        {
            try
            {
                if (this.CurrentUser == null || this.CurrentUser.Id > 0)
                {
                    LogSystem.Info("CurrentUser null or id <= 0");
                    return;
                }
                WaitingManager.Show();
                CommonParam commonParam = new CommonParam();
                bool success = false;
                if (this.ValidData(this.CurrentUser, true))
                {
                    User rs = new BackendAdapter(commonParam).Post<User>(AasUser.CREATE, ApiConsumerStore.AasConsumer, commonParam, this.CurrentUser, null);
                    if (rs != null)
                    {
                        success = true;
                        CommonParam param = new CommonParam();
                        param.Start = this._start;
                        param.Limit = this._limit;
                        this.LoadPaging(param);
                    }
                }
                else
                {
                    MessageUtil.SetMessage(commonParam, Message.Enum.Common_ThieuTruongThongTinBatBuoc);
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

        public void BtnEdit_Click(object parameters)
        {
            try
            {
                if (this.CurrentUser == null || this.CurrentUser.Id <= 0)
                {
                    LogSystem.Info("CurrentUser null or id > 0");
                    return;
                }
                WaitingManager.Show();
                CommonParam commonParam = new CommonParam();
                bool success = false;
                if (this.ValidData(this.CurrentUser, false))
                {
                    User rs = new BackendAdapter(commonParam).Post<User>(AasUser.UPDATE, ApiConsumerStore.AasConsumer, commonParam, this.CurrentUser, null);
                    if (rs != null)
                    {
                        success = true;
                        CommonParam param = new CommonParam();
                        param.Start = this._start;
                        param.Limit = this._limit;
                        this.LoadPaging(param);
                    }
                }
                else
                {
                    MessageUtil.SetMessage(commonParam, Message.Enum.Common_ThieuTruongThongTinBatBuoc);
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

        public void BtnRefresh_Click(object parameters)
        {
            try
            {
                this.CurrentUser = new AasUserADO();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        private bool ValidData(User user, bool isCreate)
        {
            bool valid = true;
            try
            {
                valid = valid && IsNotNull(user);
                valid = valid && IsNotNullOrEmpty(user.Loginname);
                valid = valid && IsNotNullOrEmpty(user.Username);
                if (isCreate)
                {
                    valid = valid && IsNotNullOrEmpty(user.Password);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
            }
            return valid;
        }
        #endregion

        public void LoadPaging(CommonParam param)
        {
            try
            {
                this.ListUser = new ObservableCollection<AasUserADO>();
                this.CurrentUser = new AasUserADO();
                this._start = param.Start ?? 0;
                this._limit = param.Limit ?? 0;
                CommonParam paramCommon = new CommonParam(this._start, this._limit);
                AasUserFilter filter = new AasUserFilter();
                filter.KeyWord = this.KeyWord;
                filter.OrderDirection = "DESC";
                filter.OrderField = "ModifyTime";
                var rs = new BackendAdapter(paramCommon).GetRO<List<User>>(AasUser.GET, ApiConsumerStore.AasConsumer, paramCommon, filter, null);
                if (rs != null)
                {
                    var data = (List<User>)rs.Data;
                    Mapper.CreateMap<User, AasUserADO>();
                    this.ListUser = Mapper.Map<ObservableCollection<AasUserADO>>(data);
                    if (this.ListUser != null)
                    {
                        this._total = (ListUser == null ? 0 : ListUser.Count);
                        this._count = (rs.Param == null ? 0 : rs.Param.Count ?? 0);
                        param.Count = this._count;
                        param.Limit = this._limit;
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
