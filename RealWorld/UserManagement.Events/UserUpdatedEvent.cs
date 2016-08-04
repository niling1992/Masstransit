namespace UserManagement.Events
{
    public class UserUpdatedEvent : UserManagementEvent
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}