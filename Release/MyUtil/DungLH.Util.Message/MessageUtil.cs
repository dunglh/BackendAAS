using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Message
{
    class MessageUtil
    {
        public static string GetMessageAlert(CommonParam param)
        {
            string result = "";
            try
            {
                if (param.Messages != null && param.Messages.Count > 0)
                {
                    result = result + param.GetMessage();
                }
                if (param.BugCodes != null && param.BugCodes.Count > 0)
                {
                    result = result + "\r\nMã sự cố: " + param.GetBugCode();
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error("Co exception khi GetMessageAlert.", ex);
            }
            return result;
        }

        public static void SetResultParam(CommonParam param, bool success)
        {
            try
            {
                if (param.Messages == null)
                {
                    param.Messages = new List<string>();
                }
                if (success)
                    param.Messages.Insert(0, "Xử lý thành công");
                else
                    param.Messages.Insert(0, "Xử lý thất bại");
            }
            catch (Exception ex)
            {
                LogSystem.Error("Co exception khi SetResultParam.", ex);
            }
        }
    }
}
