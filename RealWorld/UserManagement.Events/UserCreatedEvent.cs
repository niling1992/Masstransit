namespace UserManagement.Events
{
    public class UserCreatedEvent:UserManagementEvent
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}