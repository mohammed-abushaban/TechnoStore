using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechnoStore.Data.Models;

namespace TechnoStore.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDbEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BrandDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<CartDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<CartProductDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<CategoryDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<ExpensesDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<FeedbackDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<FileDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<OrderDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<PrivacyAndQuestionDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<ProductDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<ProductImagesDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<ProductDamageDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<SettingDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<SmsDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<SubCategoryDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<SupplierDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<ExpensesCategoryDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<UserDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<CityDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<WarehouseDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<WarehouseProductDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<EmployeeDbEntity>().HasQueryFilter(x => !x.IsDelete);

        }


        public DbSet<BrandDbEntity> Brands { get; set; }
        public DbSet<CartDbEntity> Carts { get; set; }
        public DbSet<CartProductDbEntity> CartProducts { get; set; }
        public DbSet<CategoryDbEntity> Categories { get; set; }
        public DbSet<ExpensesDbEntity> Expenses { get; set; }
        public DbSet<FeedbackDbEntity> Feedbacks { get; set; }
        public DbSet<FileDbEntity> Files { get; set; }
        public DbSet<OrderDbEntity> Orders { get; set; }
        public DbSet<PrivacyAndQuestionDbEntity> PrivacyAndQuestions { get; set; }
        public DbSet<ProductDbEntity> Products { get; set; }
        public DbSet<ProductImagesDbEntity> ProductImages { get; set; }
        public DbSet<ProductDamageDbEntity> ProductDamages { get; set; }
        public DbSet<SettingDbEntity> Settings { get; set; }
        public DbSet<SmsDbEntity> Sms { get; set; }
        public DbSet<SubCategoryDbEntity> SubCategories { get; set; }
        public DbSet<SupplierDbEntity> Suppliers { get; set; }
        public DbSet<ExpensesCategoryDbEntity> ExpensesCategory { get; set; }
        public DbSet<CityDbEntity> Cities { get; set; }
        public DbSet<WarehouseDbEntity> Warehouses { get; set; }
        public DbSet<WarehouseProductDbEntity> warehouseProducts { get; set; }
        public DbSet<EmployeeDbEntity> Employees { get; set; }
    }
}

