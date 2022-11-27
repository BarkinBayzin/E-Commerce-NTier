using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.Address).IsOptional();
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.Email).HasMaxLength(50).IsOptional();
            Property(x => x.ImagePath).IsOptional();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Role).IsOptional();
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.Surname).HasMaxLength(50).IsOptional();
        }
    }
}
