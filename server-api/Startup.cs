using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ServerApi
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
            // Add configuration for Azure OpenAI API credentials
            services.AddSingleton(provider => new AzureAIOptions
            {
                ApiKey = Configuration["AzureOpenAI:ApiKey"],
                Endpoint = Configuration["AzureOpenAI:Endpoint"]
            });

            // Add DbContext for SQL Server
            services.AddDbContext<ChatContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ChatDatabase")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Set up any additional routing and middleware for the API here
            });
        }
    }

    public class AzureAIOptions
    {
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
    }

    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
    }

    public class ChatMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
