using Microsoft.AspNetCore.Authentication;

namespace Web.Helpers
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
