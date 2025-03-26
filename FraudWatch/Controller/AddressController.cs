using FraudWatch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace FraudWatch.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IViaCepApplicationService _viaCepApplicationService;

    public AddressController(IViaCepApplicationService viaCepApplicationService)
    {
        _viaCepApplicationService = viaCepApplicationService;
    }

    [HttpGet("{cep}")]
    [SwaggerOperation(Summary = "Retorna um endereço pelo CEP.")]
    [SwaggerResponse(200, "Endereço obtido com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public async Task<IActionResult> GetAddressByCep(string cep)
    {
        try
        {
            var address = await _viaCepApplicationService.GetAddressByCep(cep);
            return StatusCode((int)HttpStatusCode.OK, address);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
