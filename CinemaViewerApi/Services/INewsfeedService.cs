using CinemaViewerApi.Models;
using System.Net.Http.Headers;

namespace CinemaViewerApi.Services
{
    public interface INewsfeedService
    {
        Task<IEnumerable<Article>> GetNewsfeedAsync();
    }
}
