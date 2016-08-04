namespace UserManagement.Core
{
    public interface IMessage{  }

    public interface IEvent:IMessage { }

    public interface ICommand : IMessage { }
}