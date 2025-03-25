using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using CursosControllador.Entidades;
using System.Security.Claims;
using System.ComponentModel.Design;

namespace CursosFront.Extensiones
{
    public class AutenticacioExtension : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsPrincipal _sininformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacioExtension(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;     
        }

        public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;
            if(sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim("UsuarioID",sesionUsuario.UserID),
                    new Claim(ClaimTypes.Name,sesionUsuario.Nombre),
                    new Claim(ClaimTypes.Email,sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role,sesionUsuario.Rol),
                    new Claim("Token",sesionUsuario.Token)
                }, "JwtAuth"));
                await _sessionStorageService.GuardarStorage("sesionUsuario", sesionUsuario);
            }
            else
            {
                claimsPrincipal = _sininformacion;
                await _sessionStorageService.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
            
        }
        

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario=await _sessionStorageService.ObtenerStorage<SesionDTO>("sesionUsuario");
            if(sesionUsuario== null)
               return await Task.FromResult(new AuthenticationState(_sininformacion));

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim("UsuarioID",sesionUsuario.UserID!),
                    new Claim(ClaimTypes.Name,sesionUsuario.Nombre!),
                    new Claim(ClaimTypes.Email,sesionUsuario.Correo!),
                    new Claim(ClaimTypes.Role,sesionUsuario.Rol!),
                    new Claim("Token",sesionUsuario.Token!)
                }, "JwtAuth"));
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));

        }
    }
}
