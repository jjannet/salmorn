using Microsoft.EntityFrameworkCore;
using salmorn.Models.Logs;
using salmorn.Models.Masters;
using salmorn.Models.Systems;
using salmorn.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.Services
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        { }

        public DbSet<FileUpload> FileUploads { get; set; }

        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMapping> RoleMappings { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentNotification> PaymentNotifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
    }
}
