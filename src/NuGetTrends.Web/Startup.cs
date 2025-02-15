using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NuGetTrends.Data;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using Shortr;
using Shortr.Npgsql;

namespace NuGetTrends.Web;

public class Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSentryTunneling(); // Add Sentry Tunneling to avoid ad-blockers.
        services.AddControllers();
        services.AddHttpClient();

        // In production, the Angular files will be served from this directory
        services.AddSpaStaticFiles(c =>
        {
            c.RootPath = "Portal/dist";
        });

        if (hostingEnvironment.IsDevelopment())
        {
            // keep cors during development so we can still run the spa on Angular default port (4200)
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetPreflightMaxAge(TimeSpan.FromDays(1));
                    });
            });
        }

        services.AddDbContext<NuGetTrendsContext>(options =>
        {
            var connString = configuration.GetNuGetTrendsConnectionString();
            options.UseNpgsql(connString);
            if (hostingEnvironment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
            }
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "NuGet Trends", Version = "v1"});
            var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        services.AddShortr();
        if (!hostingEnvironment.IsDevelopment())
        {
            services.Replace(ServiceDescriptor.Singleton<IShortrStore, NpgsqlShortrStore>());
            services.AddSingleton(_ => new NpgsqlShortrOptions
            {
                ConnectionString = configuration.GetNuGetTrendsConnectionString()
            });
        }
    }

    public void Configure(IApplicationBuilder app)
    {
        app.Use(async (context, next) => {
            context.Response.OnStarting(() => {
                // Sentry Browser Profiling
                // https://docs.sentry.io/platforms/javascript/profiling/
                context.Response.Headers.Append("Document-Policy", "js-profiling");
                return Task.CompletedTask;
            });
            await next();
        });

        app.UseStaticFiles();
        if (!hostingEnvironment.IsDevelopment())
        {
            app.UseSpaStaticFiles();
        }

        app.UseRouting();
        app.UseSentryTracing();

        if (hostingEnvironment.IsDevelopment())
        {
            app.UseCors("AllowAll");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NuGet Trends");
                c.DocumentTitle = "NuGet Trends API";
                c.DocExpansion(DocExpansion.None);
            });
        }

        // Proxy Sentry events from the frontend to sentry.io
        // https://docs.sentry.io/platforms/javascript/troubleshooting/#using-the-tunnel-option
        // https://docs.sentry.io/platforms/dotnet/guides/aspnetcore/#tunnel
        app.UseSentryTunneling("/t");

        app.UseSwagger();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "Portal";
            if (hostingEnvironment.IsDevelopment())
            {
                // use the external angular CLI server instead
                spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            }
        });

        app.UseShortr();
    }
}
