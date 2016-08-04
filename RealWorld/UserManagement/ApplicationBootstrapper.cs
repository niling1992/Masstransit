using Castle.Windsor;
using Castle.Windsor.Installer;

namespace UserManagement
{
    public class ApplicationBootstrapper
    {
        public static IWindsorContainer Container;

        static ApplicationBootstrapper()
        {
            Container=new WindsorContainer();

            Container.Install(FromAssembly.InThisApplication());
        }
    }
}