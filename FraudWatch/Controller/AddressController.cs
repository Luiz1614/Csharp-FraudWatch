using FraudWatch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> GetAddressByCep(string cep)
    {
        try
        {
            var address = await _viaCepApplicationService.GetAddressByCep(cep);
            return Ok(address);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
