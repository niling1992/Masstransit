using System;

namespace Masstransit.RabbitMQ.Event
{
    public class GreetingEventB
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
    }
}
