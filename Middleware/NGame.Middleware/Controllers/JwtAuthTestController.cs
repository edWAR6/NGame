using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NGame.Middleware.Controllers
{
  [Route("api/test")]
  public class JwtAuthTestController : Controller
  {
    private readonly JsonSerializerSettings _serializerSettings;

    public JwtAuthTestController()
    {
      _serializerSettings = new JsonSerializerSettings
      {
        Formatting = Formatting.Indented
      };
    }

    [HttpGet]
    // [Authorize(Policy = "DisneyUser")]
    [Authorize(Policy = "AgentRole")]
    public IActionResult Get()
    {
      var response = new
      {
        made_it = "Welcome Mickey!"
      };

      var json = JsonConvert.SerializeObject(response, _serializerSettings);
      return new OkObjectResult(json);
    }
  }
}