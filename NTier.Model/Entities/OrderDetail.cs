using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    public class OrderDetail:CoreEntity
    {
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }

        //Fk for Product
        public Guid ProductID { get; set; }
        public Guid OrderID { get; set; }
        //Navigation Props. Begin
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
