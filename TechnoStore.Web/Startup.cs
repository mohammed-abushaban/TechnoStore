using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;
using TechnoStore.Infostructures.AutoMapper;
using TechnoStore.Infostructures.Services.ExpensesCategories;
using TechnoStore.Infostructures.Services.IFeedbacks;
using TechnoStore.Infrastructure.Services;
using TechnoStore.Infrastructure.Services.Brands;
using TechnoStore.Infrastructure.Services.Categories;
using TechnoStore.Infrastructure.Services.Cities;
using TechnoStore.Infrastructure.Services.Expenses;
using TechnoStore.Infrastructure.Services.Files;
using TechnoStore.Infrastructure.Services.PrivacyAndQuestions;
using TechnoStore.Infrastructure.Services.Products;
using TechnoStore.Infrastructure.Services.ProductsQuantities;
using TechnoStore.Infrastructure.Services.Settings;
using TechnoStore.Infrastructure.Services.Shippers;
using TechnoStore.Infrastructure.Services.Sms;
using TechnoStore.Infrastructure.Services.SubCategories;
using TechnoStore.Infrastructure.Services.Suppliers;
using TechnoStore.Infrastructure.Services.Users;
using TechnoStore.Infrastructure.Services.WareHouse;
using TechnoStore.Infrastructure.Services.WarehousesProducts;

namespace TechnoStore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<UserDbEntity , IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddCors();
            services.AddMvc();

            //Services
            services.AddScoped<IExpensesCategoryService, ExpensesCategoryService>();
            services.AddScoped<IExpensesService, ExpensesService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IPrivacyAndQuestionService, PrivacyAndQuestionService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ISubCategoriesService, SubCategoriesService>();
            services.AddScoped<IBrandsService, BrandsService>();
            services.AddScoped<ISuppliersService, SuppliersService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductsQuantitiesService, ProductsQuantitiesService>();
            services.AddScoped<IExpensesService, ExpensesService>(); 
            services.AddScoped<IUserService, UserService>(); 
            services.AddScoped<IRoleService, RoleService>(); 
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IWareHouseService, WareHouseService>();
            services.AddScoped<IWarehousesProductsService, WarehousesProductsService>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<ICityService, CityService>();


            
            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);


            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));
            // Add the processing server as IHostedService
            services.AddHangfireServer();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //Hangfire
            //app.UseHangfireDashboard();


            ////Use The HangFire
            //using var ScopeChackQuantityProduct = app.ApplicationServices.CreateScope();
            //using var ScopeChangeAvilable = app.ApplicationServices.CreateScope();
            //var chackQuantityProduct = ScopeChackQuantityProduct.ServiceProvider.GetService<IWarehousesProductsService>();
            //var changeAvilable = ScopeChangeAvilable.ServiceProvider.GetService<IProductsService>();
            //RecurringJob.AddOrUpdate(() => chackQuantityProduct.GetProductQuantity(1), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => changeAvilable.ChangeAvailability(1,true), Cron.Minutely);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
