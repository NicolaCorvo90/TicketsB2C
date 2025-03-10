using System.Net;
using System.Text;
using Newtonsoft.Json;
using TicketsB2C;
using TicketsB2C.tickets;
using TicketsB2C.tickets.readmodel;

namespace TicketsB2CTest.tests.tickets;

public class TicketsControllerTest: IClassFixture<ApiWebApplicationFactory>
{
    private readonly HttpClient _client;
    
    public TicketsControllerTest(ApiWebApplicationFactory factory)
    {
        _client = factory.CreateClient();

        new InitializeTests();
    }
    
    [Fact]
    public async Task GetTicketsTest()
    {
        var response = await _client.GetAsync("/tickets/GetTickets");
        
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();
        
        var tickets = JsonConvert.DeserializeObject<List<Tickets>>(responseString);
        Assert.NotNull(tickets);
        Assert.NotEmpty(tickets);
        
        Assert.Equal(7, tickets.Count);

        foreach (Tickets ticket in tickets)
        {
            Assert.True(ticket.Id > 0, "Ticket Id should be a positive number.");
            Assert.False(string.IsNullOrEmpty(ticket.DepartureCity), "DepartureCity should not be null or empty.");
            Assert.False(string.IsNullOrEmpty(ticket.DestinationCity), "DestinationCity should not be null or empty.");
            Assert.False(string.IsNullOrEmpty(ticket.Type), "Type should not be null or empty.");
            Assert.True(ticket.PriceInCent >= 0, "PriceInCent should be a non-negative number.");
            Assert.NotNull(ticket.Carrier);
            Assert.True(ticket.Carrier.Id > 0, "Carrier Id should be a positive number.");
            Assert.False(string.IsNullOrEmpty(ticket.Carrier.Name), "Carrier Name should not be null or empty.");
        }
    }
    
    [Fact]
    public async Task GetTicketByInvalidCarrier()
    {
        var response = await _client.GetAsync("/tickets/GetTicketsByCarrier/9");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task GetTicketByValidCarrier()
    {
        var response = await _client.GetAsync("/tickets/GetTicketsByCarrier/1");
        
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();
        
        var tickets = JsonConvert.DeserializeObject<List<Tickets>>(responseString);
        Assert.NotNull(tickets);
        Assert.NotEmpty(tickets);
        
        Assert.Equal(4, tickets.Count);

        foreach (Tickets ticket in tickets)
        {
            Assert.True(ticket.Id > 0, "Ticket Id should be a positive number.");
            Assert.False(string.IsNullOrEmpty(ticket.DepartureCity), "DepartureCity should not be null or empty.");
            Assert.False(string.IsNullOrEmpty(ticket.DestinationCity), "DestinationCity should not be null or empty.");
            Assert.False(string.IsNullOrEmpty(ticket.Type), "Type should not be null or empty.");
            Assert.True(ticket.PriceInCent >= 0, "PriceInCent should be a non-negative number.");
            Assert.NotNull(ticket.Carrier);
            Assert.True(ticket.Carrier.Id > 0, "Carrier Id should be a positive number.");
            Assert.False(string.IsNullOrEmpty(ticket.Carrier.Name), "Carrier Name should not be null or empty.");
        }
    }
    
    [Fact]
    public async Task SearchTicketsByInvalidParams()
    {
        var response = await _client.GetAsync("/tickets/SearchTickets?DepartureCity=Termoli");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task SearchTicketsByValidCities()
    {
        var response = await _client.GetAsync("/tickets/SearchTickets?DepartureCity=Roma&DestinationCity=Napoli");
        
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();
        
        var tickets = JsonConvert.DeserializeObject<List<Tickets>>(responseString);
        Assert.NotNull(tickets);
        Assert.NotEmpty(tickets);
        
        Assert.Equal(2, tickets.Count);

        foreach (Tickets ticket in tickets)
        {
            Assert.True(ticket.Id > 0, "Ticket Id should be a positive number.");
            Assert.False(string.IsNullOrEmpty(ticket.DepartureCity), "DepartureCity should not be null or empty.");
            Assert.False(string.IsNullOrEmpty(ticket.DestinationCity), "DestinationCity should not be null or empty.");
            Assert.False(string.IsNullOrEmpty(ticket.Type), "Type should not be null or empty.");
            Assert.True(ticket.PriceInCent >= 0, "PriceInCent should be a non-negative number.");
            Assert.NotNull(ticket.Carrier);
            Assert.True(ticket.Carrier.Id > 0, "Carrier Id should be a positive number.");
            Assert.False(string.IsNullOrEmpty(ticket.Carrier.Name), "Carrier Name should not be null or empty.");
        }
    }
    
    [Fact]
    public async Task BuyTicketByInvalidParams()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TicketId = 1
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/tickets/BuyTicket", content);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task BuyTicketWithQuantity1()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TicketId = 1,
            quantity = 1,
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/tickets/BuyTicket", content);
        
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BuyTicketReadModel>(responseString);

        Assert.NotNull(result);
        Assert.Equal(1455, result.TotalInCent);
    }
    
    [Fact]
    public async Task BuyTicketWithQuantity4()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TicketId = 4,
            quantity = 4,
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/tickets/BuyTicket", content);
        
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BuyTicketReadModel>(responseString);

        Assert.NotNull(result);
        Assert.Equal(4850, result.TotalInCent);
    }
    
    [Fact]
    public async Task BuyTicketWithQuantity10()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TicketId = 5,
            quantity = 10,
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/tickets/BuyTicket", content);
        
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BuyTicketReadModel>(responseString);

        Assert.NotNull(result);
        Assert.Equal(22050, result.TotalInCent);
    }
}