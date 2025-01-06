using System.Net.Security;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Blazored.LocalStorage;

namespace CursosFront.Servicios
{
        public class CustomAuthStateProvider : AuthenticationStateProvider
        {
            private readonly ILocalStorageService _localStorage;

            public CustomAuthStateProvider(ILocalStorageService localStorage)
            {
                _localStorage = localStorage;
            }

            public override async Task<AuthenticationState> GetAuthenticationStateAsync()
            {
                var token = await _localStorage.GetItemAsync<string>("authToken");

                if (string.IsNullOrEmpty(token))
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                var role = await _localStorage.GetItemAsync<string>("userRole");
                var identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, "Usuario"),
                new Claim(ClaimTypes.Role, role)
            }, "jwt");

                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
        }
    }
