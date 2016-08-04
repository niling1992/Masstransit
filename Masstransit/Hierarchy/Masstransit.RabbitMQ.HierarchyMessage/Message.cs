using System;

namespace Masstransit.RabbitMQ.HierarchyMessage
{
    public interface IMessage
    {
        Guid Id { get; set; }
    }

    public class Message : IMessage
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
    }

    public class UserUpdatedMessage : Message
    {
        public Guid Id { get; set; }
    }

    public class UserDeletedMessage : Message
    {
        public Guid Id { get; set; }
    }
}