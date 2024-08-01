using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Zion.System.EntityFrameworkCore;

public class SystemHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<SystemHttpApiHostMigrationsDbContext>
{
    public SystemHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SystemHttpApiHostMigrationsDbContext>()
            .UseMySql(configuration.GetConnectionString("System"), MySqlServerVersion.LatestSupportedServerVersion);

        return new SystemHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
