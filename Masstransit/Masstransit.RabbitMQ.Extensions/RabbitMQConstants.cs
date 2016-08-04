namespace Masstransit.RabbitMQ.Extensions
{
    public class RabbitMqConstants
    {
        //需要连VPN 大厅服务器
        public const string RabbitMqUri = "rabbitmq://19.134.148.23:5672/";
        public const string UserName = "rollen";
        public const string Password = "root";
        public const string GreetingQueue = "greeting.service";
        public const string HierarchyMessageSubscriberQueue = "hierarchyMessage.subscriber.service";
        public const string GreetingEventSubscriberAQueue = "greetingEvent.subscriberA.service";
        public const string GreetingEventSubscriberBQueue = "greetingEvent.subscriberB.service";

        public const string RequestClientQueue = "Request.Service";
    }
}