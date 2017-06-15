using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NGame.Middleware.Controllers
{
    [Produces("application/json")]
    [Route("api/Agents")]
    public class AgentsController : Controller
    {
        private static readonly int AGENT_SYSTEM_ID = 1;

        // GET: api/Agents
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Agents/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            NakamaAgentService.AgentWebServiceClient client = new NakamaAgentService.AgentWebServiceClient();
            NakamaAgentService.AgentFilter filter = new NakamaAgentService.AgentFilter();
            filter.AgentID = id;
            filter.AgentSystemID = AGENT_SYSTEM_ID;
            NakamaAgentService.AgentResponse response = client.GetAgent(filter);
            return "value";
        }
        
        // POST: api/Agents
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Agents/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
