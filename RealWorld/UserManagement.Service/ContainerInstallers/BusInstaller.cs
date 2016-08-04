using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MassTransit;

namespace UserManagement.Service.ContainerInstallers
{
    public class BusInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IBus, IBusControl>()
                    .Instance(UserManagementServiceBusConfiguration.BusInstance())
                    .LifestyleSingleton());
        }
    }
}