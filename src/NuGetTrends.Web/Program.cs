using Serilog;
using SystemEnvironment = System.Environment;
using Sentry;

namespace NuGetTrends.Web;

public static class Program
{
    private const string Production = nameof(Production);
    private static readonly string Environment
        = SystemEnvironment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Production;

    public static IConfiguration Configuration { get; private set; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment}.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

    public static int Main(string[] args)
    {
        if (Environment != Production)
        {
            Serilog.Debugging.SelfLog.Enable(Console.Error);
        }

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            .CreateLogger();

        try
        {
            Log.Information("Starting.");

            CreateHostBuilder(args).Build().Run();

            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseConfiguration(Configuration)
                    .UseSentry(o =>
                    {
                        o.CaptureFailedRequests = true;
                        o.TracesSampler = context => context.CustomSamplingContext.TryGetValue("__HttpPath", out var path)
                                                     && path is "/t"
                            ? 0 // tunneling JS events
                            : 1.0;
                        o.AddExceptionFilterForType<OperationCanceledException>();
                        if (Environment != Production)
                        {
                            o.EnableSpotlight = true;
                        }
                    })
                    .UseStartup<Startup>();
            });
}
