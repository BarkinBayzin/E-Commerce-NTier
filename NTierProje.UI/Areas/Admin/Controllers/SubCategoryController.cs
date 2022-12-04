using NTier.Model.Entities;
using NTier.Service.Option;
using NTierProje.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;

namespace NTierProje.UI.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        SubCategoryService _subCategoryService;
        CategoryService _categoryService;
        public SubCategoryController()
        {
            _categoryService= new CategoryService();
            _subCategoryService = new SubCategoryService();
        }
        public ActionResult List()
        {
            List<SubCategory> model = _subCategoryService.GetActives();
            return View(model);
        }
        public ActionResult Create()
        {
            List<Category> model = _categoryService.GetActives();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(SubCategory model)
        {
            model.Id = Guid.NewGuid();
            _subCategoryService.Add(model);
            return Redirect("/Admin/SubCategory/List");
        }
        public ActionResult Edit(Guid id)
        {
            SubCategoryVM model = new SubCategoryVM();
            model.SubCategory = _subCategoryService.GetById(id);
            model.Categories = _categoryService.GetActives();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SubCategory model)
        {
            _subCategoryService.Update(model);
            return Redirect("/Admin/SubCategory/List");
        }

        public RedirectResult Delete(Guid id)
        {
            _subCategoryService.Remove(id);
            return Redirect("/Admin/SubCategory/List");
        }
    }
}