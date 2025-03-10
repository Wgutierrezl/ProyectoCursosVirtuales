using CursosFront;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CursosFront.Servicios;
using System.Net.Http.Headers;
using CursosFront.Servicios;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using CursosFront.Extensiones;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Agregar componentes raíz
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar Blazored.LocalStorage
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7244/") });

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider,AutenticacioExtension>();
builder.Services.AddAuthorizationCore();
// Registrar servicios de la aplicación
builder.Services.AddScoped<IServiciosUsuario, ServiciosUsuario>();
builder.Services.AddScoped<IServiciosCursos, ServiciosCursos>();
builder.Services.AddScoped<IServiciosEstudiantesCursos, ServiciosEstudiantesCursos>();
builder.Services.AddScoped<IServiciosEvaluaciones, ServiciosEvaluaciones>();
builder.Services.AddScoped<IServiciosPreguntasEvaluacion, ServiciosPreguntasEvaluacion>();
builder.Services.AddScoped<IServiciosRespuestas, ServiciosRespuestas>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();