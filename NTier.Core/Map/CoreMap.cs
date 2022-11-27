using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Core.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        //Core propertyler maplenir.
        public CoreMap()
        {
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(x => x.Status).HasColumnName("Status").IsOptional();

            Property(x => x.CreateDate).HasColumnName("CreatedDate").IsOptional();

            Property(x => x.CreatedUserName).HasColumnName("CreatedUserName").IsOptional();

            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName").IsOptional();

            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();

            Property(x => x.CreatedIp).HasColumnName("CreatedIp").IsOptional();

            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();

            Property(x => x.ModifiedUserName).HasColumnName("ModifiedUserName").IsOptional();

            Property(x => x.ModifiedComputerName).HasColumnName("ModifiedComputerName").IsOptional();

            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();

            Property(x => x.ModifiedIp).HasColumnName("ModifiedIp").IsOptional();

        }
    }
}
