using UserApplication.Interfaces;
using UserApplication.Services;
using UserCore.Entities;
using UserCore.InterfaceRepositories;
using UserInfrastructure.Repositories;

namespace UserPresentation.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<User>, BaseRepository<User>>();
            services.AddTransient<IBaseRepository<Follow>, BaseRepository<Follow>>();
            services.AddTransient<IFollowRepository, FollowRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFollowService, FollowService>();
            services.AddTransient<IBaseServices<User>, UserService>();
            services.AddTransient<IStorageService, FileStorageService>();

            services.AddScoped<IPushNotificationService, PushNotificationService>();
        }
    }
}