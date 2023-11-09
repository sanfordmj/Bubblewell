using Microsoft.AspNetCore.Authentication;

namespace WebApi.Helpers
{
    /// <summary>
    /// Composable AuthenticationManager
    /// </summary>
    public interface IAuthenticationManager
    {
        Task<AuthenticateResult> AuthenticateAsync();
        AuthenticateResult Authenticate();
    }
}
