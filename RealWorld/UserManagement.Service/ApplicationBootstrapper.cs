using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace UserManagement.Service
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
