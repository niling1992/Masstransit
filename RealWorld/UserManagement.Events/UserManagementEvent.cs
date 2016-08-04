using System;
using UserManagement.Core;

namespace UserManagement.Events
{
    public class UserManagementEvent:IEvent
    {
        public Guid Id { get; set; }
    }
}