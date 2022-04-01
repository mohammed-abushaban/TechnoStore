using AutoMapper;
using TechnoStore.Core.Dto.Brands;
using TechnoStore.Core.Dto.Category;
using TechnoStore.Core.Dto.Cities;
using TechnoStore.Core.Dto.Employees;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Core.Dto.ExpensesCategories;
using TechnoStore.Core.Dto.Feedbacks;
using TechnoStore.Core.Dto.Files;
using TechnoStore.Core.Dto.PrivacyAndQuestions;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Core.Dto.Settings;
using TechnoStore.Core.Dto.Sms;
using TechnoStore.Core.Dto.SubCategories;
using TechnoStore.Core.Dto.Suppliers;
using TechnoStore.Core.Dto.Users;
using TechnoStore.Core.Dto.WareHouse;
using TechnoStore.Core.Dto.WarehousesProducts;
using TechnoStore.Core.ViewModel.Brands;
using TechnoStore.Core.ViewModel.Categories;
using TechnoStore.Core.ViewModel.Cities;
using TechnoStore.Core.ViewModel.Employees;
using TechnoStore.Core.ViewModel.Expenses;
using TechnoStore.Core.ViewModel.ExpensesCategories;
using TechnoStore.Core.ViewModel.Feedbacks;
using TechnoStore.Core.ViewModel.Files;
using TechnoStore.Core.ViewModel.PrivacyAndQuestions;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.Settings;
using TechnoStore.Core.ViewModel.Sms;
using TechnoStore.Core.ViewModel.SubCategories;
using TechnoStore.Core.ViewModel.Suppliers;
using TechnoStore.Core.ViewModel.Users;
using TechnoStore.Core.ViewModel.WareHouses;
using TechnoStore.Core.ViewModel.WarehousesProducts;
using TechnoStore.Data.Models;

namespace TechnoStore.Infostructures.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //ExpensesCategories
            CreateMap<ExpensesCategoryDbEntity, ExpensesCategoryVm>();
            CreateMap<CreateExpensesCategoryDto, ExpensesCategoryDbEntity>();
            CreateMap<UpdateExpensesCategoryDto, ExpensesCategoryDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Expenses
            CreateMap<ExpensesDbEntity, ExpensesVm>()
                .ForMember(x => x.ExpensesCategoryName, x => x.MapFrom(y => y.ExpensesCategory.Name));
            CreateMap<CreateExpensesDto, ExpensesDbEntity>();
            CreateMap<UpdateExpensesDto, ExpensesDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            //Feedback
            CreateMap<FeedbackDbEntity, FeedbackVm>();
            CreateMap<CreateFeedbackDto, FeedbackDbEntity>();

            //File
            CreateMap<FileDbEntity, FileVm>();
            CreateMap<CreateFileDto, FileDbEntity>();
            CreateMap<UpdateFileDto, FileDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            //Sms
            CreateMap<SmsDbEntity, SmsVm>();
            CreateMap<CreateSmsDto, SmsDbEntity>();

            //PrivacyAndQuestion 
            CreateMap<PrivacyAndQuestionDbEntity, PrivacyAndQuestionVm>();
            CreateMap<CreatePrivacyAndQuestionDto, PrivacyAndQuestionDbEntity>();
            CreateMap<UpdatePrivacyAndQuestionDto, PrivacyAndQuestionDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            //Setting  
            CreateMap<SettingDbEntity, SettingVm>();
            CreateMap<CreateSettingDto, SettingDbEntity>();
            //CreateMap<UpdateSettingDto, SettingDbEntity>()
            //    .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            
            //Categories
            CreateMap<CategoryDbEntity, CategoryVm>();
            CreateMap<CreateCategoryDto, CategoryDbEntity>();
            CreateMap<UpdateCategoryDto, CategoryDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //SubCategories
            CreateMap<SubCategoryDbEntity, SubCategoryVm>()
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.Name));
            CreateMap<CreateSubCategoryDto, SubCategoryDbEntity>();
            CreateMap<UpdateSubCategoryDto, SubCategoryDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Brands
            CreateMap<BrandDbEntity, BrandVm>();
            CreateMap<CreateBrandDto, BrandDbEntity>();
            CreateMap<UpdateBrandDto, BrandDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Suppliers
            CreateMap<SupplierDbEntity, SupplierVm>();
            CreateMap<CreateSupplierDto, SupplierDbEntity>();
            CreateMap<UpdateSupplierDto, SupplierDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Products
            CreateMap<ProductDbEntity, ProductVm>()
                .ForMember(x => x.PriceAfterDiscount, x => x.MapFrom(y => (y.PriceSale - (y.Discount / 100 * y.PriceSale)))) // get product price adding the discount to it 
            .ForMember(x => x.BrandName, x => x.MapFrom(y => y.Brand.Name))
            .ForMember(x => x.SubCategoryName, x => x.MapFrom(y => y.SubCategory.Name))
            .ForMember(x => x.SupplierName, x => x.MapFrom(y => y.Supplier.Name));
            //CreateMap<CreateProductDto, ProductDbEntity>();
            CreateMap<UpdateProductDto, ProductDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Users
            CreateMap<UserDbEntity, UserVm>()
                .ForMember(x => x.CityName, x => x.MapFrom(y => y.City.Name));
            CreateMap<CreateUserDto, UserDbEntity>();

            //WareHouses
            CreateMap<WarehouseDbEntity, WareHouseVm>()
                .ForMember(x => x.CityName, x => x.MapFrom(y => y.City.Name))
                .ForMember(x => x.UserName, x => x.MapFrom(y => (y.User.FirstName + " " +  y.User.LastName)));
            CreateMap<CreateWareHouseDto, WarehouseDbEntity>();
            CreateMap<UpdateWareHouseDto, WarehouseDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));



            //City
            CreateMap<CityDbEntity, CityVm>();
            CreateMap<CreateCityDto, CityDbEntity>();
            CreateMap<UpdateCityDto, CityDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //WareHousesProducts
            CreateMap<WarehouseDbEntity, wareHouseForProductDetailsVm>();
            CreateMap<CreateWarehouseProductDto, WarehouseProductDbEntity>()
                .ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<WarehouseProductDbEntity, WarehouseProductVm>()
                .ForMember(x => x.ProductName, x => x.MapFrom(y => y.Product.Name))
                .ForMember(x => x.WarehouseName, x => x.MapFrom(y => y.Warehouse.Name))
                .ForMember(x => x.Image, x => x.MapFrom(y => y.ImageUrl));


            CreateMap<WarehouseProductDbEntity, WarehouseProductDetailsVm>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Product.Name))
                .ForMember(x => x.TotalQuantity, x => x.Ignore());

            CreateMap<WarehouseProductDbEntity, warehouseProductForWarehouseDetailsVm>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Warehouse.Name))
                .ForMember(x => x.City, x => x.MapFrom(y => y.Warehouse.City))
                .ForMember(x => x.Address, x => x.MapFrom(y => y.Warehouse.Address))
                .ForMember(x => x.productDetails, x => x.Ignore());
            CreateMap<UpdateWarehouseProductDto, WarehouseProductDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Employee
            CreateMap<EmployeeDbEntity, EmployeeVm>();
            CreateMap<CreateEmployeeDto, EmployeeDbEntity>();
            CreateMap<UpdateEmployeeDto, EmployeeDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

        }

    }
}
