using BackEnd.Dtos;
namespace BackEnd.Services;

public class ProcesarAzar
{
    public AzarDto DarAzar()
    {
        AzarDto azarDto = new AzarDto();
        azarDto.NumeroAzar = DarNumeroAleatorio();
        azarDto.ColorAzar = DarColorAleatorio();
        return azarDto;
    }
    public byte DarNumeroAleatorio()
    {
        var rnd = new Random();
        int valor = rnd.Next(0, 37);
        return (byte)valor;
    }
    public string DarColorAleatorio() {
        var rnd = new Random();
        return rnd.Next(0,2)==1 ? "rojo" : "Negro";
    }
}
