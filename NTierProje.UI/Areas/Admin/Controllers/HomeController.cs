using NTier.Core.Entity.Enum;
using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProje.UI.Areas.Admin.Controllers
{

    public class HomeController : BaseController
    {
        OrderService _orderService;
        public HomeController()
        {
            _orderService = new OrderService();
        }
        public ActionResult Index()
        {
            CheckRole();
            //Onaylanmamış tüm siparişler admin'e gönderiliyor.
            List<Order> model = _orderService.GetDefaults(x => !x.Confirmed && x.Status == Status.Active);

            //Sipariş sayısını viewbag içerisinde gönderiliyor.
            ViewBag.Siparis = model.Count;
            return View();
        }
    }
}