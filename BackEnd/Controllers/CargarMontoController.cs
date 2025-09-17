using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Controllers;
[Route("api/CargarSaldo")]
public class CargarMontoController : Controller
{
    private readonly CargarMontoService _cargarMontoService;
    public CargarMontoController(CargarMontoService cargarMontoService)
    {
        _cargarMontoService = cargarMontoService;
    }
    [HttpPost("Obtener")]
    public async Task<IActionResult> Obtener([FromBody] UsuarioDto usuarioDto)
    {
        var Respuesta = await _cargarMontoService.Obtener(usuarioDto);
        return Ok(Respuesta);
    }
}