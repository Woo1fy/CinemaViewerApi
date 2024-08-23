
using CinemaViewerApi.Services;

namespace eShopOnContainers.Services.AppEnvironment;

public class AppEnvironmentService : IAppEnvironmentService
{
    private readonly INewsfeedService _newsfeedService;

    public INewsfeedService NewsfeedService { get; private set; }

    public AppEnvironmentService(
        INewsfeedService newsfeedService)
    {
        _newsfeedService = newsfeedService;
    }

    public void UpdateDependencies()
    {
        NewsfeedService = _newsfeedService;
    }
}

