using Autofac;
using CinemaViewerApi.Services;
using CinemaViewerApi.Services.RequestProvider;
using eShopOnContainers.Services.AppEnvironment;

namespace CinemaViewerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //services.AddSingleton<INewsfeedService, NewsfeedService>();
            services.AddSingleton<IRequestProvider, RequestProvider>();

            services.AddSingleton<IAppEnvironmentService, AppEnvironmentService>(
                serviceProvider =>
                {
                    var requestProvider = serviceProvider.GetService<IRequestProvider>();

                    var aes = new AppEnvironmentService(new NewsfeedService(requestProvider, Configuration));
                    aes.UpdateDependencies();
                    return aes;
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
