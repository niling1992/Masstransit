using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.RequestMessage;
using MassTransit;

namespace Masstransit.RabbitMQ.RequestService
{
    public class RequestConsumer:IConsumer<ISimpleRequest>
    {
        public async Task Consume(ConsumeContext<ISimpleRequest> context)
        {
            await Console.Out.WriteAsync("recieved request:{context.Message.CustomerId}");
            context.Respond(new SimpleResponse
            {
                CusomerName = "Customer Number {context.Message.CustomerId}"
            });
        }
    }
}