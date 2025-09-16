namespace BackEnd.Dtos;


public class GirarRuletaDto
{
    public required string Nombre { get; set; }
    public required  string TipoJuego { get; set; }
    public string Color { get; set; }
    public string ParImpar { get; set; }
    public byte? Numero { get; set; }
    public required decimal Saldo { get; set; }
}