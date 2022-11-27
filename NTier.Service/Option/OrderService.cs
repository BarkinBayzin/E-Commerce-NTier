using NTier.Core.Entity.Enum;
using NTier.Model.Entities;
using NTier.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Option
{
    public class OrderService:BaseService<Order>
    {
        /// <summary>
        /// List of pending orders
        /// </summary>
        /// <returns></returns>
        public List<Order> ListPendingOrders() =>
            GetDefaults(x => x.Confirmed == false && x.Status == Status.Active)
            .OrderByDescending(x => x.CreateDate).ToList();
        /// <summary>
        /// Get the count of pending orders
        /// </summary>
        /// <returns></returns>
        public int PendingOrderCount() => GetDefaults(x => x.Confirmed == false && x.Status == Status.Active).Count;
    }
}
