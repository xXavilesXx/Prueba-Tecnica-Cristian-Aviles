using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[Route("api/UsuarioXMonto")]
public class UsuarioXMontoController : Controller
{
    private readonly UsuarioXMontoService _UsuarioXMontoService;
    public UsuarioXMontoController(UsuarioXMontoService usuarioXMontoService)
    {
        _UsuarioXMontoService = usuarioXMontoService;
    }
    [HttpPost("Insertar")]
    public async Task<IActionResult> Insertar([FromBody] USUARIOSXMONTOS usuariXMonto)
    {
        var Bandera = await _UsuarioXMontoService.Insertar(usuariXMonto);
        return Ok(Bandera);
    }
}
