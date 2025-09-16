namespace BackEnd.Services;

using BackEnd.Data;
using BackEnd.Models;

public class UsuarioXMontoService
{
    private readonly UsuarioXMontoRepository _repository;

    public UsuarioXMontoService(UsuarioXMontoRepository repository)
    {
        _repository = repository;
    }
    //
    public async Task<bool> Insertar(USUARIOSXMONTOS UsuarioXMontos)
    {
        return await _repository.Insert(UsuarioXMontos);
    }
}