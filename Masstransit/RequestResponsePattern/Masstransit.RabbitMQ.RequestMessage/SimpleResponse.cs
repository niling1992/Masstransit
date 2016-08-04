namespace Masstransit.RabbitMQ.RequestMessage
{
    public interface ISimpleResponse
    {
        string CusomerName { get; }
    }

    public class SimpleResponse:ISimpleResponse
    {
        public string CusomerName { get; set; }
    }
}