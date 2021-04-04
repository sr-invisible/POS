using POS.Service.IService;
using POS.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace POS.Models
{
    public class AppService
    {
        public AppService(IUnityContainer service)
        {
            service.RegisterType<ISectionService, SectionService>();
            service.RegisterType<IAsideService, AsideService>();
            service.RegisterType<IProductService, ProductService>();
            service.RegisterType<IBrandService, BrandService>();
            service.RegisterType<ICategoryService, CategoryService>();
            service.RegisterType<ISubCategoryService, SubCategoryService>();
            service.RegisterType<IFinancialYearService, FinancialYearService>();
            service.RegisterType<IShopService, ShopService>();
            service.RegisterType<IAsideSectionService, AsideSectionService>();
            service.RegisterType<IRoleBaseMenuPermissionService, RoleBaseMenuPermissionService>();
        }
    }
}