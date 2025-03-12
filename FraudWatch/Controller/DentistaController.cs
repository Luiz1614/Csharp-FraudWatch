using FraudWatch.Application.DTOs;
using FraudWatch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FraudWatch.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class DentistaController : ControllerBase
{
    private readonly IDentistaApplicationService _dentistaApplicationService;

    public DentistaController(IDentistaApplicationService dentistaApplicationService)
    {
        _dentistaApplicationService=dentistaApplicationService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retorna uma lista de todos os dentistas.")]
    [SwaggerResponse(200, "Dentistas obtidos com sucesso.")]
    [SwaggerResponse(204, "Nenhum dentista encontrado.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetAllDentistas()
    {
        try
        {
            var clientes = _dentistaApplicationService.GetAll();

            if (clientes == null)
                return NoContent();

            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retorna um dentista pelo ID.")]
    [SwaggerResponse(200, "Dentista obtido com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(404, "Dentista não encontrado.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetDentistaById(int id)
    {
        try
        {
            var cliente = _dentistaApplicationService.GetById(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("cro/{cro}")]
    [SwaggerOperation(Summary = "Retorna um dentista pelo CRO.")]
    [SwaggerResponse(200, "Dentista obtido com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(404, "Dentista não encontrado.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetDentistaByCro(string cro)
    {
        try
        {
            var cliente = _dentistaApplicationService.GetByCro(cro);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Adiciona um novo dentista.")]
    [SwaggerResponse(201, "Dentista adicionado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult PostDentista([FromBody] DentistaDTO dentistaDTO)
    {
        try
        {
            _dentistaApplicationService.Add(dentistaDTO);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualiza um dentista pelo ID.")]
    [SwaggerResponse(200, "Dentista atualizado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult PutDentista(int id, [FromBody] DentistaDTO dentistaDTO)
    {
        try
        {
            _dentistaApplicationService.Update(id, dentistaDTO);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deleta um dentista pelo ID.")]
    [SwaggerResponse(200, "Dentista deletado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult DeleteDentista(int id)
    {
        try
        {
            _dentistaApplicationService.DeleteById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}


