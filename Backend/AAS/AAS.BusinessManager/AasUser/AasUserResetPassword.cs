using AAS.EFMODEL.DataModels;
using AutoMapper;
using MyUtil.Backend.MANAGER;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.BusinessManager.AasUser
{
    class AasUserResetPassword : BusinessBase
    {
        private AasUserUpdate aasUserUpdate;
        internal AasUserResetPassword()
            : base()
        {
            this.aasUserUpdate = new AasUserUpdate(param);
        }

        internal AasUserResetPassword(CommonParam param)
            : base(param)
        {
            this.aasUserUpdate = new AasUserUpdate(param);
        }

        internal bool Run(long id)
        {
            bool result = false;
            try
            {
                bool valid = true;
                User raw = null;
                AasUserCheck checker = new AasUserCheck(param);
                valid = valid && IsGreaterThanZero(id);
                valid = valid && checker.VerifyId(id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
                    Mapper.CreateMap<User, User>();
                    User beforeUpdate = Mapper.Map<User>(raw);
                    raw.Password = new MyUtil.Token.Password.PasswordManager().HashPassword(raw.Loginname, raw.Salt, raw.Loginname);
                    if (!this.aasUserUpdate.Update(raw, beforeUpdate))
                    {
                        throw new Exception("Reset passwod that bai");
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MyUtil.CommonLogging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
    }
}
