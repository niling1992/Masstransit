using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor.Mvc;
using CommonServiceLocator.WindsorAdapter;
using log4net;
using MassTransit;
using UserManagement.ServiceBus;
using WebApiContrib.IoC.CastleWindsor;

namespace UserManagement
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            //*********************************web api*********************
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver=new WindsorResolver(ApplicationBootstrapper.Container);

            //*********************************mvc*************************
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var mvcControllerFactory=new WindsorControllerFactory(ApplicationBootstrapper.Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(mvcControllerFactory);

            var serviceLocator = new WindsorServiceLocator(ApplicationBootstrapper.Container);
            DependencyResolver.SetResolver(serviceLocator) ;

            //**************************bus******************
            ((IBusControl) UserManagementBusConfiguration.BusInstance).Start();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var _log = LogManager.GetLogger(typeof(WebApiApplication));
            _log.Error("Unhandled exception", Server.GetLastError().GetBaseException());
        }

        protected void Application_End()
        {
            ((IBusControl)UserManagementBusConfiguration.BusInstance).Stop();
        }

    }
}
