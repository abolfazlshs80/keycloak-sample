using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace keycloak_sample.Controllers
{
 
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger; 
           // _httpClient = new HttpClient();
        }
        [Authorize]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //private readonly HttpClient _httpClient;


        //[HttpGet(Name = "GetAccessTokenAsync")]
        //public async Task<string?> GetAccessTokenAsync()
        //{
        //    var formData = new Dictionary<string, string>
        //{
        //    { "client_id", "my-api" },
        //    { "client_secret", "YOUR_CLIENT_SECRET" },
        //    { "grant_type", "client_credentials" }
        //};

        //    var content = new FormUrlEncodedContent(formData);

        //    var response = await _httpClient.PostAsync("http://localhost:8080/realms/MyRealm/protocol/openid-connect/token", content);

        //    if (!response.IsSuccessStatusCode)
        //        return null;

        //    var json = await response.Content.ReadAsStringAsync();
        //    var token = JsonDocument.Parse(json).RootElement.GetProperty("access_token").GetString();

        //    return token;
        //}


    }
}
