using TicketsB2C;

namespace TicketsB2CTest;

public class HealthControllerTest(ApiWebApplicationFactory factory): IClassFixture<ApiWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();
    
    [Fact]
    public async Task GetHealthTest()
    {
        var response = await _client.GetAsync("/health");
        
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();
        
        Assert.Equal( "OK", responseString);
    }
}