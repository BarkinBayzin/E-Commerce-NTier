using NTier.Model.Entities;
using NTier.Service.Option;
using NTierProje.UI.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProje.UI.Areas.Member.Controllers
{
    public class CheckOutController : Controller
    {
        OrderService _orderService;
        ProductService _productService;
        AppUserService _appUserService;
        public CheckOutController()
        {
            _appUserService= new AppUserService();
            _orderService= new OrderService();
            _productService= new ProductService();
        }

        public ActionResult Add()
        {
            if (Session["sepet"] == null)
            {
                return Redirect("~/Home/Index");
            }

            ProductCart cart = Session["sepet"] as ProductCart;

            Order order = new Order();

            AppUser user = _appUserService.GetById((Guid)Session["userId"]);
            order.AppUserID = user.Id;
            order.AppUser = user;

            _appUserService.DetachEntity(user);

            Product product= new Product();
            foreach (var item in cart.CartProductList)
            {
                product = _productService.GetById(item.Id);

                order.OrderDetails.Add(new OrderDetail
                {
                    ProductID = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });

                _productService.DetachEntity(product);
            }

            _orderService.Add(order);

            Session["sepet"] = null;

            return Redirect("/Home/Index");
        }


    }
}