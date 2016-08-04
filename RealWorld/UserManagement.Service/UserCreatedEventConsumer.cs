using System;
using System.Threading.Tasks;
using MassTransit;
using UserManagement.Events;

namespace UserManagement.Service
{
    public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
    {
        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            await Console.Out.WriteLineAsync("user name is {context.Message.UserName}");
            await Console.Out.WriteLineAsync("user email is {context.Message.Email}");
        }
    }
}