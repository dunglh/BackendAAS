﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.CommonLogging
{
    public static class LogUtil
    {

        /// <summary>
        /// Su dung CommonUtil.GetMemberName(() => variable) de lay ra ten bien variable
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string TraceData(string name, object data)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("___");
                sb.Append(name + ":");
                sb.Append(JsonConvert.SerializeObject(data));
                sb.Append("___");

                return sb.ToString();
            }
            catch (Exception)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("___Inventec.Common.Logging.LogUtil.TraceData has exception when trace data [" + name + "]___");
                    return sb.ToString();
                }
                catch (Exception)
                {
                    return "___Inventec.Common.Logging.LogUtil.TraceData has exception___";
                }
            }
        }
        
        public static string TraceDbException(System.Data.Entity.Validation.DbEntityValidationException e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("___Loi tuong tac CDSL (DbEntityValidationException)").Append("{");
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        sb.Append(string.Format("{0}:{1}; ", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                sb.Append("}___");
                return sb.ToString();
            }
            catch (Exception)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("___Loi tuong tac CSDL").Append("{...LogUtil.TraceDbException. Co exception khi logging...}___");
                    return sb.ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static void LogActionSuccess(string className, string methodName, string userName)
        {
            try
            {
                LogSystem.Info(new StringBuilder(className).Append(".").Append(methodName).Append(".Username=").Append(userName).Append(".Xu ly thanh cong.").ToString());
            }
            catch (Exception ex)
            {
                try
                {
                    LogSystem.Error("___Co exception trong qua trinh ghi log success action___");
                    LogSystem.Error(ex);
                }
                catch (Exception)
                {

                }
            }
        }

        public static void LogActionFail(string className, string methodName, string userName)
        {
            try
            {
                LogSystem.Info(new StringBuilder(className).Append(".").Append(methodName).Append(".Username=").Append(userName).Append(".Xu ly that bai.").ToString());
            }
            catch (Exception ex)
            {
                try
                {
                    LogSystem.Error("___Co exception trong qua trinh ghi log fail action___");
                    LogSystem.Error(ex);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
