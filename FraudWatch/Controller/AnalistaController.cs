using FraudWatch.Application.DTOs;
using FraudWatch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FraudWatch.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class AnalistaController : ControllerBase
{
    private readonly IAnalistaApplicationService _analistaApplicationService;

    public AnalistaController(IAnalistaApplicationService analistaApplicationService)
    {
        _analistaApplicationService=analistaApplicationService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var clientes = _analistaApplicationService.GetAll();

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
    public IActionResult Get(int id)
    {
        try
        {
            var cliente = _analistaApplicationService.GetById(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("departamento/{departamento}")]
    public IActionResult Get(string departamento)
    {
        try
        {
            var cliente = _analistaApplicationService.GetByDepartamento(departamento);

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
    public IActionResult Post([FromBody] AnalistaDTO analistaDTO)
    {
        try
        {
            _analistaApplicationService.Add(analistaDTO);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AnalistaDTO analistaDTO)
    {
        try
        {
            _analistaApplicationService.Update(id, analistaDTO);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _analistaApplicationService.DeleteById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
