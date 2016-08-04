using System;

namespace Masstransit.RabbitMQ.Event
{
    public class GreetingEventA
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get;set; }
    }
}