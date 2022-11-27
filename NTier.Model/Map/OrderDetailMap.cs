using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(x => x.UnitPrice).IsOptional();
            Property(x => x.Quantity).IsOptional();
        }
    }
}
