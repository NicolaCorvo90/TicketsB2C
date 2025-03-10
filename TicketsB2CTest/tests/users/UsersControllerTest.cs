using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TicketsB2C;

namespace TicketsB2CTest.tests.tickets;

[Collection("Test collection")]
public class UsersControllerTest: IClassFixture<ApiWebApplicationFactory>
{
    private readonly HttpClient _client;
    
    public UsersControllerTest(ApiWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }
    
    [Fact]
    public async Task RegisterUser()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Email = "test2@test.it",
            Password = "test"
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/users/register", content);
        
        response.EnsureSuccessStatusCode();
    }
    
    [Fact]
    public async Task LoginUserWithWrongPassword()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Email = "test@test.com",
            Password = "test4324"
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        await Assert.ThrowsAsync<BadHttpRequestException>(async () =>
        {
            await _client.PostAsync("/users/login", content);
        });
    }
    
    [Fact]
    public async Task LoginUser()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Email = "test@test.com",
            Password = "test"
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/users/login", content);
        
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(responseString);

        var idClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;

        Assert.NotNull(idClaim);
        Assert.Equal("1", idClaim);
    }
}