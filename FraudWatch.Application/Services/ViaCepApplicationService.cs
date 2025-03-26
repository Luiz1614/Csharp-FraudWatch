using FraudWatch.Application.Services.Interfaces;
using FraudWatch.Domain.Entities;
using Newtonsoft.Json;

namespace FraudWatch.Application.Services;

public class ViaCepApplicationService : IViaCepApplicationService
{
    private readonly HttpClient _httpClient;

    public ViaCepApplicationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ViaCepResponseEntity?> GetAddressByCep(string cep)
    {
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(content))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<ViaCepResponseEntity>(content);
    }

}
