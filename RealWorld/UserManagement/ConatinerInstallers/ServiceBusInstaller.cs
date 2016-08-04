using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MassTransit;
using UserManagement.ServiceBus;

namespace UserManagement.ConatinerInstallers
{
    public class ServiceBusInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IBus, IBusControl>()
                    .Instance(UserManagementBusConfiguration.BusInstance)
                    .LifestyleSingleton());
        }

       
    }
}