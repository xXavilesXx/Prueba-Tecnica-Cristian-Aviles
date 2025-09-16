using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Dtos;

namespace BackEnd.Controllers;

[Route("api/GirarRuleta")]
public class GirarRuletaController : Controller
{
    private readonly GirarRuletaService _girarRuletaService;
    public GirarRuletaController(GirarRuletaService girarRuletaService)
    {
        _girarRuletaService = girarRuletaService;
    }
    [HttpPost("Girar")]
    public IActionResult GirarRuleta([FromBody] GirarRuletaDto girarRuletaDto)
    {
        var Respuesta = _girarRuletaService.Girar(girarRuletaDto);
        return Ok(Respuesta);
    }
}