using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NakamaCommonService;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NGame.Middleware.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class CommonsController : Controller
    {
        // GET: api/commons/sports
        [HttpGet("sports")]
        public SportListResponse GetSports()
        {
            CommonWebServiceClient client = new CommonWebServiceClient();
            SportListResponse response = client.GetSportListAsync().Result;

            client.CloseAsync();
            return response;
        }

        // POST api/commons/limits
        [HttpPost("limits")]
        public LimitResponse PostLimits([FromBody]float maxBet, [FromBody]float maxWin, [FromBody]AgentFilter[] agents, [FromBody]PlayerFilter[] players)
        {
            CommonWebServiceClient client = new CommonWebServiceClient();
            LimitFilter filter = new LimitFilter();
            filter.MaxBet = maxBet;
            filter.MaxWin = maxWin;
            filter.Agents = agents;
            filter.Players = players;

            LimitResponse response = client.SetLimitAmountAsync(filter).Result;
            client.CloseAsync();

            return response;
        }
    }
}
