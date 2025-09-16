using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Dtos;
namespace BackEnd.Controllers;

[Route("api/ProcesaAzar")]
public class ProcesarAzarController : Controller
{

    private readonly ProcesarAzar _procesarAzar;
    public ProcesarAzarController(ProcesarAzar procesarAzar)
    {
        _procesarAzar = procesarAzar;
    }
    [HttpGet("ObtenerAzar")]
    public ActionResult ObtnerAzar()
    {
        AzarDto azarDto = _procesarAzar.DarAzar();
        return Ok(azarDto);
    }
}

