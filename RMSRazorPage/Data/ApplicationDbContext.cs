using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RMSRazorPage.Models;

namespace RMSRazorPage.Data
{
    // Kế thừa từ IdentityDbContext để tích hợp Identity
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSets for each of your entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cần gọi base.OnModelCreating để cấu hình Identity được thực hiện
            base.OnModelCreating(modelBuilder);

            // Cấu hình độ chính xác cho các trường decimal
            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(o => o.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
