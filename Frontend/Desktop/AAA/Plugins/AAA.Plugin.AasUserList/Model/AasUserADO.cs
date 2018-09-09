using Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.AasUserList.Model
{
    public class AasUserADO : AAS.EFMODEL.DataModels.User
    {
        public string CreateTimeStr
        {
            get
            {
                if (this.CreateTime.HasValue)
                {
                    return DungLH.Util.DateTime.Convert.TimeNumberToTimeString(this.CreateTime.Value);
                }
                return null;
            }            
        }

        public string ModifyTimeStr
        {
            get
            {
                if (this.ModifyTime.HasValue)
                {
                    return DungLH.Util.DateTime.Convert.TimeNumberToTimeString(this.ModifyTime.Value);
                }
                return null;
            }
        }

        public bool Active
        {
            get
            {
                return this.IsActive == Constant.IS_TRUE;
            }
        }

        public string imageLock
        {
            get
            {
                if (this.Active)
                {
                    return "pack://application:,,,/Common.Resource;component/Icon/unlock_16.png";
                }
                else
                {
                    return "pack://application:,,,/Common.Resource;component/Icon/lock_16.png";
                }
            }
        }
    }
}
