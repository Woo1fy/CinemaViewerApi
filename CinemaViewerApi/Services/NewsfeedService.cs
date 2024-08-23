using CinemaViewerApi.Services.RequestProvider;
using CinemaViewerApi.Helpers;
using CinemaViewerApi.Models;
using CinemaViewerApi.Logic;

namespace CinemaViewerApi.Services
{
    public class NewsfeedService : INewsfeedService
    {
        private const string ApiUrlBase = "https://newsapi.org/v2/everything?domains=hollywoodreporter.com";

        private const string ApiVersion = "News-API-csharp/0.1";

        private readonly IRequestProvider _requestProvider;
        private readonly string _apiKey;

        public NewsfeedService(IRequestProvider requestProvider
            , IConfiguration configuration)
        {
            _requestProvider = requestProvider;
            _apiKey = configuration["NewsApiKey"]!;

            _requestProvider.SetDefaultRequestHeaders(
                    new Dictionary<string, string?>()
                    {
                        { "user-agent", ApiVersion },
                        { "x-api-key", _apiKey }
                    }
                );
        }

        public async Task<IEnumerable<Article>> GetNewsfeedAsync()
        {
            var uri = UriHelper.CombineUri($"{ApiUrlBase}&pageSize=10&apiKey={_apiKey}");
            var newsfeed = await _requestProvider.GetAsync<ApiResponse>(uri).ConfigureAwait(false);
            if (newsfeed?.Articles != null)
            {
               return await newsfeed.Articles.GetVideos();
            }
            //if (catalog?.Data != null)
            //{
            //    _fixUriService.FixCatalogItemPictureUri(catalog.Data);
            //    return catalog.Data;
            //}

            return Enumerable.Empty<Article>();
        }
    }
}
