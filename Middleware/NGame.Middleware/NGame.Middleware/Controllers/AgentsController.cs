using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NakamaAgentService;
using NakamaPlayerService;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NGame.Middleware.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class AgentsController : Controller
    {
        private IConfiguration configuration;
        private int systemPlataformID;

        public AgentsController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.systemPlataformID = configuration.GetValue<int>("SystemPlataformID");
        }

        // GET api/agents/5
        [HttpGet("{id}")]
        public AgentResponse Get(string id)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentFilter filter = new AgentFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;

            AgentResponse response = client.GetAgentAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/agents/5/masteragents
        [HttpGet("{id}/masteragents")]
        public AgentResponse GetMasterAgents(string id, [FromQuery] string type)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentFilter filter = new AgentFilter();
            filter.AgentID = id;
            filter.AgentType = type;
            filter.SystemPlataformID = this.systemPlataformID;

            AgentResponse response = client.GetMasterAgentsAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/agents/5/subagents
        [HttpGet("{id}/subagents")]
        public AgentResponse GetSubAgents(string id)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentFilter filter = new AgentFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;

            AgentResponse response = client.GetMasterAgentsAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/agents/5/settings
        [HttpGet("{id}/settings")]
        public AgentResponse GetSettings(string id, [FromQuery] string type)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentFilter filter = new AgentFilter();
            filter.AgentID = id;
            filter.AgentType = type;
            filter.SystemPlataformID = this.systemPlataformID;

            AgentResponse response = client.GetAgentSettingByAgentIDAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/agents/5/sports/5/limits
        [HttpGet("{id}/sports/{sportId}/limits")]
        public NakamaAgentService.MarketResponse GetSportsLimits(string id, int sportId)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentMarketSportGroupFilter filter = new AgentMarketSportGroupFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;
            filter.SportID = sportId;

            NakamaAgentService.MarketResponse response = client.GetAgentSportMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/agents/5/sports/5/categories/5/limits
        [HttpGet("{id}/sports/{sportId}/categories/{categoryId}/limits")]
        public NakamaAgentService.MarketResponse GetSportsCategoriesLimits(string id, int sportId, int categoryId)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentMarketCategoryGroupFilter filter = new AgentMarketCategoryGroupFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;
            filter.SportID = sportId;
            filter.CategoryID = categoryId;

            NakamaAgentService.MarketResponse response = client.GetAgentCategoryMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/agents/5/sports/5/categories/5/tournaments/5/limits
        [HttpGet("{id}/sports/{sportId}/categories/{categoryId}/tournaments/{tournamentId}/limits")]
        public NakamaAgentService.MarketResponse GetSportsCategoriesTournamentsLimits(string id, int sportId, int categoryId, int tournamentId)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentMarketTournamentGroupFilter filter = new AgentMarketTournamentGroupFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;
            filter.SportID = sportId;
            filter.CategoryID = categoryId;
            filter.TournamentID = tournamentId;

            NakamaAgentService.MarketResponse response = client.GetAgentTournamentMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/agents/5/players
        [HttpGet("{id}/players")]
        public PlayersListResponse GetPlayers(string id)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerFilter filter = new PlayerFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;

            PlayersListResponse response = client.GetPlayersByAgentIDAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // PUT api/agents/5/settings
        [HttpPut("{id}/settings")]
        public AgentResponse PutSettings(string id, [FromBody]AgentSettingFilter[] settings)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentFilter filter = new AgentFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;
            filter.AgentSettings = settings;

            AgentResponse response = client.SetAgentSettingByAgentIDAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // PUT api/agents/5/sports/5/limits
        [HttpPut("{id}/sports/{sportId}/limits")]
        public AgentResponse PutSportsLimits(string id, int sportId, [FromBody]NakamaAgentService.MarketLimitFilter[] limits)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentMarketSportGroupFilter filter = new AgentMarketSportGroupFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;
            filter.SportID = sportId;
            filter.Limits = limits;

            AgentResponse response = client.SetAgentSportMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // PUT api/agents/5/sports/5/categories/5/limits
        [HttpPut("{id}/sports/{sportId}/categories/{categoryId}/limits")]
        public AgentResponse PutSportsCategoriesLimits(string id, int sportId, int categoryId, [FromBody]NakamaAgentService.MarketLimitFilter[] limits)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentMarketCategoryGroupFilter filter = new AgentMarketCategoryGroupFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;
            filter.SportID = sportId;
            filter.CategoryID = categoryId;
            filter.Limits = limits;

            AgentResponse response = client.SetAgentCategoryMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // PUT api/agents/5/sports/5/categories/5/tournaments/5/limits
        [HttpPut("{id}/sports/{sportId}/categories/{categoryId}/tournaments/{tournamentId}/limits")]
        public AgentResponse PutSportsCategoriesTournamentsLimits(string id, int sportId, int categoryId, int tournamentId, [FromBody]NakamaAgentService.MarketLimitFilter[] limits)
        {
            AgentWebServiceClient client = new AgentWebServiceClient();
            AgentMarketTournamentGroupFilter filter = new AgentMarketTournamentGroupFilter();
            filter.AgentID = id;
            filter.SystemPlataformID = this.systemPlataformID;
            filter.SportID = sportId;
            filter.CategoryID = categoryId;
            filter.TournamentID = tournamentId;
            filter.Limits = limits;

            AgentResponse response = client.SetAgentTournamentMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }
    }
}
