using Microsoft.EntityFrameworkCore;
namespace DidarCodeChallenge.Api.Context.Migration;

public class MigrationManager
{
    public static void Migrate(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateAsyncScope();
        var dataContexService = serviceScope.ServiceProvider.GetService<DataContext>();
        dataContexService.Database.Migrate();
    }
}