using System.Net.Http.Json;
using Blazored.LocalStorage;
namespace CursosFront.Servicios
{
        public class AuthService
        {
            private readonly HttpClient _httpClient;
            private readonly ILocalStorageService _localStorage;

            public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
            {
                _httpClient = httpClient;
                _localStorage = localStorage;
            }

            public async Task<bool> Login(string username, string password)
            {
                var Logeo = new { UserID = username, Password = password };
                var response = await _httpClient.PostAsJsonAsync("Usuarios/login", Logeo);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    if (result != null)
                    {
                        // Guardar el token en el localStorage
                        await _localStorage.SetItemAsync("authToken", result.Token);
                        await _localStorage.SetItemAsync("userRole", result.Rol);
                        return true;
                    }
                }

                return false;
            }

            public async Task Logout()
            {
                await _localStorage.RemoveItemAsync("authToken");
                await _localStorage.RemoveItemAsync("userRole");
            }
        }

        public class LoginResponse
        {
            public string Token { get; set; }
            public string Rol { get; set; }
        }
}


