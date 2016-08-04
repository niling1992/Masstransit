using System;
using System.Threading.Tasks;
using MassTransit;
using UserManagement.Events;

namespace UserManagement.Service
{
    public class ExceptionConsumer:IConsumer<Fault<UserUpdatedEvent>>
    {
        public async Task Consume(ConsumeContext<Fault<UserUpdatedEvent>> context)
        {
           await Console.Out.WriteLineAsync("catch exception: {context.Message.Message}");
        }
    }
}