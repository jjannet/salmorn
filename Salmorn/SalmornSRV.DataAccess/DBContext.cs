using Microsoft.EntityFrameworkCore;
using SalmornSRV.Models.Account;
using SalmornSRV.Models.Log;
using SalmornSRV.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Service
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMapping> RoleMappings { get; set; }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<PaymentNotification> PaymentNotifications { get; set; }
        public DbSet<Order_H> Order_Hs { get; set; }
        public DbSet<Order_D> Order_Ds { get; set; }
        public DbSet<Shipping_H> Shipping_Hs { get; set; }
        public DbSet<Shipping_D> Shipping_Ds { get; set; }

        public DbSet<FileUpload> FileUploads { get; set; }
    }
}
