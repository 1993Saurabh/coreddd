using System;
using CoreDdd.Domain.Repositories;
using CoreDdd.Nhibernate.Configurations;
using CoreDdd.Nhibernate.Repositories;
using CoreDdd.Nhibernate.UnitOfWorks;
using CoreDdd.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace CoreDdd.Nhibernate.Register.DependencyInjection
{
    /// <summary>
    /// Registers CoreDdd NHibernate services into Dependency Injection Service Provider IoC container.
    /// </summary>
    public static class CoreDddNhibernateRegistrator
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <typeparam name="TNhibernateConfigurator">A NHibernate configurator type</typeparam>
        /// <param name="services">A service collection</param>
        public static void AddCoreDddNhibernate<TNhibernateConfigurator>(this IServiceCollection services)
            where TNhibernateConfigurator : class, INhibernateConfigurator
        {
            services.AddSingleton<INhibernateConfigurator, TNhibernateConfigurator>();
            services.AddTransient(typeof(IRepository<>), typeof(NhibernateRepository<>));
            services.AddTransient(typeof(IRepository<,>), typeof(NhibernateRepository<,>));
            services.AddTransient(typeof(NhibernateRepository<>));
            services.AddTransient(typeof(NhibernateRepository<,>));
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped<IUnitOfWork, NhibernateUnitOfWork>();
            services.AddScoped(x => (NhibernateUnitOfWork)x.GetService<IUnitOfWork>());
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <typeparam name="TNhibernateConfigurator">A NHibernate configurator type</typeparam>
        /// <param name="services">A service collection</param>
        /// <param name="implementationFactory">A factory which creates NHibernate configurator instance</param>
        public static void AddCoreDddNhibernate<TNhibernateConfigurator>(
            this IServiceCollection services,
            Func<IServiceProvider, TNhibernateConfigurator> implementationFactory
        )
            where TNhibernateConfigurator : class, INhibernateConfigurator
        {
            services.AddSingleton<INhibernateConfigurator>(implementationFactory);
            services.AddTransient(typeof(IRepository<>), typeof(NhibernateRepository<>));
            services.AddTransient(typeof(IRepository<,>), typeof(NhibernateRepository<,>));
            services.AddTransient(typeof(NhibernateRepository<>));
            services.AddTransient(typeof(NhibernateRepository<,>));
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped<IUnitOfWork, NhibernateUnitOfWork>();
            services.AddScoped(x => (NhibernateUnitOfWork)x.GetService<IUnitOfWork>());
        }
    }
}