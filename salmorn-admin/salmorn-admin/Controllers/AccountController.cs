using salmorn_admin.BO;
using salmorn_admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace salmorn_admin.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            LoginScreenModel data = new LoginScreenModel()
            {
                email = "", password = ""
            };
            return View(data);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(LoginScreenModel data)
        {
            AccountBO bo = new AccountBO();
            var usr = bo.getUser(data.email, data.password);
            if (usr != null)
            {

                UserSerializeModel serializeModel = new UserSerializeModel()
                {
                    DisplayName = usr.displayName,
                    Email = usr.email,
                    roles = usr.roleMappings.Select(m=>m.role).ToList(),
                    UserId = usr.userId
                };

                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };

                string userData = serializer.Serialize(serializeModel);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,
                          usr.displayName,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(20),
                         data.remember,
                         userData);

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email หรือ Password ไม่ถูกต้อง";
                return View(data);
            }
        }
    }
}