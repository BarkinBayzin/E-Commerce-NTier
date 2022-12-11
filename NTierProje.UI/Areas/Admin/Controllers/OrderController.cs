using NTier.Model.Entities;
using NTier.Service.Option;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProje.UI.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        OrderService _orderService;
        ProductService _productService;
        OrderDetailService _orderDetailService;

        public OrderController()
        {
            _orderService = new OrderService();
            _productService = new ProductService();
            _orderDetailService = new OrderDetailService();
        }

        [HttpGet]
        public ActionResult List(int page = 1)
        {
            //Admin kontrolü
            CheckRole();

            //Daha ponaylanmamış tüm siparişleri listele
            List<Order> model = _orderService.ListPendingOrders();
            return View(model.ToPagedList(page, 10));
        }

        //Onaylanmamış sipariş sayısını ana sayfada listeler
        public JsonResult OrderCount()
        {
            int count = _orderService.PendingOrderCount();
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(Guid id)
        {
            CheckRole();

            List<OrderDetail> model = _orderDetailService.GetDefaults(x => x.Order.Id == id);
            return View(model);
        }

        public RedirectResult ConfirmOrder(Guid id)
        {
            CheckRole();

            Order order = new Order();
            order = _orderService.GetById(id);

            order.Confirmed = true;
            _orderService.Update(order);

            foreach (var item in order.OrderDetails)
            {
                Product p = _productService.GetById(item.ProductID);
                p.UnitsInStock -= item.Quantity;
                _productService.Update(p);
            }

            return Redirect("~/Admin/Order/List");
        }

        public RedirectResult RejectOrder(Guid id)
        {
            CheckRole();

            Order order = _orderService.GetById(id);

            order.Confirmed = false;

            order.Status = NTier.Core.Entity.Enum.Status.Deleted;
            
            _orderService.Update(order);

            return Redirect("~/Admin/Order/List");
        }
    }
}