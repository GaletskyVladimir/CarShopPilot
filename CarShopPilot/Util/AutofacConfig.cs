using ApplicationServices.Interfaces;
using ApplicationServices.IServices;
using ApplicationServices.Repositories;
using ApplicationServices.Services;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CarShopPilot.Util
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UserRepository>()
                   .As<IUserRepository>()
                   .InstancePerRequest();

            builder.RegisterType<CustomerRepository>()
                   .As<ICustomerRepository>()
                   .InstancePerRequest();

            builder.RegisterType<DealRepository>()
                   .As<IDealRepository>()
                   .InstancePerRequest();

            builder.RegisterType<VehicleRepository>()
                   .As<IVehicleRepository>()
                   .InstancePerRequest();

            builder.RegisterType<StoreRepository>()
                   .As<IStoreRepository>()
                   .InstancePerRequest();

            builder.RegisterType<UserService>()
                   .As<IUserService>()
                   .InstancePerRequest();

            builder.RegisterType<DealService>()
                   .As<IDealService>()
                   .InstancePerRequest();

            builder.RegisterType<CustomerService>()
                   .As<ICustomerService>()
                   .InstancePerRequest();

            builder.RegisterType<StoreService>()
                   .As<IStoreService>()
                   .InstancePerRequest();

            builder.RegisterType<VehicleService>()
                   .As<IVehicleService>()
                   .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}