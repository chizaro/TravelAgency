using AutoMapper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.EntityFramework;
using TravelAgency.EntityFramework.Repositories;
using TravelAgency.Web.App_Start;

namespace TravelAgency.Web.Ninject
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<TravelAgencyContext>().ToSelf().InRequestScope();

            Bind<ICountryRepository>().To<CountryRepository>();
            Bind<ISaleRepository>().To<SaleRepository>();
            Bind<IHotelTypeRepository>().To<HotelTypeRepository>();
            Bind<IFoodRepository>().To<FoodRepository>();
            Bind<IHotelRepository>().To<HotelRepository>();
            Bind<ITourTypeRepostiory>().To<TourTypeRepository>();
            Bind<ITourRepository>().To<TourRepository>();
            Bind<ITourPageRepository>().To<TourPageRepository>();
            Bind<IAdminRepository>().To<AdminRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();

            var mapperConfiguration = new AutoMapperConfig().Configure();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx => new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }
    }
}