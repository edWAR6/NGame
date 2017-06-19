using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NakamaPlayerService;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NGame.Middleware.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private static readonly int SYSTEM_ID = 1;

        // GET api/players/5/settings
        [HttpGet("{id}/settings")]
        public PlayerResponse Get(int id)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerFilter filter = new PlayerFilter();
            filter.PlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;

            PlayerResponse response = client.GetPlayerSettingByPlayerIDAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/players/host/5/settings
        [HttpGet("host/{id}/settings")]
        public PlayerResponse GetSettingsByHostPlayerId(string id)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerFilter filter = new PlayerFilter();
            filter.HostPlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;

            PlayerResponse response = client.GetPlayerSettingByHostPlayerIDAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/players/5/sports/5/limits
        [HttpGet("{id}/sports/{sportId}/limits")]
        public MarketResponse GetSportsLimits(int id, int sportId)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerMarketSportGroupFilter filter = new PlayerMarketSportGroupFilter();
            filter.PlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;
            filter.SportID = sportId;

            MarketResponse response = client.GetPlayerSportMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/players/5/sports/5/categories/5/limits
        [HttpGet("{id}/sports/{sportId}/categories/{categoryId}/limits")]
        public NakamaPlayerService.MarketResponse GetSportsCategoriesLimits(int id, int sportId, int categoryId)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerMarketCategoryGroupFilter filter = new PlayerMarketCategoryGroupFilter();
            filter.PlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;
            filter.SportID = sportId;
            filter.CategoryID = categoryId;

            MarketResponse response = client.GetPlayerCategoryMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/players/5/sports/5/categories/5/tournaments/5/limits
        [HttpGet("{id}/sports/{sportId}/categories/{categoryId}/tournaments/{tournamentId}/limits")]
        public MarketResponse GetSportsCategoriesTournamentsLimits(int id, int sportId, int categoryId, int tournamentId)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerMarketTournamentGroupFilter filter = new PlayerMarketTournamentGroupFilter();
            filter.PlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;
            filter.SportID = sportId;
            filter.CategoryID = categoryId;
            filter.TournamentID = tournamentId;

            MarketResponse response = client.GetPlayerTournamentMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // PUT api/players/5/settings
        [HttpPut("{id}/settings")]
        public PlayerResponse PutPlayersSettings(int id, [FromBody]PlayerSettingFilter[] settings)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerFilter filter = new PlayerFilter();
            filter.PlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;
            filter.PlayerSettings = settings;

            PlayerResponse response = client.SetPlayerSettingAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // PUT api/players/5/sports/5/limits
        [HttpPut("{id}/sports/{sportId}/limits")]
        public PlayerResponse PutSportsLimits(int id, int sportId, [FromBody]MarketLimitFilter[] limits)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerMarketSportGroupFilter filter = new PlayerMarketSportGroupFilter();
            filter.PlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;
            filter.SportID = sportId;
            filter.Limits = limits;

            PlayerResponse response = client.SetPlayerSportMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // PUT api/players/5/sports/5/categories/5/limits
        [HttpPut("{id}/sports/{sportId}/categories/{categoryId}/limits")]
        public PlayerResponse PutSportsCategoriesLimits(int id, int sportId, int categoryId, [FromBody]MarketLimitFilter[] limits)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerMarketCategoryGroupFilter filter = new PlayerMarketCategoryGroupFilter();
            filter.PlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;
            filter.SportID = sportId;
            filter.CategoryID = categoryId;
            filter.Limits = limits;

            PlayerResponse response = client.SetPlayerCategoryMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // PUT api/players/5/sports/5/categories/5/tournaments/5/limits
        [HttpPut("{id}/sports/{sportId}/categories/{categoryId}/tournaments/{tournamentId}/limits")]
        public PlayerResponse PutSportsCategoriesTournamentsLimits(int id, int sportId, int categoryId, int tournamentId, [FromBody]MarketLimitFilter[] limits)
        {
            PlayerWebServiceClient client = new PlayerWebServiceClient();
            PlayerMarketTournamentGroupFilter filter = new PlayerMarketTournamentGroupFilter();
            filter.PlayerID = id;
            filter.AgentSystemID = SYSTEM_ID;
            filter.SportID = sportId;
            filter.CategoryID = categoryId;
            filter.TournamentID = tournamentId;
            filter.Limits = limits;

            PlayerResponse response = client.SetPlayerTournamentMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }
    }
}
