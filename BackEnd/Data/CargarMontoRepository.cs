using System.Data;
using BackEnd.Models;
using Dapper;
using BackEnd.Dtos;

using BackEnd.Services;
namespace BackEnd.Data;

public class CargarMontoRepository
{
    private readonly IDbConnection _dbConnection;

    private readonly IDbConnectionFactory _connectionFactory;

    public CargarMontoRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<USUARIOSXMONTOS?> GetSaldo(UsuarioDto usuarioDto)
    {

        string sql = @"SELECT USUARIO, MONTO
                             FROM USUARIOSXMONTO
                             WHERE UPPER(TRIM(USUARIO)) = UPPER(TRIM(@Usu))";

        using var conn = _connectionFactory.CreateConnection();
        var parametros = new DynamicParameters();
        parametros.Add("@Usu", usuarioDto.Usuario);

        return await conn.QueryFirstOrDefaultAsync<USUARIOSXMONTOS>(sql, parametros);

    }
}