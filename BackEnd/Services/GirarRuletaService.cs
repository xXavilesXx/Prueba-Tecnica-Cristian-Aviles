namespace BackEnd.Services;

using BackEnd.Dtos;
public class GirarRuletaService
{
    private readonly ProcesarAzar _ProcesarAzar;

    public GirarRuletaService(ProcesarAzar procesarAzar)
    {
        _ProcesarAzar = procesarAzar;
    }
    public RespuestaDto Girar(GirarRuletaDto girarRuletaDto)
    {
        //Obtengo resultado del azar
        AzarDto azarDto = _ProcesarAzar.DarAzar();
        return ProcesarResultado(azarDto,girarRuletaDto);
    }
    public RespuestaDto ProcesarResultado(AzarDto azarDto, GirarRuletaDto girarRuletaDto)
    {
        RespuestaDto respuestaDto = new RespuestaDto
        {
            Nombre = girarRuletaDto.Nombre,
            Saldo = girarRuletaDto.Saldo
        };

        bool Gano = false;
        decimal Premio = 0M;
        switch (girarRuletaDto.TipoJuego)
        {
            case "color":
                if (string.Equals(girarRuletaDto.Color, azarDto.ColorAzar, StringComparison.OrdinalIgnoreCase))
                {
                    Gano = true;
                    Premio = girarRuletaDto.Saldo * 0.5m;
                }
                break;
            case "parimpar":
                bool esPar = azarDto.NumeroAzar % 2 == 0;
                if (girarRuletaDto.Color.ToUpper() == azarDto.ColorAzar.ToUpper() && ((girarRuletaDto.ParImpar.Equals("par", StringComparison.OrdinalIgnoreCase) && esPar) ||
                    (girarRuletaDto.ParImpar.Equals("impar", StringComparison.OrdinalIgnoreCase) && !esPar)))
                {
                    Gano = true;
                    Premio = girarRuletaDto.Saldo;
                }
                break;
            case "numero":
                if (girarRuletaDto.Numero == azarDto.NumeroAzar && string.Equals(girarRuletaDto.Color, azarDto.ColorAzar, StringComparison.OrdinalIgnoreCase))
                {
                    Gano = true;
                    Premio = girarRuletaDto.Saldo * 3;
                }
                break;

        }
        ;
        if (Gano)
        {
            respuestaDto.Saldo += Premio;
            respuestaDto.Gano = "Gano";
        }
        else
        {
            respuestaDto.Saldo = Premio;
            respuestaDto.Gano = "Perdio";
        }
        return respuestaDto;
    }
}