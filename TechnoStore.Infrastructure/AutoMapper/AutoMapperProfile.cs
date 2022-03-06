using AutoMapper;
using TechnoStore.Core.Dto.Brands;
using TechnoStore.Core.Dto.Category;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Core.Dto.ExpensesCategories;

using TechnoStore.Core.Dto.Products;
using TechnoStore.Core.Dto.ProductsQuantities;
using TechnoStore.Core.Dto.SubCategories;
using TechnoStore.Core.Dto.Suppliers;
using TechnoStore.Core.ViewModel.Brands;
using TechnoStore.Core.ViewModel.Categories;
using TechnoStore.Core.ViewModel.Expenses;
using TechnoStore.Core.ViewModel.ExpensesCategories;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.ProductsQuantities;
using TechnoStore.Core.ViewModel.SubCategories;
using TechnoStore.Core.ViewModel.Suppliers;

using TechnoStore.Core.Dto.Shippers;
using TechnoStore.Core.Dto.Users;
using TechnoStore.Core.ViewModel;
using TechnoStore.Core.ViewModel.Expenses;
using TechnoStore.Core.ViewModel.ExpensesCategories;
using TechnoStore.Core.ViewModel.Shippers;

using TechnoStore.Data.Models;

namespace TechnoStore.Infostructures.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //ExpensesCategory
            CreateMap<ExpensesCategoryDbEntity, ExpensesCategoryVm>();
            CreateMap<CreateExpensesCategoryDto, ExpensesCategoryDbEntity>();
            CreateMap<UpdateExpensesCategoryDto, ExpensesCategoryDbEntity>();

            //Expenses
            CreateMap<ExpensesDbEntity, ExpensesVm>();
            CreateMap<CreateExpensesDto, ExpensesDbEntity>();
            CreateMap<UpdateExpensesDto, ExpensesDbEntity>();


            //Categories
            CreateMap<CategoryDbEntity, CategoryVm>();
            CreateMap<CreateCategoryDto, CategoryDbEntity>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateCategoryDto, CategoryDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //SubCategories
            CreateMap<SubCategoryDbEntity, SubCategoryVm>().ForMember(x => x.CategoryId, x => x.MapFrom(y => y.Category.Id))
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.Name));
            CreateMap<CreateSubCategoryDto, SubCategoryDbEntity>();
            CreateMap<UpdateSubCategoryDto, SubCategoryDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Brands
            CreateMap<BrandDbEntity, BrandVm>();
            CreateMap<CreateBrandDto, BrandDbEntity>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateBrandDto, BrandDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Suppliers
            CreateMap<SupplierDbEntity, SupplierVm>();
            CreateMap<CreateSupplierDto, SupplierDbEntity>();
            CreateMap<UpdateSupplierDto, SupplierDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Products
            CreateMap<ProductDbEntity, ProductVm>().ForMember(x => x.BrandId, x => x.MapFrom(y => y.Brand.Id))
                .ForMember(x => x.SubCategoryId, x => x.MapFrom(y => y.SubCategory.Id))
                .ForMember(x => x.SupplierId, x => x.MapFrom(y => y.Supplier.Id))
                .ForMember(x => x.PriceAfterDiscount, x => x.MapFrom(y => (y.Discount != null) ? (y.PriceSale - (y.Discount / 100 * y.PriceSale)) : y.PriceSale)); // get product price adding the discount to it 
            CreateMap<CreateProductDto, ProductDbEntity>();
            CreateMap<UpdateProductDto, ProductDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //ProductsQuantities
            CreateMap<ProductQuantityDbEntity, ProductQuantityVm>().ForMember(x => x.ProductId, x => x.MapFrom(y => y.Product.Id));
            CreateMap<CreateProductQuantityDto, ProductQuantityDbEntity>();
            CreateMap<UpdateProductQuantityDto, ProductQuantityDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));

            //Users
            CreateMap<UserDbEntity, UserVm>();
            CreateMap<CreateUserDto, UserDbEntity>();

            //Shipper
            CreateMap<ShipperDbEntity, ShipperVm>();
            CreateMap<CreateShipperDto, ShipperDbEntity>();
            CreateMap<UpdateShipperDto, ShipperDbEntity>();

        }

    }
}
