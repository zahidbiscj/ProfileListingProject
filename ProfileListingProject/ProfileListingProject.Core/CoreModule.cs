using Autofac;
using Microsoft.Extensions.Configuration;
using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Repositories;
using ProfileListingProject.Core.Services;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;
        public CoreModule(IConfiguration configuration , string connectionString , string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<StoreContext>().As<IStoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<StoreUnitOfWork>().As<IStoreUnitOfWork>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
