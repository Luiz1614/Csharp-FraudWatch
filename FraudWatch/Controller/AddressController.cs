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
    [SwaggerResponse(404, "Endereço não encontrado.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public async Task<IActionResult> GetAddressByCep(string cep)
    {
        try
        {
            var validationMessage = _viaCepApplicationService.ValidateCep(cep);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                return BadRequest(validationMessage);
            }

            var address = await _viaCepApplicationService.GetAddressByCep(cep);
            if (address == null)
            {
                return NotFound("Endereço não encontrado para o CEP fornecido.");
            }

            return Ok(address);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
