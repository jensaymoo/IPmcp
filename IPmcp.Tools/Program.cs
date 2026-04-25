using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using IPmcp.App.Services.Entities;
using IPmcp.App.Services.Fields;
using IPmcp.Database;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol;
using ModelContextProtocol.Protocol;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole(o 
    => o.LogToStandardErrorThreshold = LogLevel.Trace);

var loggingLevel = LoggingLevel.Debug;

var database = builder.Configuration["database"]
    ?? throw new InvalidOperationException(
        "Required configuration missing. Pass --database <connection_string> or set the DATABASE environment variable.");

builder.Services.AddLinqToDBContext<AppDataConnection>((provider, options) =>
    options.UseConnectionString(ProviderName.PostgreSQL, database)
        .UseDefaultLogging(provider));

builder.Services.AddScoped<IEntityService, EntityService>();
builder.Services.AddScoped<IFieldService, FieldService>();

var serializerOptions = new JsonSerializerOptions
{
    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower) },
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
    WriteIndented = false
};

builder.Services
    .AddMcpServer(options =>
    {
        options.ServerInfo = new Implementation
        {
            Name = nameof(IPmcp),
            Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0",
            WebsiteUrl = "https://github.com/jensaymoo/IPmcp",
            Description = "MCP server for querying IdeaPlatform entity metadata — entity types, fields, and their configurations."
        };
    })
    .WithStdioServerTransport()
    .WithToolsFromAssembly(serializerOptions: serializerOptions)    
    .WithSetLoggingLevelHandler(async (ctx, ct) =>
    {
        if (ctx.Params?.Level is null)
            throw new McpException("Missing required argument 'level'");

        loggingLevel = ctx.Params.Level;
        return new EmptyResult();
    });

builder.Services.AddSingleton<Func<LoggingLevel>>(_ => () => loggingLevel);

await builder.Build()
    .RunAsync();
