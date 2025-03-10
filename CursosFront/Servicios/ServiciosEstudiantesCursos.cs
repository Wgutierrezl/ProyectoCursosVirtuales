
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CursosFront.Servicios
{
    public class ServiciosEstudiantesCursos : IServiciosEstudiantesCursos
    {
        private readonly HttpClient _httpClient;

        public ServiciosEstudiantesCursos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private JsonSerializerOptions _serialicer = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public async Task<HttpResponseWrapper<object>> DeleteEstudiantesCursos(string url)
        {
            var responsehttp = await _httpClient.DeleteAsync(url);
            var content = await responsehttp.Content.ReadAsStringAsync();
            return new HttpResponseWrapper<object>(content, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> DeleteEstudiantesCursos<TActionResponse>(string url)
        {
            var responsehttp = await _httpClient.DeleteAsync(url);
            var content = await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<TActionResponse>(content, _serialicer);
                return new HttpResponseWrapper<TActionResponse>(response, !responsehttp.IsSuccessStatusCode, responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<T>> GetEstudiantesCursos<T>(string url)
        {
            var responsehttp = await _httpClient.GetAsync(url);
            var content = await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<T>(content, _serialicer);
                return new HttpResponseWrapper<T>(response, !responsehttp.IsSuccessStatusCode, responsehttp);
            }
            return new HttpResponseWrapper<T>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<object>> PostEstudiantesCursos<T>(string url, T model)
        {
            var MessageBody = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(url, Encoding.UTF8, "application/json");
            var responsehttp = await _httpClient.PostAsync(url, MessageContent);
            var content = await responsehttp.Content.ReadAsStringAsync();
            return new HttpResponseWrapper<object>(content, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostEstudiantesCursos<T, TActionResponse>(string url, T model)
        {
            var MessageBody = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(url, Encoding.UTF8, "application/json");
            var responsehttp = await _httpClient.PostAsync(url, MessageContent);
            var content = await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<TActionResponse>(content, _serialicer);
                return new HttpResponseWrapper<TActionResponse>(response, !responsehttp.IsSuccessStatusCode, responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<object>> PutEstudiantesCursos<T>(string url, T model)
        {
            var MessageBody = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(url, Encoding.UTF8, "application/json");
            var responsehttp = await _httpClient.PutAsync(url, MessageContent);
            var content = await responsehttp.Content.ReadAsStringAsync();
            return new HttpResponseWrapper<object>(content, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PutEstudiantesCursos<T, TActionResponse>(string url, T model)
        {
            var MessageBody = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(url, Encoding.UTF8, "application/json");
            var responsehttp = await _httpClient.PutAsync(url, MessageContent);
            var content = await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<TActionResponse>(content, _serialicer);
                return new HttpResponseWrapper<TActionResponse>(response, responsehttp.IsSuccessStatusCode, responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
        }
    }
}
