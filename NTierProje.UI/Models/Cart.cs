using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierProje.UI.Models
{
    public class Cart
    {
        private Dictionary<Guid, Product> _cart = null;

        public Cart()
        {
            _cart = new Dictionary<Guid, Product>();
        }

        public List<Product> CartProductList
        {
            get => _cart.Values.ToList(); 
        }

        /// <summary>
        /// Seçilen ürünü sepete ekler
        /// </summary>
        /// <param name="item"></param>
        public void AddCart(Product item)
        {
            //Eğer o id'ye ait bir item yoksa id ve itemi dictionary içerisine değeri ile atıyoruz
            if (!_cart.ContainsKey(item.Id))
                _cart.Add(item.Id, item);
            else//Eğer o id varsa satın alınacak(sepete eklenecek) miktarı bir arttırır.
                _cart[item.Id].Quantity = (int.Parse(_cart[item.Id].Quantity) + 1).ToString();
        }
        /// <summary>
        /// Seçilen ürünü sepetten siler
        /// </summary>
        /// <param name="id"></param>
        public void RemoveCart(Guid id)
        {
            _cart.Remove(id);
        }
        /// <summary>
        /// Seçilen ürünün sepetteki adetini bir düşürür, eğer o elemandan daha kalmayacaksa siler.
        /// </summary>
        /// <param name="id"></param>
        public void DecreaseCart(Guid id)
        {
            //Sepetten bir azaltma
            _cart[id].Quantity = (int.Parse(_cart[id].Quantity) - 1).ToString();

            //Eğer sepette azaltırken başka o elemandan kalmadı ise tamamen sepetten siliyoruz
            if (int.Parse(_cart[id].Quantity) <= 0) _cart.Remove(id);
        }
        /// <summary>
        /// Seçilen ürünün adetini bir arttırır.
        /// </summary>
        /// <param name="id"></param>
        public void IncreaseCart(Guid id)
        {
            //Sepetteki ürünün miktarını bir arttırır.
            _cart[id].Quantity = (int.Parse(_cart[id].Quantity) + 1).ToString();
        }
    }
}