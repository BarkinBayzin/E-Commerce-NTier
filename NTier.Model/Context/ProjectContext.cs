using NTier.Core.Entity;
using NTier.Model.Entities;
using NTier.Model.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext() /*:base("NTierProject")*/
        {
            Database.Connection.ConnectionString = "Server=.\\SQLEXPRESS;DataBase=NTier;Trusted_Connection=True;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Konfigürasyonlara hazırladığımız map sınıflarını ekliyoruz.
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            int user = 1;
            string ip = "1";
            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedBy = user;
                        entity.CreatedIp = ip;
                        entity.CreateDate = dateTime;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedUserName = identity;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedBy = user;
                        entity.ModifiedIp = ip;
                        entity.ModifiedDate = dateTime;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedUserName = identity;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
