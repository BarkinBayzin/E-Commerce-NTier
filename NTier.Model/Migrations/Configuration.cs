namespace NTier.Model.Migrations
{
    using NTier.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Principal;

    internal sealed class Configuration : DbMigrationsConfiguration<NTier.Model.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NTier.Model.Context.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Category c = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Main Category",
                Status = Core.Entity.Enum.Status.Active,
                Description = "Test Category Item",
                CreateDate = DateTime.Now,
                MasterId = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIp = "123",
                CreatedUserName = WindowsIdentity.GetCurrent().Name
            };

            SubCategory sc = new SubCategory()
            {
                Id = Guid.NewGuid(),
                Name = "Sub Category",
                Status = Core.Entity.Enum.Status.Active,
                Description = "Test SubCategory Item",
                CategoryID = c.Id,
                CreateDate = DateTime.Now,
                MasterId = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIp = "123",
                CreatedUserName = WindowsIdentity.GetCurrent().Name
            };

            AppUser a = new AppUser
            {
                UserName = "admin",
                Password = "123",
                Id = Guid.NewGuid(),
                Role = Role.Admin,
                Status = Core.Entity.Enum.Status.Active,
                CreateDate = DateTime.Now,
                Address = "Test Sokak Test Mahalllesi",
                PhoneNumber = "05004445566",
                ImagePath = "/Uploads/e2e1d86e-c22c-4059-9aa8-73dbdec640a4.jpg",
                MasterId = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIp = "123",
                CreatedUserName = WindowsIdentity.GetCurrent().Name
            };

            List<Product> products = new List<Product> {
                new Product {Name="Test Product 1",Id=Guid.NewGuid(),Status=Core.Entity.Enum.Status.Active,SubCategoryID=sc.Id,ImagePath="/Uploads/de68051b-a3c8-4b44-a918-5825e3c3601b.jpg",CreateDate=DateTime.Now,UnitsInStock=100,UnitPrice=50,Quantity="20", MasterId = null, CreatedComputerName = Environment.MachineName, CreatedIp = "123", CreatedUserName = WindowsIdentity.GetCurrent().Name  },
                new Product {Name="Test Product 2",Id=Guid.NewGuid(),Status=Core.Entity.Enum.Status.Active,SubCategoryID=sc.Id,ImagePath="/Uploads/de68051b-a3c8-4b44-a918-5825e3c3601b.jpg",CreateDate=DateTime.Now,UnitsInStock=200,UnitPrice=25,Quantity="10", MasterId = null, CreatedComputerName = Environment.MachineName, CreatedIp = "123", CreatedUserName = WindowsIdentity.GetCurrent().Name }
            };


            context.AppUsers.AddOrUpdate(a);
            context.Categories.AddOrUpdate(c);
            context.SubCategories.AddOrUpdate(sc);
            context.Products.AddRange(products);


            base.Seed(context);
        }
    }
}
