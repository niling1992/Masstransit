using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MassTransit;
using UserManagement.Events;
using UserManagement.Providers;

namespace UserManagement.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IUserProvider _userProvider;
        private readonly IBus _bus;

        public ValuesController(IUserProvider userProvider,IBus bus)
        {
            _userProvider = userProvider;
            _bus = bus;
        }

        [HttpGet]
        [Route("api/values/createuser")]
        public string CreateUser()
        {
            _bus.Publish(new UserCreatedEvent() {UserName = "Tom", Email = "tom@google.com"});

            return "create user named Tom";
        }

        [HttpGet]
        [Route("api/values/updateUser")]
        public string UpdateUser()
        {
            _bus.Publish(new UserUpdatedEvent() {UserName = "Jim", Email = "jim@google.com"});

            return "update user named jim";
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return _userProvider.Names();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
