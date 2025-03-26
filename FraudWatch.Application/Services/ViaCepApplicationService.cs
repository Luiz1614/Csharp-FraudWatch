using FraudWatch.Application.Services.Interfaces;
using FraudWatch.Domain.Entities;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

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

    public string ValidateCep(string cep)
    {
        if (string.IsNullOrWhiteSpace(cep))
        {
            return "CEP não pode ser vazio.";
        }

        var regex = new Regex(@"^\d{5}-?\d{3}$");

        if (!regex.IsMatch(cep))
        {
            return "CEP inválido. O formato deve ser '12345-678' ou '12345678'.";
        }

        return string.Empty;
    }



}
