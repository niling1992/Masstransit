using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserManagement.Providers;

namespace UserManagement.ConatinerInstallers
{
    public class ProvidersInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserProvider>().ImplementedBy<UserProvider>().LifestylePerWebRequest());
        }
    }
}