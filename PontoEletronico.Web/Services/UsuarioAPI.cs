
using PontoEletronico.Web.Response;
using System.Net.Http.Json;

namespace PontoEletronico.Web.Services;

public class UsuarioAPI
{
    private readonly HttpClient _httpClient;

    public UsuarioAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    //public async Task AddUsuarioAsync(UsuarioResponse usuario)
    //{
    //    await _httpClient.PostAsJsonAsync();
    //}
}
