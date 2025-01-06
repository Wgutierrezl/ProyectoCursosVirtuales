
namespace CursosFront.Servicios
{
    public class ServiciosCursos : IServiciosCursos
    {
        public Task<HttpResponseWrapper<object>> DeleteCursos(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> DeleteCursos<TActionResponse>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<T>> GetCursos<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PostCursos<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PostCursos<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PutCursos<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PutCursos<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }
    }
}
