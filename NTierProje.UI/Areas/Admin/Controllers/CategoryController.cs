using NTier.Model.Entities;
using NTier.Service.Option;
using NTierProje.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProje.UI.Areas.Admin.Controllers
{
    //[CustomAuthorize(Role.Admin)]
    public class CategoryController : BaseController
    {
        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        // GET: Admin/Category
        public ActionResult List()
        {
            List<Category> model = _categoryService.GetActives();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult Update(Guid id)
        {
            Category category = _categoryService.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            _categoryService.Update(category);
            return Redirect("/Admin/Category/List");
        }

        public RedirectResult Delete(Guid id)
        {
            _categoryService.Remove(id);
            return Redirect("/Admin/Category/List");
        }
    }
}