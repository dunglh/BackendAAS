using DungLH.Util.CommonLogging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Core
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            try
            {
                ClassName = this.GetType().Name;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        protected string ClassName { get; set; }
        protected string MethodName { get; set; }
        public string UserName { get; set; }
        protected string Input { get; set; }
        protected string Output { get; set; }

        protected void LogInOut()
        {
            try
            {
                MethodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                Logging("\n- InputData:" + Input + "\n- OutputData:" + Output, LogType.Info);
            }
            catch (Exception ex)
            {
                try
                {
                    LogSystem.Error("EntityBase.LogInOut.Exception.", ex);
                }
                catch (Exception)
                {
                }
            }
        }

        protected void LogInOut(string output)
        {
            try
            {
                MethodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                Logging("\n- InputData:" + Input + "\n- OutputData:" + output, LogType.Info);
            }
            catch (Exception ex)
            {
                try
                {
                    LogSystem.Error("EntityBase.LogInOut.Exception.", ex);
                }
                catch (Exception)
                {
                }
            }
        }

        protected void Logging(string message, LogType en)
        {
            try
            {
                try
                {
                    if (String.IsNullOrEmpty(MethodName))
                    {
                        MethodName = string.Format("{0}", new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name);
                    }
                }
                catch (Exception ex)
                {
                    LogSystem.Error(ex);
                }
                string threadInfo = GetThreadId();
                message = new StringBuilder().Append("- ClassName: ").Append(ClassName)
                    .Append("\n- MethodName: ").Append(MethodName).
                    Append("\n- UserName: ").Append(UserName)
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
                try
                {
                    LogSystem.Error("EntityBase.Logging.Exception.", ex);
                }
                catch (Exception)
                {
                }
            }
        }

        protected string GetInfoProcess()
        {
            try
            {
                return (String.IsNullOrWhiteSpace(ClassName) ? "" : ClassName + ".") +
                    (String.IsNullOrWhiteSpace(MethodName) ? "" : MethodName + ".") +
                    (String.IsNullOrWhiteSpace(UserName) ? "" : UserName + ".");
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return "";
            }
        }

        protected static string GetThreadId()
        {
            try
            {
                return "___{ThreadId=" + System.Threading.Thread.CurrentThread.ManagedThreadId + "}___";
            }
            catch (Exception ex)
            {
                LogSystem.Error("EntityBase.GetThreadId.Exception.", ex);
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
