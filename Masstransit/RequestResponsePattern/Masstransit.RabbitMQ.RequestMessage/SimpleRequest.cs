using System;

namespace Masstransit.RabbitMQ.RequestMessage
{
    public interface ISimpleRequest
    {
        DateTime Timestamp { get; }

        string CustomerId { get; }
    }

    public class SimpleRequest:ISimpleRequest
    {
        public DateTime Timestamp { get; set; }
        public string CustomerId { get; set; }
    }
}