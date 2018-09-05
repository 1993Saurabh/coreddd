using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreDdd.Queries;

namespace CoreDdd.Register.Castle
{
    // todo: merge registrators into one registrator, do the same for ninject bindings
    public class QueryExecutorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            AddTypedFactoryFacilityHelper.TryAddTypedFactoryFacility(container);

            container.Register(
                Component.For<IQueryHandlerFactory>().AsFactory(),
                Component.For<IQueryExecutor>()
                    .ImplementedBy<QueryExecutor>()
                    .LifeStyle.Transient);
        }
    }
}