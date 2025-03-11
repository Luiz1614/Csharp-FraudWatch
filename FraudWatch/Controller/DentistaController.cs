using FraudWatch.Application.DTOs;
using FraudWatch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Get()
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
    public IActionResult Get(int id)
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
    public IActionResult Get(string cro)
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
    public IActionResult Post([FromBody] DentistaDTO dentistaDTO)
    {
        try
        {
            _dentistaApplicationService.Add(dentistaDTO);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DentistaDTO dentistaDTO)
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
    public IActionResult Delete(int id)
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


