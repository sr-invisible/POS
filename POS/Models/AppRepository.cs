using POS.IRepository.IRepository;
using POS.IRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace POS.Models
{
    public class AppRepository
    {
        public AppRepository(IUnityContainer service)
        {
            service.RegisterType<ISectionRepository, SectionRepository>();
            service.RegisterType<IAsideRepository, AsideRepository>();
            service.RegisterType<IProductRepository, ProductRepository>();
            service.RegisterType<IBrandRepository, BrandRepository>();
            service.RegisterType<ICategoryRepository, CategoryRepository>();
            service.RegisterType<ISubCategoryRepository, SubCategoryRepository>();
            service.RegisterType<IFinancialYearRepository, FinancialYearRepository>();
            service.RegisterType<IShopRepository, ShopRepository>();
            service.RegisterType<IRoleBaseMenuPermissionRepository, RoleBaseMenuPermissionRepository>();
        }

    }
}