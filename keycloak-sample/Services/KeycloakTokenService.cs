namespace keycloak_sample.Services;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class KeycloakTokenService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public KeycloakTokenService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        var keycloakUrl = _config["Keycloak:Url"];
        var realm = _config["Keycloak:Realm"];
        var clientId = _config["Keycloak:ClientId"];
        var clientSecret = _config["Keycloak:ClientSecret"];
        var tokenUrl = $"{keycloakUrl}/realms/{realm}/protocol/openid-connect/token";

        var formData = new Dictionary<string, string>
        {
            { "client_id", clientId },
            { "client_secret", clientSecret },
            { "grant_type", "client_credentials" },
               { "audience", clientId} // ← نام کلاینت مقصد (همانی که می‌خواهید aud باشد)
        };

        var content = new FormUrlEncodedContent(formData);

        var response = await _httpClient.PostAsync(tokenUrl, content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"❌ Token request failed: {error}");
            return null;
        }

        var json = await response.Content.ReadAsStringAsync();
        var token = JsonDocument.Parse(json).RootElement.GetProperty("access_token").GetString();

        return token;
    }
}

