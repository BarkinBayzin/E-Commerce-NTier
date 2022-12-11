using NTier.Core.Entity.Enum;
using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NTierProje.UI.Controllers
{
    public class HomeController : Controller
    {
        ProductService _productService;
        AppUserService _appUserService;
        CategoryService _categoryService;
        public HomeController()
        {
            _productService = new ProductService();
            _appUserService = new AppUserService();
            _categoryService = new CategoryService();
        }
        public ActionResult Index(Guid? id)
        {
            //ID API üzerinden gönderiliyor. Eğer boş ise authentication yapmıyoruz.
            if (id != null)
            {
                AppUser user = new AppUser();
                user = _appUserService.GetById((Guid)id);

                //string cookie = user.UserName.ToString();
                //FormsAuthentication.SetAuthCookie(cookie, true);

                Session["userId"] = user.Id;

                Session.Add("role", user.Role);

                if (user.Role == Role.Admin) return Redirect("/Admin/Home/Index");
            }

            var model = _productService.GetDefaults(x => x.UnitsInStock > 0 && x.Status != Status.Deleted).OrderByDescending(x => x.CreateDate).Take(16).ToList();
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            var list = _categoryService.GetActives();
            return PartialView("_CategoryList", list);
        }

        //Bu metot PartialView'ı yönlendirmek için kullanılıyor. ChildActionOnly bu action'ın sadece bu durumlarda cağırılabileceğini belirtir. Opsiyoneldir..
        [ChildActionOnly]
        public ActionResult ProductList()
        {
            var list = _productService.GetActives().OrderByDescending(x => x.CreateDate).Take(9).ToList();
            return PartialView("_ProductList", list );
        }

        public ActionResult Login()
        { return View(); }

        //Bu metot API üzerinden yönlendirilerek ulaşılmaktadır.
        public RedirectResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
    }
}