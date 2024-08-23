using AngleSharp;
using AngleSharp.Dom;
using CinemaViewerApi.Models;

namespace CinemaViewerApi.Logic
{
    public static class AdditionalDataLogic
    {
        public async static Task<List<Article>> GetVideos(this List<Article> articles)
        {
            foreach (var article in articles)
            {
                var config = Configuration.Default.WithDefaultLoader();
                var address = article.Url;
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(address);
                var srcAttr = document.QuerySelector(".youtube-player")?.Attributes?
                    .FirstOrDefault(x => x.Name == "src");
                if (srcAttr != null)
                {
                    article.UrlToVideo = srcAttr.Value;
                }
            }

            return articles;
        }
    }
}
