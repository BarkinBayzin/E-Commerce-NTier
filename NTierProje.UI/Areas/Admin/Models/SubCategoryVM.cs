using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierProje.UI.Areas.Admin.Models
{
    public class SubCategoryVM
    {
        public List<Category> Categories{ get; set; }
        public SubCategory SubCategory { get; set; }
    }
}