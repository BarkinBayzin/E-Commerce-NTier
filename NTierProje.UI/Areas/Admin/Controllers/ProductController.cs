using NTier.Model.Entities;
using NTier.Service.Option;
using NTierProje.UI.Areas.Admin.Models;
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
    public class ProductController : BaseController
    {
        ProductService _productService;
        SubCategoryService _subCategoryService;
        public ProductController()
        {
            _subCategoryService = new SubCategoryService();
            _productService = new ProductService();
        }

        public ActionResult List(int page = 1)
        {
            CheckRole();
            List<Product> model = _productService.GetActives().OrderByDescending(x => x.CreateDate).ToList();
            return View(model.ToPagedList(page, 10));
        }

        public ActionResult Create()
        {
            List<SubCategory> model = _subCategoryService.GetActives();
            return View(model);
        }

        [HttpPost]
        public RedirectResult Create(Product data, HttpPostedFileBase image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
                data.ImagePath = "~/Content/Images/testPhoto.jpg";

            _productService.Add(data);
            return Redirect("/Admin/Product/List");
        }

        public ActionResult Edit(Guid id)
        {
            ProductUpdateVM model = new ProductUpdateVM();
            model.Product = _productService.GetById(id);
            model.SubCategories = _subCategoryService.GetActives();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product data, HttpPostedFileBase image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                Product updated = _productService.GetById(data.Id);
                if (updated.ImagePath == null || updated.ImagePath == "~/Content/Images/testPhoto.jpg")
                {
                    data.ImagePath = "~/Content/Images/testPhoto.jpg";
                }
                else
                {
                    data.ImagePath = updated.ImagePath;
                }
            }

            _productService.Update(data);
            return Redirect("/Admin/Product/List");
        }

        public RedirectResult Delete(Guid id)
        {
            _productService.Remove(id);
            return Redirect("/Admin/Product/List");
        }
    }
}