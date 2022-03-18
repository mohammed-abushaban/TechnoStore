using AutoMapper;
using TechnoStore.Core.Dto.Brands;
using TechnoStore.Core.Dto.Category;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Core.Dto.ExpensesCategories;
using TechnoStore.Core.Dto.Feedbacks;
using TechnoStore.Core.Dto.Files;
using TechnoStore.Core.Dto.PrivacyAndQuestions;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Core.Dto.ProductsQuantities;
using TechnoStore.Core.Dto.Settings;
using TechnoStore.Core.Dto.Shippers;
using TechnoStore.Core.Dto.Sms;
using TechnoStore.Core.Dto.SubCategories;
using TechnoStore.Core.Dto.Suppliers;
using TechnoStore.Core.Dto.Users;
using TechnoStore.Core.Dto.WareHouse;
using TechnoStore.Core.Dto.WarehousesProducts;
using TechnoStore.Core.ViewModel.Brands;
using TechnoStore.Core.ViewModel.Categories;
using TechnoStore.Core.ViewModel.Expenses;
using TechnoStore.Core.ViewModel.ExpensesCategories;
using TechnoStore.Core.ViewModel.Feedbacks;
using TechnoStore.Core.ViewModel.Files;
using TechnoStore.Core.ViewModel.PrivacyAndQuestions;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.ProductsQuantities;
using TechnoStore.Core.ViewModel.Settings;
using TechnoStore.Core.ViewModel.Shippers;
using TechnoStore.Core.ViewModel.Sms;
using TechnoStore.Core.ViewModel.SubCategories;
using TechnoStore.Core.ViewModel.Suppliers;
using TechnoStore.Core.ViewModel.Users;
using TechnoStore.Core.ViewModel.WareHouses;
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
            CreateMap<UpdateExpensesDto, ExpensesDbEntity>();

            //Feedback
            CreateMap<FeedbackDbEntity, FeedbackVm>();
            CreateMap<CreateFeedbackDto, FeedbackDbEntity>();

            //File
            CreateMap<FileDbEntity, FileVm>();
            CreateMap<CreateFileDto, FileDbEntity>();
            CreateMap<UpdateFileDto, FileDbEntity>();

            //Sms
            CreateMap<SmsDbEntity, SmsVm>();
            CreateMap<CreateSmsDto, SmsDbEntity>();
            CreateMap<UpdateSmsDto, SmsDbEntity>();

            //PrivacyAndQuestion 
            CreateMap<PrivacyAndQuestionDbEntity, PrivacyAndQuestionVm>();
            CreateMap<CreatePrivacyAndQuestionDto, PrivacyAndQuestionDbEntity>();
            CreateMap<UpdatePrivacyAndQuestionDto, PrivacyAndQuestionDbEntity>();

            //Setting  
            CreateMap<SettingDbEntity, SettingVm>();
            CreateMap<CreateSettingDto, SettingDbEntity>();
            CreateMap<UpdateSettingDto, SettingDbEntity>();

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
            CreateMap<CreateProductDto, ProductDbEntity>();
            CreateMap<UpdateProductDto, ProductDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //ProductsQuantities
            CreateMap<ProductQuantityDbEntity, ProductQuantityVm>();
            CreateMap<CreateProductQuantityDto, ProductQuantityDbEntity>();
            CreateMap<UpdateProductQuantityDto, ProductQuantityDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Shippers
            CreateMap<ShipperDbEntity, ShipperVm>();
            CreateMap<CreateShipperDto, ShipperDbEntity>();
            CreateMap<UpdateShipperDto, ShipperDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Users
            CreateMap<UserDbEntity, UserVm>();
            CreateMap<CreateUserDto, UserDbEntity>();

            //WareHouses
            CreateMap<WarehouseDbEntity, WareHouseVm>();
            CreateMap<CreateWareHouseDto, WarehouseDbEntity>();
            CreateMap<UpdateWareHouseDto, WarehouseDbEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));


            //WareHousesProducts
            CreateMap<CreateWarehouseProductDto, WarehouseProductDbEntity>().ForMember(x => x.ImageUrl, x => x.Ignore());
        }

    }
}
