using Microsoft.EntityFrameworkCore;
using BlogAPIDotnet.Data;

namespace BlogAPIDotnet.Services.Configuration
{
    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    public class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<BlogContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
        }
    }
}