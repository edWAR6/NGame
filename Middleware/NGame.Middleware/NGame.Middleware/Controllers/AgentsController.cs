using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NakamaAgentService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NGame.Middleware.Controllers
{
    [Route("api/[controller]")]
    public class AgentsController : Controller
    {
        private static readonly int SYSTEM_ID = 1;

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/agents/5
        [HttpGet("{id}")]
        public AgentResponse Get(string id)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentFilter filter = new AgentFilter();
            filter.AgentID = id;
            filter.AgentSystemID = SYSTEM_ID;

            AgentResponse response = client.GetAgentAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
