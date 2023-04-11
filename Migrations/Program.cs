// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Migrations;
using Migrations.GroupLevelDefaults;
using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Migration Tool");

var build = new ConfigurationBuilder();
InitBuildConfig(build);

Tranformer.Run();

static void InitBuildConfig(IConfigurationBuilder configBuilder)
{
    configBuilder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(path: $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
        .AddEnvironmentVariables();
    configBuilder.Add
}

Console.ReadLine();