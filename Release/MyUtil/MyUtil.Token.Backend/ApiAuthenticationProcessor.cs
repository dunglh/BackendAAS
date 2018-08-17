using MyUtil.CommonLogging;
using MyUtil.Token.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MyUtil.Token.Backend
{
    public class ApiAuthenticationProcessor : AuthorizeAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null) throw new Exception("actionContext is null");
            if (AuthenDisabled(actionContext) || AuthenRequest(actionContext))
            {
                return;
            }
            else
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new Exception("actionContext is null");
            actionContext.Response = CreateUnauthorizedResp(actionContext.ControllerContext.Request);
        }

        private HttpResponseMessage CreateUnauthorizedResp(HttpRequestMessage request)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            result.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            result.RequestMessage = request;
            result.Headers.Add(HttpHeaderConstant.BASIC_AUTH_HEADER_RESPONSE, HttpHeaderConstant.BASIC_AUTH_SCHEME);
            return result;
        }

        private static bool AuthenDisabled(HttpActionContext actionContext)
        {
            if (!actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            }
            return true;
        }

        private bool AuthenRequest(HttpActionContext actionContext)
        {
            bool result = false;
            try
            {
                var headers = actionContext.ControllerContext.Request.Headers;
                if (headers.Contains(HttpHeaderConstant.TOKEN_PARAM))
                {
                    string tokenCode = headers.GetValues(HttpHeaderConstant.TOKEN_PARAM).FirstOrDefault();
                    Credential credential = CredentialStore.GetAuthenticated(tokenCode, actionContext);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                throw;
            }
            return result;
        }
    }
}
