using DungLH.Util.WebApiConsumer;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Adapter
{
    public class BackendAdapter : AdapterBase
    {
        private string uriFormat = "{0}/{1}";
        private static string STR_CANNOT_CONNECT_TO_SERVER = "Không kết nối được máy chủ";
        private static string STR_SESSION_TIMEOUT = "Phiên làm việc đã hết hiệu lực";

        public BackendAdapter(CommonParam param)
            : base(param)
        {

        }

        public T Get<T>(string uri, ApiConsumer consumer, CommonParam commonParam, object filter, int? timeout, params object[] listParam)
        {
            T result = default(T);
            try
            {
                ApiResultObject<T> rs = null;
                if (timeout.HasValue)
                {
                    rs = consumer.Get<ApiResultObject<T>>(uri, commonParam, filter, timeout.Value, listParam);
                }
                else
                {
                    rs = consumer.Get<ApiResultObject<T>>(uri, commonParam, filter, listParam);
                }

                if (rs != null)
                {
                    if (rs.Param != null)
                    {
                        this.param.Messages.AddRange(rs.Param.Messages);
                        this.param.BugCodes.AddRange(rs.Param.BugCodes);
                    }
                    if (rs.Success) result = rs.Data;
                }

                if (rs == null || !rs.Success || rs.Data == null)
                {
                    this.Input = LogUtil.TraceData("\n     + filter", filter) + LogUtil.TraceData("\n     + CommonParam", commonParam) + LogUtil.TraceData("\n     + listParam", listParam);
                    this.RequestUrl = String.Format(uriFormat, consumer.GetBaseUri(), uri);
                    Logging(JsonConvert.SerializeObject(rs), LogType.Error);
                }
            }
            catch (ApiException ex)
            {
                LogSystem.Error(LogUtil.TraceData("StatusCode: ", ex.StatusCode));
                LogSystem.Error(ex);
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    this.param.Messages.Add(STR_CANNOT_CONNECT_TO_SERVER);
                }
                else if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    param.Messages.Add(STR_SESSION_TIMEOUT);
                    param.HasException = true;
                }
            }
            catch (AggregateException ex)
            {
                LogSystem.Error(ex);
                this.param.Messages.Add(STR_CANNOT_CONNECT_TO_SERVER);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public T Post<T>(string uri, ApiConsumer consumer, CommonParam commonParam, object data, int? timeout, params object[] listParam)
        {
            T result = default(T);
            try
            {
                ApiResultObject<T> rs = null;
                if (timeout.HasValue)
                {
                    rs = consumer.Post<ApiResultObject<T>>(uri, commonParam, data, timeout.Value, listParam);
                }
                else
                {
                    rs = consumer.Post<ApiResultObject<T>>(uri, commonParam, data, listParam);
                }

                if (rs != null)
                {
                    if (rs.Param != null)
                    {
                        this.param.Messages.AddRange(rs.Param.Messages);
                        this.param.BugCodes.AddRange(rs.Param.BugCodes);
                    }
                    if (rs.Success) result = rs.Data;
                }

                if (rs == null || !rs.Success || rs.Data == null)
                {
                    this.Input = LogUtil.TraceData("\n     + data", data) + LogUtil.TraceData("\n     + CommonParam", commonParam) + LogUtil.TraceData("\n     + listParam", listParam);
                    this.RequestUrl = String.Format(uriFormat, consumer.GetBaseUri(), uri);
                    Logging(JsonConvert.SerializeObject(rs), LogType.Error);
                }
            }
            catch (ApiException ex)
            {
                LogSystem.Error(LogUtil.TraceData("StatusCode: ", ex.StatusCode));
                LogSystem.Error(ex);
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    this.param.Messages.Add(STR_CANNOT_CONNECT_TO_SERVER);
                }
                else if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    param.Messages.Add(STR_SESSION_TIMEOUT);
                    param.HasException = true;
                }
            }
            catch (AggregateException ex)
            {
                LogSystem.Error(ex);
                this.param.Messages.Add(STR_CANNOT_CONNECT_TO_SERVER);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public ApiResultObject<T> GetRO<T>(string uri, ApiConsumer consumer, CommonParam commonParam, object filter, int? timeout, params object[] listParam)
        {
            ApiResultObject<T> result = null;
            try
            {
                if (timeout.HasValue)
                {
                    result = consumer.Get<ApiResultObject<T>>(uri, commonParam, filter, timeout.Value, listParam);
                }
                else
                {
                    result = consumer.Get<ApiResultObject<T>>(uri, commonParam, filter, listParam);
                }

                if (result != null)
                {
                    if (result.Param != null)
                    {
                        this.param.Messages.AddRange(result.Param.Messages);
                        this.param.BugCodes.AddRange(result.Param.BugCodes);
                    }
                }

                if (result == null || !result.Success || result.Data == null)
                {
                    this.Input = LogUtil.TraceData("\n     + filter", filter) + LogUtil.TraceData("\n     + CommonParam", commonParam) + LogUtil.TraceData("\n     + listParam", listParam);
                    this.RequestUrl = String.Format(uriFormat, consumer.GetBaseUri(), uri);
                    Logging(JsonConvert.SerializeObject(result), LogType.Error);
                }
            }
            catch (ApiException ex)
            {
                LogSystem.Error(LogUtil.TraceData("StatusCode: ", ex.StatusCode));
                LogSystem.Error(ex);
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    this.param.Messages.Add(STR_CANNOT_CONNECT_TO_SERVER);
                }
                else if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    param.Messages.Add(STR_SESSION_TIMEOUT);
                    param.HasException = true;
                }
            }
            catch (AggregateException ex)
            {
                LogSystem.Error(ex);
                this.param.Messages.Add(STR_CANNOT_CONNECT_TO_SERVER);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }
    }
}
