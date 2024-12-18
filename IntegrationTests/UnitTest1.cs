using AlbumApi;
using Microsoft.AspNetCore.Mvc.Testing;

public class AlbumApiIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public AlbumApiIntegrationTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_Albums_ReturnsSuccessStatusCode()
    {
        // Arrange
        var request = "/api/albums";

        // Act
        var response = await _client.GetAsync(request);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
    }
}
