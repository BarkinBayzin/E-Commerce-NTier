using NTier.Core.Entity.Enum;
using NTier.Model.Entities;
using NTier.Service.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Option
{
    public class CategoryService:BaseService<Category>
    {
        public override List<Category> GetActives() => Context.Categories.Where(x => x.Status == Status.Active).Include(x => x.SubCategories).ToList();
    }
}
