using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using WebLibraryApp.Data;
using WebLibraryApp.GraphQL;
using WebLibraryApp.Options;
using System.Reflection;
using Serilog.Formatting.Elasticsearch;
using Elasticsearch.Net;
using WebLibraryApp.Helpers;

namespace WebLibraryApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var environment = builder.Environment.EnvironmentName;

            var loggerConfiguration = new LoggerConfiguration();
            if (builder.Environment.IsProduction())
            {
                loggerConfiguration
                    .WriteTo
                    .Elasticsearch(ElasticsearchSinkHelper.ConfigureElasticSink(builder.Configuration, environment));
            }

            Log.Logger = loggerConfiguration
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            string? useSerilogDebugging = Environment.GetEnvironmentVariable("USE_SERILOG_DEBUGGING");
            if (builder.Environment.IsDevelopment() || string.Equals(useSerilogDebugging, "TRUE"))
            {
                Serilog.Debugging.SelfLog.Enable(s => Console.WriteLine($"\\n{s}\\n"));
            }

            try
            {
                await Setup(builder);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application fatal error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static async Task Setup(WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog();

            if(builder.Environment.IsDevelopment())
            {
                builder.Services.AddPooledDbContextFactory<AppDbContext>(opts => opts.UseInMemoryDatabase("InMemory"));
            } 
            else
            {
                string sqlServerConnection = builder.Configuration.GetConnectionString("SqlServer");
                builder.Services.AddPooledDbContextFactory<AppDbContext>(opts => opts.UseSqlServer(sqlServerConnection));
            }

            builder.Services
                .AddGraphQLServer()
                .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseGraphQLVoyager();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQLVoyager();
                endpoints.MapGraphQL();
            });

            await AppDbContextSeed.Seed(app, app.Environment);

            app.Run();
        }
    }
}