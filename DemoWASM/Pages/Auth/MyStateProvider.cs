using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DemoWASM.Pages.Auth
{
    public class MyStateProvider(IJSRuntime JS) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            if (!string.IsNullOrEmpty(token))
            {
                JwtSecurityToken jwt = new JwtSecurityToken(token);
                ClaimsIdentity user = new ClaimsIdentity(jwt.Claims, "JwtClaim");

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
            }

            ClaimsIdentity anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }

        public void UserStateChange()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
