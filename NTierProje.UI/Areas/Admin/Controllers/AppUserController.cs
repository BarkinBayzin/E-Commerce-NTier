using NTier.Model.Entities;
using NTier.Service.Option;
using NTierProje.UI.Attributes;
using NTierProje.UI.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProje.UI.Areas.Admin.Controllers
{
    //[CustomAuthorize(Role.Admin)]
    public class AppUserController : BaseController
    {
        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }
        // GET: Admin/AppUser
        public ActionResult List(int page =1)
        {
            List<AppUser> model = _appUserService.GetActives();
            return View(model.ToPagedList(page, 10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AppUser data, HttpPostedFileBase image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", image);
            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
                data.ImagePath = "~/Content/Images/testPhoto.jpg";

            _appUserService.Add(data);
            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult Edit(Guid id)
        {
            AppUser model = _appUserService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AppUser data, HttpPostedFileBase image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                //Elimizdeki imajı güncelleme aşamasında kaybetmemek için bir kontrol daha uyguluyoruz.
                AppUser updated = _appUserService.GetById(data.Id);
                if (updated.ImagePath == null || updated.ImagePath == "~/Content/Images/testPhoto.jpg")
                {
                    data.ImagePath = "~/Content/Images/testPhoto.jpg";
                }
                else
                {
                    data.ImagePath = updated.ImagePath;
                }
            }

            _appUserService.Update(data);
            return Redirect("/Admin/AppUser/List");
        }

        public RedirectResult Delete(Guid id)
        {
            _appUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }
    }
}