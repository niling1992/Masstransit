using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.Greeting.Message;
using MassTransit;

namespace Masstransit.RabbitMQ.GreetingServer
{
    public class GreetingConsumer :
    IConsumer<GreetingCommandA>
    {
        public async Task Consume(ConsumeContext<GreetingCommandA> context)
        {

            await Console.Out.WriteLineAsync("receive greeting commmand: {context.Message.Id},{context.Message.DateTime}");

            //var greetingEvent = new GreetingEvent()
            //{
            //    Id = context.Message.Id,
            //    DateTime = DateTime.Now
            //};

            //await context.Publish(greetingEvent);

        }
    }
}