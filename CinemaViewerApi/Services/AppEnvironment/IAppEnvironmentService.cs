
using CinemaViewerApi.Services;

namespace eShopOnContainers.Services.AppEnvironment;

public interface IAppEnvironmentService
{
    INewsfeedService NewsfeedService { get; }

    void UpdateDependencies();
}