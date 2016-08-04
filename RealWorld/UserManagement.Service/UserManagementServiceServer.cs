using MassTransit;

namespace UserManagement.Service
{
    public class UserManagementServiceServer
    {
        private readonly IBusControl _bus;

        public UserManagementServiceServer()
        {
            var container = ApplicationBootstrapper.Container;
            _bus = container.Resolve<IBusControl>();
        }

        public void Start()
        {
            _bus.Start();
        }

        public void Stop()
        {
            _bus.Stop();
        }
    }
}