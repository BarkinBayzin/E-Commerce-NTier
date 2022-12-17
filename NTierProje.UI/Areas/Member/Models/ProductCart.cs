using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierProje.UI.Areas.Member.Models
{
    public class ProductCart
    {
        private Dictionary<Guid, ProductVM> _cart = null;

        public ProductCart()
        {
              _cart = new Dictionary<Guid, ProductVM>();
        }

        public List<ProductVM> CartProductList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }

        public void AddCart(ProductVM item)
        {
            if(!_cart.ContainsKey(item.Id)) _cart.Add(item.Id, item);
            else _cart[item.Id].Quantity++;
        }

        public void RemoveCart(Guid id)
        {
            _cart.Remove(id);
        }

        public void DecreaseCart(Guid id)
        {
            _cart[id].Quantity--;

            if(_cart[id].Quantity <= 0) _cart.Remove(id);
        }

        public void IncreaseCart(Guid id)
        {
            _cart[id].Quantity++;
        }


    }
}