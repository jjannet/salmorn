using salmorn_admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace salmorn_admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", JSettings.GoogleCloudStorage.AcountAPIKeyPath);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                UserSerializeModel serializeModel = serializer.Deserialize<UserSerializeModel>(authTicket.UserData);

                UserModel newUser = new UserModel(authTicket.Name)
                {
                    DisplayName = serializeModel.DisplayName,
                    Email = serializeModel.Email,
                    roles = serializeModel.roles,
                    UserId = serializeModel.UserId
                };

                HttpContext.Current.User = newUser;
            }
        }
    }
}
