using System.Threading.Tasks;
using MassTransit;
using UserManagement.Events;

namespace UserManagement.Service
{
    public class UserUpdatedEventComsumer:IConsumer<UserUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserUpdatedEvent> context)
        {
            throw new System.NotImplementedException();
        }
    }
}