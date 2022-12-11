using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProje.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public void CheckRole()
        {
            try
            {
                var role = Session["role"].ToString().ToLower();
                if (role != "admin" && role != "member") Redirect("/Home/Index");
                else Redirect("/Home/Login");

            }
            catch (Exception ex)
            {
                Redirect("/Home/Login");
            }
        }
    }
}