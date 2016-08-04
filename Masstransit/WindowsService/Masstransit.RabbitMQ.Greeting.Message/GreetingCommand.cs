using System;

namespace Masstransit.RabbitMQ.Greeting.Message
{
    public class GreetingCommand
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
    }
}