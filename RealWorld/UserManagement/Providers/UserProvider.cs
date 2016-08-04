using System.Collections.Generic;

namespace UserManagement.Providers
{
    public interface IUserProvider
    {
        List<string> Names();
    }

    public class UserProvider:IUserProvider
    {
        public List<string> Names()
        {
            var list = new List<string>();
            list.Add("Lily");
            list.Add("Lucy");
            list.Add("Tom");
            list.Add("Jim");

            return list;
        }
    }
}