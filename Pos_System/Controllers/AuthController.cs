using Pos_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Pos_System.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {

            //Credential Validation
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.Username == "admin" && model.Password == "123456")
            {
                var identity = new ClaimsIdentity(new[] {
                                               new Claim(ClaimTypes.Name,"Abdul" ),
                                               new Claim(ClaimTypes.Role, "admin")
                }, "AppCookie");

                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                authManager.SignIn(identity);

                 Url.Action("Index", "Product");
            }


            return View(model);
        }
    }

  
}