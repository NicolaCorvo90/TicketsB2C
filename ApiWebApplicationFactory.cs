

using Microsoft.AspNetCore.Mvc.Testing;

namespace TicketsB2C;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
        });
    }
}