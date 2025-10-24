using keycloak_sample.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly KeycloakTokenService _tokenService;

    public TokenController(KeycloakTokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetToken()
    {
        var token = await _tokenService.GetAccessTokenAsync();
        return token is not null ? Ok(token) : StatusCode(500, "?error");
    }
}
