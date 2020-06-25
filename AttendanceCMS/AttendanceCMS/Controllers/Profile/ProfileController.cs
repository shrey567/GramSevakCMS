using AttendanceCMS.Models.SessionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceCMS.Controllers.Profile
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Profiles()
        {
            //    if (SessionHandler.Current.AppId != 0)
            //    {
            //        return View();
            //    }
            //    else
            //        Redirect("/Account/Login");
            return View();
        }
    }
}