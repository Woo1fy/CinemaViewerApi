using CinemaViewerApi.Models;
using CinemaViewerApi.Services;
using eShopOnContainers.Services.AppEnvironment;
using Microsoft.AspNetCore.Mvc;

namespace CinemaViewerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsApiController : ControllerBase
    {
        private readonly ILogger<NewsApiController> _logger;
        private readonly IAppEnvironmentService _appEnvironmentService;

        public NewsApiController(IAppEnvironmentService appEnvironmentService, ILogger<NewsApiController> logger)
        {
            _appEnvironmentService = appEnvironmentService;
            _logger = logger;
        }

        [HttpGet(Name = "newsfeed")]
        public async Task<IEnumerable<Article>> Get()
        {
            return await _appEnvironmentService.NewsfeedService.GetNewsfeedAsync();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
