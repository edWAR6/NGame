using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NakamaMarketService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NGame.Middleware.Controllers
{
    [Route("api/[controller]")]
    public class MarketsController : Controller
    {
        private IConfiguration configuration;
        private int systemPlataformID;

        public MarketsController(IConfiguration configuration) {
            this.configuration = configuration;
            this.systemPlataformID = configuration.GetValue<int>("SystemPlataformID");
        }

        // GET: api/markets
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", systemPlataformID.ToString() };
        }

        // GET api/markets/sports/5/limits
        [HttpGet("sports/{id}/limits")]
        public MarketResponse Get(int id)
        {
            MarketWebServiceClient client = new MarketWebServiceClient();
            MarketSportFilter filter = new MarketSportFilter();
            filter.SportID = id;
            filter.SystemPlataformID = this.systemPlataformID;

            MarketResponse response = client.GetSportMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/markets/sports/5/categories/5/limits
        [HttpGet("sports/{id}/categories/{categoryId}/limits")]
        public MarketResponse Get(int id, int categoryId)
        {
            MarketWebServiceClient client = new MarketWebServiceClient();
            MarketCategoryFilter filter = new MarketCategoryFilter();
            filter.SportID = id;
            filter.CategoryID = categoryId;
            filter.SystemPlataformID = this.systemPlataformID;

            MarketResponse response = client.GetCategoryMarketAsync(filter).Result;
            client.CloseAsync();

            return response;
        }

        // GET api/markets/sports/5/categories/5/tournaments/5/limits
        [HttpGet("sports/{id}/categories/{categoryId}/tournaments/{tournamentId}/limits")]
        public MarketResponse Get(int id, int categoryId, int tournamentId)
        {
            MarketWebServiceClient client = new MarketWebServiceClient();
            MarketTournamentFilter filter = new MarketTournamentFilter();
            filter.SportID = id;
            filter.CategoryID = categoryId;
            filter.TournamentID = tournamentId;
            filter.SystemPlataformID = this.systemPlataformID;

            MarketResponse response = client.GetCategoryMarketAsync(filter).Result;
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
