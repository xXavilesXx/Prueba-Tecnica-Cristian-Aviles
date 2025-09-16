using System.Data;
using BackEnd.Models;
using Dapper;

namespace BackEnd.Data;

public class UsuarioXMontoRepository
{
    private readonly IDbConnection _dbConnection;

    public UsuarioXMontoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<bool> Insert(USUARIOSXMONTOS UsuariosXMonto)
    {
        string sql = @"MERGE INTO USUARIOSXMONTO AS destino
                    USING (VALUES (@USUARIO, @MONTO)) AS origen (USUARIO, MONTO)
                        ON UPPER(TRIM(destino.USUARIO)) = UPPER(TRIM(origen.USUARIO))
                    WHEN MATCHED THEN
                        UPDATE SET destino.Monto = destino.Monto+origen.Monto
                    WHEN NOT MATCHED THEN
                        INSERT (USUARIO, MONTO)
                        VALUES (origen.USUARIO, origen.MONTO);";
        var rowsAffected = await _dbConnection.ExecuteAsync(sql, UsuariosXMonto);
        return rowsAffected > 0;
    }
}