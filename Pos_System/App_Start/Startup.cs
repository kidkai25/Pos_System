using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pos_System.App_Start
{
    public class Startup
    {
        public void Configuration (IAppBuilder app)
        {

            //This will be used instead of form authentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "AppCookie",
                LoginPath = new PathString("/auth/login")
            }); 
        }
    }
}