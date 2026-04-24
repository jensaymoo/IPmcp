using IPmcp.App.Services.Fields;
using IPmcp.App.Services.Entities;
using IPmcp.Database;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var database = ParseArg(args, "-database")
    ?? throw new InvalidOperationException("Required argument -database is missing. Usage: IPmcp.Tools -database <connection_string>");

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddLinqToDBContext<AppDataConnection>((provider, options) =>
    options.UseConnectionString(ProviderName.PostgreSQL, database)
        .UseDefaultLogging(provider));

builder.Services.AddScoped<IEntityService, EntityService>();
builder.Services.AddScoped<IFieldService, FieldService>();

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build()
    .RunAsync();

static string? ParseArg(string[] args, string key)
{
    var index = Array.IndexOf(args, key);
    return index >= 0 && index + 1 < args.Length ? args[index + 1] : null;
}
