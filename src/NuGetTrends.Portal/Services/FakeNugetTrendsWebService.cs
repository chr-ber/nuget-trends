using System.Text.Json;
using NuGetTrends.Portal.Models;

namespace NuGetTrends.Portal.Services;

public class FakeNugetTrendsWebService() : INugetTrendsWebService
{
    private static readonly JsonSerializerOptions? JsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    private static readonly Dictionary<string, PackageSearchResult> FakePackages = new()
    {
        { "Newtonsoft.Json", new PackageSearchResult("Newtonsoft.Json", 2_500_000_000, "https://api.nuget.org/v3-flatcontainer/newtonsoft.json/13.0.3/icon") },
        { "System.Text.Json", new PackageSearchResult("System.Text.Json", 1_800_000_000, "https://api.nuget.org/v3-flatcontainer/system.text.json/8.0.0/icon") },
        { "AutoMapper", new PackageSearchResult("AutoMapper", 900_000_000, "https://api.nuget.org/v3-flatcontainer/automapper/12.0.1/icon") },
        { "EntityFramework", new PackageSearchResult("EntityFramework", 1_200_000_000, "https://api.nuget.org/v3-flatcontainer/entityframework/6.4.4/icon") },
        { "Microsoft.EntityFrameworkCore", new PackageSearchResult("Microsoft.EntityFrameworkCore", 1_500_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.entityframeworkcore/8.0.0/icon") },
        { "Serilog", new PackageSearchResult("Serilog", 600_000_000, "https://api.nuget.org/v3-flatcontainer/serilog/3.1.1/icon") },
        { "NLog", new PackageSearchResult("NLog", 400_000_000, "https://api.nuget.org/v3-flatcontainer/nlog/5.2.8/icon") },
        { "FluentValidation", new PackageSearchResult("FluentValidation", 300_000_000, "https://api.nuget.org/v3-flatcontainer/fluentvalidation/11.9.0/icon") },
        { "Dapper", new PackageSearchResult("Dapper", 700_000_000, "https://api.nuget.org/v3-flatcontainer/dapper/2.1.35/icon") },
        { "xunit", new PackageSearchResult("xunit", 500_000_000, "https://api.nuget.org/v3-flatcontainer/xunit/2.4.2/icon") },
        { "NUnit", new PackageSearchResult("NUnit", 350_000_000, "https://api.nuget.org/v3-flatcontainer/nunit/3.14.0/icon") },
        { "Moq", new PackageSearchResult("Moq", 450_000_000, "https://api.nuget.org/v3-flatcontainer/moq/4.20.69/icon") },
        { "Castle.Core", new PackageSearchResult("Castle.Core", 800_000_000, "https://api.nuget.org/v3-flatcontainer/castle.core/5.1.1/icon") },
        { "Microsoft.Extensions.DependencyInjection", new PackageSearchResult("Microsoft.Extensions.DependencyInjection", 1_100_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection/8.0.0/icon") },
        { "Microsoft.Extensions.Logging", new PackageSearchResult("Microsoft.Extensions.Logging", 1_000_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging/8.0.0/icon") },
        { "Microsoft.Extensions.Configuration", new PackageSearchResult("Microsoft.Extensions.Configuration", 950_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration/8.0.0/icon") },
        { "Polly", new PackageSearchResult("Polly", 200_000_000, "https://api.nuget.org/v3-flatcontainer/polly/8.2.0/icon") },
        { "RestSharp", new PackageSearchResult("RestSharp", 300_000_000, "https://api.nuget.org/v3-flatcontainer/restsharp/110.2.0/icon") },
        { "Swashbuckle.AspNetCore", new PackageSearchResult("Swashbuckle.AspNetCore", 250_000_000, "https://api.nuget.org/v3-flatcontainer/swashbuckle.aspnetcore/6.5.0/icon") },
        { "Microsoft.AspNetCore.Mvc", new PackageSearchResult("Microsoft.AspNetCore.Mvc", 600_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.mvc/2.2.0/icon") },
        { "Microsoft.AspNetCore.Authentication.JwtBearer", new PackageSearchResult("Microsoft.AspNetCore.Authentication.JwtBearer", 180_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.authentication.jwtbearer/8.0.0/icon") },
        { "System.IdentityModel.Tokens.Jwt", new PackageSearchResult("System.IdentityModel.Tokens.Jwt", 220_000_000, "https://api.nuget.org/v3-flatcontainer/system.identitymodel.tokens.jwt/7.0.3/icon") },
        { "Microsoft.AspNetCore.Identity.EntityFrameworkCore", new PackageSearchResult("Microsoft.AspNetCore.Identity.EntityFrameworkCore", 150_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.identity.entityframeworkcore/8.0.0/icon") },
        { "Microsoft.AspNetCore.SignalR", new PackageSearchResult("Microsoft.AspNetCore.SignalR", 100_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.signalr/1.1.0/icon") },
        { "Microsoft.EntityFrameworkCore.SqlServer", new PackageSearchResult("Microsoft.EntityFrameworkCore.SqlServer", 400_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.entityframeworkcore.sqlserver/8.0.0/icon") },
        { "Microsoft.EntityFrameworkCore.InMemory", new PackageSearchResult("Microsoft.EntityFrameworkCore.InMemory", 120_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.entityframeworkcore.inmemory/8.0.0/icon") },
        { "Microsoft.EntityFrameworkCore.Sqlite", new PackageSearchResult("Microsoft.EntityFrameworkCore.Sqlite", 80_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.entityframeworkcore.sqlite/8.0.0/icon") },
        { "Npgsql.EntityFrameworkCore.PostgreSQL", new PackageSearchResult("Npgsql.EntityFrameworkCore.PostgreSQL", 90_000_000, "https://api.nuget.org/v3-flatcontainer/npgsql.entityframeworkcore.postgresql/8.0.0/icon") },
        { "MongoDB.Driver", new PackageSearchResult("MongoDB.Driver", 150_000_000, "https://api.nuget.org/v3-flatcontainer/mongodb.driver/2.23.1/icon") },
        { "StackExchange.Redis", new PackageSearchResult("StackExchange.Redis", 200_000_000, "https://api.nuget.org/v3-flatcontainer/stackexchange.redis/2.7.10/icon") },
        { "Microsoft.Extensions.Caching.Memory", new PackageSearchResult("Microsoft.Extensions.Caching.Memory", 300_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.caching.memory/8.0.0/icon") },
        { "Microsoft.Extensions.Caching.Redis", new PackageSearchResult("Microsoft.Extensions.Caching.Redis", 60_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.caching.redis/2.2.0/icon") },
        { "Hangfire", new PackageSearchResult("Hangfire", 80_000_000, "https://api.nuget.org/v3-flatcontainer/hangfire/1.8.6/icon") },
        { "Quartz", new PackageSearchResult("Quartz", 70_000_000, "https://api.nuget.org/v3-flatcontainer/quartz/3.8.0/icon") },
        { "MediatR", new PackageSearchResult("MediatR", 150_000_000, "https://api.nuget.org/v3-flatcontainer/mediatr/12.2.0/icon") },
        { "AutoMapper.Extensions.Microsoft.DependencyInjection", new PackageSearchResult("AutoMapper.Extensions.Microsoft.DependencyInjection", 120_000_000, "https://api.nuget.org/v3-flatcontainer/automapper.extensions.microsoft.dependencyinjection/12.0.1/icon") },
        { "FluentAssertions", new PackageSearchResult("FluentAssertions", 200_000_000, "https://api.nuget.org/v3-flatcontainer/fluentassertions/6.12.0/icon") },
        { "Bogus", new PackageSearchResult("Bogus", 50_000_000, "https://api.nuget.org/v3-flatcontainer/bogus/35.0.1/icon") },
        { "Microsoft.AspNetCore.Mvc.Testing", new PackageSearchResult("Microsoft.AspNetCore.Mvc.Testing", 40_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.mvc.testing/8.0.0/icon") },
        { "Microsoft.Extensions.Hosting", new PackageSearchResult("Microsoft.Extensions.Hosting", 500_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting/8.0.0/icon") },
        { "Microsoft.Extensions.Http", new PackageSearchResult("Microsoft.Extensions.Http", 300_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http/8.0.0/icon") },
        { "System.ComponentModel.Annotations", new PackageSearchResult("System.ComponentModel.Annotations", 2_000_000_000, "https://api.nuget.org/v3-flatcontainer/system.componentmodel.annotations/8.0.0/icon") },
        { "Microsoft.Extensions.Options", new PackageSearchResult("Microsoft.Extensions.Options", 1_200_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/8.0.0/icon") },
        { "Microsoft.Extensions.Options.ConfigurationExtensions", new PackageSearchResult("Microsoft.Extensions.Options.ConfigurationExtensions", 800_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options.configurationextensions/8.0.0/icon") },
        { "System.Linq.Async", new PackageSearchResult("System.Linq.Async", 100_000_000, "https://api.nuget.org/v3-flatcontainer/system.linq.async/6.0.1/icon") },
        { "Microsoft.AspNetCore.Cors", new PackageSearchResult("Microsoft.AspNetCore.Cors", 200_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.cors/2.2.0/icon") },
        { "Microsoft.AspNetCore.Authorization", new PackageSearchResult("Microsoft.AspNetCore.Authorization", 300_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.authorization/8.0.0/icon") },
        { "System.Net.Http.Json", new PackageSearchResult("System.Net.Http.Json", 400_000_000, "https://api.nuget.org/v3-flatcontainer/system.net.http.json/8.0.0/icon") },
        { "Microsoft.AspNetCore.Components.Web", new PackageSearchResult("Microsoft.AspNetCore.Components.Web", 80_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.components.web/8.0.0/icon") },
        { "Microsoft.AspNetCore.Components.WebAssembly", new PackageSearchResult("Microsoft.AspNetCore.Components.WebAssembly", 60_000_000, "https://api.nuget.org/v3-flatcontainer/microsoft.aspnetcore.components.webassembly/8.0.0/icon") }
    };

    public Task<ICollection<PackageSearchResult>> SearchPackagesAsync(string query, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
            return Task.FromResult<ICollection<PackageSearchResult>>(FakePackages.Values.Take(10).ToList());

        var results = FakePackages.Values
            .Where(p => p.PackageId.Contains(query, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(p => p.LatestDownloadCount)
            .Take(20)
            .ToList();

        return Task.FromResult<ICollection<PackageSearchResult>>(results);
    }

    public Task<HistoryResult> GetDownloadHistoryAsync(string packageId, int? months, CancellationToken cancellationToken = default)
    {
        if (!FakePackages.TryGetValue(packageId, out var package))
            return Task.FromResult(new HistoryResult(packageId, []));

        var monthsToGenerate = Math.Min(months ?? 12, 120);
        var downloads = new List<DailyDownloads>();

        var baseDownloadCount = package.LatestDownloadCount ?? 1_000_000;
        var weeklyGrowthRate = 0.001 + (Random.Shared.NextDouble() * 0.009);

        var startDate = DateTime.UtcNow.AddMonths(-monthsToGenerate);
        var currentDate = startDate;
        long cumulativeDownloads = Math.Max(1000, baseDownloadCount / 10); // Start with 10% of current downloads

        while (currentDate <= DateTime.UtcNow)
        {
            // Add some randomness to growth but ensure it's always increasing
            var growthMultiplier = 1 + (weeklyGrowthRate * (0.5 + Random.Shared.NextDouble()));
            cumulativeDownloads = (long)(cumulativeDownloads * growthMultiplier);

            downloads.Add(new DailyDownloads(cumulativeDownloads, currentDate));
            currentDate = currentDate.AddDays(7); // Weekly data points
        }

        return Task.FromResult(new HistoryResult(packageId, downloads));
    }

    public async Task<HistoryResult?> GetDownloadHistoryAltAsync(string packageId, int? months, CancellationToken cancellationToken = default)
    {
        // Just delegate to the main method for consistency
        return await GetDownloadHistoryAsync(packageId, months, cancellationToken);
    }
}
