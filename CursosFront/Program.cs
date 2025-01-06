using CursosFront;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CursosFront.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7244/") });
builder.Services.AddScoped<IServiciosUsuario, ServiciosUsuario>();
builder.Services.AddScoped<IServiciosCursos, ServiciosCursos>();
builder.Services.AddScoped<IServiciosEstudiantesCursos, ServiciosEstudiantesCursos>();
builder.Services.AddScoped<IServiciosEvaluaciones, ServiciosEvaluaciones>();
builder.Services.AddScoped<IServiciosPreguntasEvaluacion, ServiciosPreguntasEvaluacion>();
builder.Services.AddScoped<IServiciosRespuestas, ServiciosRespuestas>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
