using System;
using log4net.Config;
using Masstransit.RabbitMQ.Extensions;
using MassTransit;
using Topshelf;
using Topshelf.Logging;

namespace Masstransit.RabbitMQ.GreetingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogWriterFactory.Use();
            XmlConfigurator.Configure();

            HostFactory.Run(x =>                                 
            {
                x.Service<GreetingServer>(s =>                        
                {
                    s.ConstructUsing(name => new GreetingServer());     
                    s.WhenStarted(tc => tc.Start());            
                    s.WhenStopped(tc => tc.Stop());
                });
                x.StartAutomatically();
                x.RunAsLocalSystem();                          
                x.SetDescription("A greeting service");        
                x.SetDisplayName("Greeting Service");                      
                x.SetServiceName("GreetingService");     
            });

        }
    }
}
