using BackEnd.Data;
using BackEnd.Models;
using BackEnd.Dtos;
namespace BackEnd.Services;

public class CargarMontoService
{
    private readonly CargarMontoRepository _repository;

    public CargarMontoService(CargarMontoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<USUARIOSXMONTOS?> Obtener(UsuarioDto usuarioDto)
    {
        var Datos = await _repository.GetSaldo(usuarioDto);
        return Datos;
    }
 }