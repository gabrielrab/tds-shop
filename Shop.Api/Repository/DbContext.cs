using Microsoft.EntityFrameworkCore;
using Shop.Api.Models;

namespace Shop.Api.Repository
{
    public class Context : DbContext
    {
        public DbSet<EmployeeModel>? EmployeeModel { get; set; }
        public DbSet<ProductModel>? ProductModel { get; set; }
        public DbSet<OrderLineModel>? OrderLineModel { get; set; }
        public DbSet<OrderModel>? OrderModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}