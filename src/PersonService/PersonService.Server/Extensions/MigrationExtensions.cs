using Microsoft.EntityFrameworkCore;

namespace PersonService.Server.Extensions;

public static class MigrationExtensions
{
    public static async Task<IHost> MigrateDatabaseAsync<TContext>(this IHost webHost) where TContext : DbContext
    {
        await using var serviceScope = webHost.Services.CreateAsyncScope();
        await using var context = serviceScope.ServiceProvider.GetRequiredService<TContext>();

        await context.Database.MigrateAsync();

        return webHost;
    }
}
