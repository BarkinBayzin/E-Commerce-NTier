using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    public class Category:CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation Props Begin.
        public List<SubCategory> SubCategories { get; set; }

    }
}
