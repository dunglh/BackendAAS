using DungLH.Util.CommonLogging;
using DungLH.Util.Token.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DungLH.Util.WebApiConsumer
{
    public class ApiConsumer
    {
        private string baseUri = null;
        private string tokenCode = null;
        private string applicationCode = null;

        public ApiConsumer(string baseuri, string applicationcode)
        {
            this.Init(baseuri, null, applicationcode);
        }

        public ApiConsumer(string baseuri, string tokencode, string applicationcode)
        {
            this.Init(baseuri, tokencode, applicationcode);
        }

        private void Init(string baseuri, string tokencode, string appcode)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            this.baseUri = baseuri;
            this.tokenCode = tokencode;
            this.applicationCode = appcode;
        }

        public void SetTokenCode(string tokencode)
        {
            this.tokenCode = tokencode;
        }

        public void SetBaseUri(string baseuri)
        {
            this.baseUri = baseuri;
        }

        public string GetTokemCode()
        {
            return this.tokenCode;
        }

        public string GetBaseUri()
        {
            return this.baseUri;
        }

        private bool Check()
        {
            bool result = true;
            if (String.IsNullOrWhiteSpace(this.baseUri))
            {
                LogSystem.Error("Khong co dia chi BaseUri");
                return false;
            }
            return result;
        }

        public T Get<T>(string uri, object commonParam, object filter, params object[] listParam)
        {
            return this.Get<T>(uri, commonParam, filter, ApiConfig.TIME_OUT, listParam);
        }

        public T Get<T>(string uri, object commonParam, object filter, int timeout, params object[] listParam)
        {
            T result = default(T);
            if (!this.Check())
            {
                return result;
            }
            using (var httpClient = new HttpClient())
            {
                string requestUrl = "";
                this.RequestBuilder(httpClient, uri, timeout, ref requestUrl, listParam);
                ApiParam apiParam = new ApiParam();
                if (filter != null || commonParam != null)
                {
                    apiParam.CommonParam = commonParam;
                    apiParam.ApiData = filter;
                    string param = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(apiParam)));
                    requestUrl += string.Format("{0}={1}", ApiConfig.API_PARAM, param);
                }

                HttpResponseMessage responseMessage = httpClient.GetAsync(requestUrl).Result;
                if (!responseMessage.IsSuccessStatusCode)
                {
                    LogSystem.Error(String.Format("Loi khi goi api: {0}/{1} " +
                        "\nStatusCode: {2} " +
                        "\nInput: {3}{4}", httpClient.BaseAddress.AbsoluteUri, uri, responseMessage.StatusCode.GetHashCode(), JsonConvert.SerializeObject(filter), JsonConvert.SerializeObject(commonParam)));
                    throw new ApiException(responseMessage.StatusCode);
                }

                string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                try
                {
                    result = JsonConvert.DeserializeObject<T>(responseData);
                }
                catch (Exception ex)
                {
                    LogSystem.Error("responseData: " + responseData);
                    LogSystem.Error("requestUrl: " + requestUrl);
                    LogSystem.Error(LogUtil.TraceData("apiParam", apiParam));
                    throw ex;
                }
            }
            return result;
        }

        public T Post<T>(string uri, object commonParam, object data, params object[] listParam)
        {
            return this.Post<T>(uri, commonParam, data, ApiConfig.TIME_OUT, listParam);
        }

        public T Post<T>(string uri, object commonParam, object data, int timeount, params object[] listParam)
        {
            T result = default(T);
            if (!this.Check())
            {
                return result;
            }

            using (var httpClient = new HttpClient())
            {
                string requestUrl = "";
                this.RequestBuilder(httpClient, uri, timeount, ref requestUrl, listParam);
                ApiParam apiParam = new ApiParam();
                if (data != null || commonParam != null)
                {
                    apiParam.ApiData = data;
                    apiParam.CommonParam = commonParam;
                }

                HttpResponseMessage responseMessage = httpClient.PostAsJsonAsync(requestUrl, apiParam).Result;
                if (!responseMessage.IsSuccessStatusCode)
                {
                    LogSystem.Error(String.Format("Loi khi goi api: {0}/{1} " +
                        "\nStatusCode: {2} " +
                        "\nInput: {3}", httpClient.BaseAddress.AbsoluteUri, uri, responseMessage.StatusCode.GetHashCode(), JsonConvert.SerializeObject(data)));
                    throw new ApiException(responseMessage.StatusCode);
                }

                string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                try
                {
                    result = JsonConvert.DeserializeObject<T>(responseData);
                }
                catch (Exception ex)
                {
                    LogSystem.Error("responseData: " + responseData);
                    LogSystem.Error("requestUrl: " + requestUrl);
                    LogSystem.Error(LogUtil.TraceData("apiParam", apiParam));
                    throw ex;
                }
            }
            return result;
        }

        public async Task<T> GetAsync<T>(string uri, object commonParam, object filter, params object[] listParam)
        {
            return await this.GetAsync<T>(uri, commonParam, filter, ApiConfig.TIME_OUT, listParam);
        }

        public async Task<T> GetAsync<T>(string uri, object commonParam, object filter, int timeout, params object[] listParam)
        {
            T result = default(T);
            if (!this.Check())
            {
                return result;
            }
            using (var httpClient = new HttpClient())
            {
                string requestUrl = "";
                this.RequestBuilder(httpClient, uri, timeout, ref requestUrl, listParam);
                ApiParam apiParam = new ApiParam();
                if (filter != null || commonParam != null)
                {
                    apiParam.CommonParam = commonParam;
                    apiParam.ApiData = filter;
                    string param = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(apiParam)));
                    requestUrl += string.Format("{0}={1}", ApiConfig.API_PARAM, param);
                }

                HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUrl).ConfigureAwait(false);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    LogSystem.Error(String.Format("Loi khi goi api: {0}/{1} " +
                        "\nStatusCode: {2} " +
                        "\nInput: {3}{4}", httpClient.BaseAddress.AbsoluteUri, uri, responseMessage.StatusCode.GetHashCode(), JsonConvert.SerializeObject(filter), JsonConvert.SerializeObject(commonParam)));
                    throw new ApiException(responseMessage.StatusCode);
                }

                string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                try
                {
                    result = JsonConvert.DeserializeObject<T>(responseData);
                }
                catch (Exception ex)
                {
                    LogSystem.Error("responseData: " + responseData);
                    LogSystem.Error("requestUrl: " + requestUrl);
                    LogSystem.Error(LogUtil.TraceData("apiParam", apiParam));
                    throw ex;
                }
            }
            return result;
        }

        public async Task<T> PostAsync<T>(string uri, object commonParam, object data, params object[] listParam)
        {
            return await this.PostAsync<T>(uri, commonParam, data, ApiConfig.TIME_OUT, listParam);
        }

        public async Task<T> PostAsync<T>(string uri, object commonParam, object data, int timeount, params object[] listParam)
        {
            T result = default(T);
            if (!this.Check())
            {
                return result;
            }

            using (var httpClient = new HttpClient())
            {
                string requestUrl = "";
                this.RequestBuilder(httpClient, uri, timeount, ref requestUrl, listParam);
                ApiParam apiParam = new ApiParam();
                if (data != null || commonParam != null)
                {
                    apiParam.ApiData = data;
                    apiParam.CommonParam = commonParam;
                }

                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync(requestUrl, apiParam).ConfigureAwait(false);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    LogSystem.Error(String.Format("Loi khi goi api: {0}/{1} " +
                        "\nStatusCode: {2} " +
                        "\nInput: {3}", httpClient.BaseAddress.AbsoluteUri, uri, responseMessage.StatusCode.GetHashCode(), JsonConvert.SerializeObject(data)));
                    throw new ApiException(responseMessage.StatusCode);
                }

                string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                try
                {
                    result = JsonConvert.DeserializeObject<T>(responseData);
                }
                catch (Exception ex)
                {
                    LogSystem.Error("responseData: " + responseData);
                    LogSystem.Error("requestUrl: " + requestUrl);
                    LogSystem.Error(LogUtil.TraceData("apiParam", apiParam));
                    throw ex;
                }
            }
            return result;
        }

        private void RequestBuilder(HttpClient httpClient, string uri, int timeout, ref string requestUrl, params object[] listParam)
        {
            httpClient.BaseAddress = new Uri(this.baseUri);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add(HttpHeaderConstant.TOKEN_PARAM, this.tokenCode);
            httpClient.DefaultRequestHeaders.Add(HttpHeaderConstant.APPLICATION_CODE_PARAM, this.applicationCode);
            httpClient.Timeout = new TimeSpan(0, 0, timeout);

            requestUrl = string.Format("{0}?", uri);

            if (listParam != null && listParam.Length > 0)
            {
                if (listParam.Length % 2 != 0)
                {
                    throw new ArgumentException("ListParam khong hop le. So luong param phai la so chan");
                }

                for (int i = 0; i < listParam.Length;)
                {
                    requestUrl += string.Format("{0}={1}&", HttpUtility.UrlEncode(listParam[i] + ""), HttpUtility.UrlEncode(listParam[i + 1] + ""));
                    i = i + 2;
                }
            }
        }

        public T PostWithoutApiParam<T>(string uri, object data, params object[] listParam)
        {
            return this.PostWithoutApiParam<T>(uri, data, ApiConfig.TIME_OUT, listParam);
        }

        public T PostWithoutApiParam<T>(string uri, object data, int timeount, params object[] listParam)
        {
            T result = default(T);
            if (!this.Check())
            {
                return result;
            }

            using (var httpClient = new HttpClient())
            {
                string requestUrl = "";
                this.RequestBuilder(httpClient, uri, timeount, ref requestUrl, listParam);

                HttpResponseMessage responseMessage = httpClient.PostAsJsonAsync(requestUrl, data).Result;
                if (!responseMessage.IsSuccessStatusCode)
                {
                    LogSystem.Error(String.Format("Loi khi goi api: {0}/{1} " +
                        "\nStatusCode: {2} " +
                        "\nInput: {3}", httpClient.BaseAddress.AbsoluteUri, uri, responseMessage.StatusCode.GetHashCode(), JsonConvert.SerializeObject(data)));
                    throw new ApiException(responseMessage.StatusCode);
                }

                string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                try
                {
                    result = JsonConvert.DeserializeObject<T>(responseData);
                }
                catch (Exception ex)
                {
                    LogSystem.Error("responseData: " + responseData);
                    LogSystem.Error("requestUrl: " + requestUrl);
                    LogSystem.Error(LogUtil.TraceData("data", data));
                    throw ex;
                }
            }
            return result;
        }

    }
}
