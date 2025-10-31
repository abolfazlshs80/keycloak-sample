using System.Text.Json.Serialization;

namespace keycloak_sample.Services.DTOs.Common;

public sealed class BadRequestErrorResponseDto
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = default!;
    
    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; } = default!;
}

public sealed class ErrorResponseDto
{
    [JsonPropertyName("error")]
    public string Field { get; set; } = default!;
    
    [JsonPropertyName("errorMessage")]
    public string ErrorMessage { get; set; } = default!;
}