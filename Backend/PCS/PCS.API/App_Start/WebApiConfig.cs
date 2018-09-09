using DungLH.Util.Token.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace PCS.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Cai dat thu vien bang nuget
            //Install-Package Microsoft.AspNet.WebApi
            //Install-Package Microsoft.AspNet.WebApi.Cors
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new ApiAuthenticationProcessor()); //Comment neu ko co nhu cau xac thuc request
            AreaRegistration.RegisterAllAreas();
        }
    }
}
