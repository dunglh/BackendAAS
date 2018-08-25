using AAS.BusinessManager.AasCredentialData;
using AAS.BusinessManager.Base;
using AAS.BusinessManager.Token.Authorize;
using AAS.BusinessManager.Token.Login;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasCredentialData;
using AAS.GetManager.AasUser;
using AAS.SDO;
using AAS.Util;
using AutoMapper;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Token.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.BusinessManager.Token.Common
{
    class TokenManagerBase
    {
        internal bool CreateCredentialData(DungLH.Util.Token.Core.CredentialData credentialData, CommonParam commonParam)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = valid && credentialData != null;
                if (!valid) throw new ArgumentNullException("credentialData is null");
                CredentialData data = new CredentialData();
                data.BackendCode = credentialData.BackendCode;
                data.Data = credentialData.Data;
                data.DataKey = credentialData.DataKey;
                data.TokenCode = credentialData.TokenCode;
                if (!new AasCredentialDataCreate(commonParam).Create(data))
                {
                    throw new Exception("Insert CredentialData that bai \n" + DungLH.Util.CommonLogging.LogUtil.TraceData("credentialData", credentialData));
                }
                result = true;
            }
            catch (ArgumentNullException ex)
            {
                BugUtil.SetBugCode(commonParam, LibraryBug.Bug.Enum.Common__ThieuThongTinBatBuoc);
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        internal bool UpdateUserPassword(string loginname, string oldPassword, string newPassword, CommonParam commonParam)
        {
            bool result = false;
            try
            {
                if (String.IsNullOrWhiteSpace(loginname)) throw new ArgumentNullException("loginname");
                if (String.IsNullOrWhiteSpace(oldPassword)) throw new ArgumentNullException("oldPassword");
                if (String.IsNullOrWhiteSpace(newPassword)) throw new ArgumentNullException("newPassword");
                if (oldPassword.Length < Constant.MIN_LENGTH_PASSWORD)
                {
                    MessageUtil.SetMessage(commonParam, LibraryMessage.Message.Enum.Common__MatKhauKhongDuocNhoHon6KyTu);
                    throw new Exception("Mat khau khong duoc nho hon 6 ky tu");
                }
                PasswordManager passwordManager = new PasswordManager();
                AasUser.AasUserUpdate aasUserUpdate = new AasUser.AasUserUpdate(commonParam);
                User user = new UserManagerGet().GetByLoginname(loginname);
                if (user == null)
                {
                    MessageUtil.SetMessage(commonParam, LibraryMessage.Message.Enum.Common_TaiKhoanKhongChinhXac);
                    throw new Exception("Loginname invalid: " + loginname);
                }
                if (!passwordManager.CheckPassword(user.Password, oldPassword, user.Salt, loginname))
                {
                    MessageUtil.SetMessage(commonParam, LibraryMessage.Message.Enum.Common_TaiKhoanHoacMatKhauKhongChinhXac);
                    throw new Exception("Tai khoan hoac mat khau khong chinh xac");
                }

                string newHashPassword = passwordManager.HashPassword(newPassword, user.Salt, loginname);
                Mapper.CreateMap<User, User>();
                User before = Mapper.Map<User>(user);
                user.Password = newHashPassword;
                if (!aasUserUpdate.Update(user, before))
                {
                    throw new Exception("Update mat khau cho tai khoan that bai");
                }
                result = true;
                user.Password = "";
            }
            catch (ArgumentNullException ex)
            {
                BugUtil.SetBugCode(commonParam, LibraryBug.Bug.Enum.Common__ThieuThongTinBatBuoc);
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        internal bool DeleteCredentialData(string backendCode, string tokenCode, string dataKey, CommonParam commonParam)
        {
            bool result = false;
            try
            {
                if (String.IsNullOrWhiteSpace(backendCode)) throw new ArgumentNullException("backendCode");
                if (String.IsNullOrWhiteSpace(tokenCode)) throw new ArgumentNullException("tokenCode");
                if (String.IsNullOrWhiteSpace(dataKey)) throw new ArgumentNullException("dataKey");

                CredentialDataFilterQuery filter = new CredentialDataFilterQuery();
                filter.BackendCodeExact = backendCode;
                filter.TokenCodeExact = tokenCode;
                filter.DataKeyExact = dataKey;
                List<CredentialData> listData = new CredentialDataManagerGet().Get(filter);
                if (listData == null || listData.Count <= 0)
                {
                    BugUtil.SetBugCode(commonParam, LibraryBug.Bug.Enum.Common_DuLieuDauVaoKhongChinhXac);
                    throw new Exception("Khong tim thay CredentialData tuong ung");
                }

                if (!new AasCredentialDataTruncate(commonParam).TruncateList(listData))
                {
                    throw new Exception("Xoa credentialData that bai");
                }
                result = true;
            }
            catch (ArgumentNullException ex)
            {
                BugUtil.SetBugCode(commonParam, LibraryBug.Bug.Enum.Common__ThieuThongTinBatBuoc);
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        internal bool DeleteAllCredentialData(string tokenCode, CommonParam commonParam)
        {
            bool result = false;
            try
            {
                if (String.IsNullOrWhiteSpace(tokenCode)) throw new ArgumentNullException("tokenCode");

                CredentialDataFilterQuery filter = new CredentialDataFilterQuery();
                filter.TokenCodeExact = tokenCode;
                List<CredentialData> listData = new CredentialDataManagerGet().Get(filter);
                if (listData == null || listData.Count <= 0)
                {
                    BugUtil.SetBugCode(commonParam, LibraryBug.Bug.Enum.Common_DuLieuDauVaoKhongChinhXac);
                    throw new Exception("Khong tim thay CredentialData tuong ung");
                }

                if (!new AasCredentialDataTruncate(commonParam).TruncateList(listData))
                {
                    throw new Exception("Xoa credentialData that bai");
                }
                result = true;
            }
            catch (ArgumentNullException ex)
            {
                BugUtil.SetBugCode(commonParam, LibraryBug.Bug.Enum.Common__ThieuThongTinBatBuoc);
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        internal DungLH.Util.Token.Core.CredentialData GetCredentialData(string backendCode, string tokenCode, string dataKey, CommonParam commonParam)
        {
            DungLH.Util.Token.Core.CredentialData result = null;
            try
            {
                if (String.IsNullOrWhiteSpace(backendCode)) throw new ArgumentNullException("backendCode");
                if (String.IsNullOrWhiteSpace(tokenCode)) throw new ArgumentNullException("tokenCode");
                if (String.IsNullOrWhiteSpace(dataKey)) throw new ArgumentNullException("dataKey");

                CredentialDataFilterQuery filter = new CredentialDataFilterQuery();
                filter.BackendCodeExact = backendCode;
                filter.TokenCodeExact = tokenCode;
                filter.DataKeyExact = dataKey;
                List<CredentialData> listData = new CredentialDataManagerGet().Get(filter);
                if (listData == null || listData.Count <= 0)
                {
                    BugUtil.SetBugCode(commonParam, LibraryBug.Bug.Enum.Common_DuLieuDauVaoKhongChinhXac);
                    throw new Exception("Khong tim thay CredentialData tuong ung");
                }
                CredentialData data = listData.FirstOrDefault();
                result = new DungLH.Util.Token.Core.CredentialData();
                result.BackendCode = data.BackendCode;
                result.Data = data.Data;
                result.DataKey = data.DataKey;
                result.TokenCode = data.TokenCode;
            }
            catch (ArgumentNullException ex)
            {
                BugUtil.SetBugCode(commonParam, LibraryBug.Bug.Enum.Common__ThieuThongTinBatBuoc);
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = null;
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal DungLH.Util.Token.Core.UserData GetValidUserData(string loginname, string password, string applicationCode, CommonParam commonParam)
        {
            DungLH.Util.Token.Core.UserData result = null;
            try
            {
                AasLoginSDO loginSDO = new AasLoginSDO();
                loginSDO.ApplicationCode = applicationCode;
                loginSDO.Loginname = loginname;
                loginSDO.Password = password;
                User user = null;
                if (!new TokenLoginProcessor(commonParam).Run(loginSDO, ref user))
                {
                    LogSystem.Warn("Khong tim thay du lieu User dang nhap");
                }
                else
                {
                    result = new DungLH.Util.Token.Core.UserData();
                    result.ApplicationCode = applicationCode;
                    result.Email = user.Email;
                    result.Loginname = user.Loginname;
                    result.Mobile = user.Mobile;
                    result.Username = user.Username;
                }
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal bool IsGrantedUser(string loginname, string applicationCode, CommonParam commonParam)
        {
            bool result = false;
            try
            {
                AasAuthorizeSDO authorizeSDO = new AasAuthorizeSDO();
                authorizeSDO.ApplicationCode = applicationCode;
                authorizeSDO.Loginname = loginname;
                User user = null;
                if (!new TokenAuthorizeProcessor(commonParam).Run(authorizeSDO, ref user))
                {
                    LogSystem.Warn("Khong tim thay du lieu User dang nhap");
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
