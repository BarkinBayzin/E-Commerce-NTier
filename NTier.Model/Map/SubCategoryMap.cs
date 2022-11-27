using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class SubCategoryMap:CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");
            Property(x => x.Name).IsRequired();
            Property(x => x.Description).IsOptional();
            Property(x => x.Tag).IsOptional();

            HasMany(x => x.Products)
                .WithRequired(x => x.SubCategory)
                .HasForeignKey(x => x.SubCategoryID);
        }
    }
}
