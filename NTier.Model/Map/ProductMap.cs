using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.UnitPrice).IsOptional();
            Property(x => x.Quantity).IsOptional();
            Property(x => x.UnitsInStock).IsOptional();
            Property(x => x.ImagePath).IsOptional();

            HasRequired(x => x.SubCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SubCategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
