using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Adapter
{
    public abstract class AdapterBase
    {
        protected CommonParam param;
        public AdapterBase()
        {
            this.param = new CommonParam();
        }

        public AdapterBase(CommonParam commonParam)
        {
            this.param = commonParam != null ? commonParam : new CommonParam();
        }

        public string UserName { get; set; }
        protected string Input { get; set; }
        protected string Output { get; set; }
        protected string RequestUrl { get; set; }

        protected void LogInOut(LogType logType)
        {
            try
            {
                Logging("\n- InputData:" + Input + "\n- OutputData:" + Output, logType);
            }
            catch (Exception ex)
            {
                LogSystem.Error("AdapterBase.LogInOut.Exception.", ex);
            }
        }

        protected void LogInOut(string output, LogType logType)
        {
            try
            {
                Logging("\n- InputData:" + Input + "\n- OutputData:" + output, logType);
            }
            catch (Exception ex)
            {
                LogSystem.Error("AdapterBase.LogInOut.Exception.", ex);
            }
        }

        protected void Logging(string message, LogType en)
        {
            try
            {
                string threadInfo = GetThreadId();
                message = new StringBuilder().Append("- RequestUrl: ").Append(RequestUrl)
                    .Append("\n- UserName: ").Append(UserName)
                    .Append("\n- ThreadInfo: ").Append(threadInfo)
                    .Append(message).ToString();
                switch (en)
                {
                    case LogType.Debug:
                        LogSystem.Debug(message);
                        break;
                    case LogType.Info:
                        LogSystem.Info(message);
                        break;
                    case LogType.Warn:
                        LogSystem.Warn(message);
                        break;
                    case LogType.Error:
                        LogSystem.Error(message);
                        break;
                    case LogType.Fatal:
                        LogSystem.Fatal(message);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error("AdapterBase.Logging.Exception.", ex);
            }
        }

        protected static string GetThreadId()
        {
            try
            {
                return System.Threading.Thread.CurrentThread.ManagedThreadId + "";
            }
            catch (Exception ex)
            {
                LogSystem.Error("AdapterBase.GetThreadId.Exception.", ex);
                return "";
            }
        }

        /// <summary>
        /// True neu data != null.
        /// False neu nguoc lai.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected bool IsNotNull(Object data)
        {
            bool result = false;
            try
            {
                result = (data != null);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// True neu string != NullOrEmpty.
        /// False neu nguoc lai.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected bool IsNotNullOrEmpty(string data)
        {
            bool result = false;
            try
            {
                result = (!String.IsNullOrEmpty(data));
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Su dung de kiem tra list co du lieu.
        /// True neu listData != null && Count > 0.
        /// False neu nguoc lai.
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        protected bool IsNotNullOrEmpty(ICollection listData)
        {
            bool result = false;
            try
            {
                result = (listData != null && listData.Count > 0);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Su dung de kiem tra cac truong ID trong CSDL.
        /// True neu id > 0.
        /// False neu nguoc lai.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool IsGreaterThanZero(long id)
        {
            bool result = false;
            try
            {
                result = (id > 0);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        protected enum LogType
        {
            Debug,
            Info,
            Warn,
            Error,
            Fatal,
        }
    }
}
