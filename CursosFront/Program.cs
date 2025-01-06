using CursosFront;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CursosFront.Servicios;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using CursosFront.Servicios.CursosFront.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Agregar componentes raíz
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Configurar un único HttpClient con autorización JWT
builder.Services.AddScoped(async sp =>
{
    var localStorage = sp.GetRequiredService<ILocalStorageService>();
    var authToken = await localStorage.GetItemAsync<string>("authToken");
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7244/")
    };

    if (!string.IsNullOrEmpty(authToken))
    {
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", authToken);
    }

    return httpClient;
});

// Registrar servicios de la aplicación
builder.Services.AddScoped<IServiciosUsuario, ServiciosUsuario>();
builder.Services.AddScoped<IServiciosCursos, ServiciosCursos>();
builder.Services.AddScoped<IServiciosEstudiantesCursos, ServiciosEstudiantesCursos>();
builder.Services.AddScoped<IServiciosEvaluaciones, ServiciosEvaluaciones>();
builder.Services.AddScoped<IServiciosPreguntasEvaluacion, ServiciosPreguntasEvaluacion>();
builder.Services.AddScoped<IServiciosRespuestas, ServiciosRespuestas>();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();