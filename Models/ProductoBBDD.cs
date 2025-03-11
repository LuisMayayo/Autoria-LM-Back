/// <summary>
/// Representa un producto almacenado en la base de datos MSSQL, 
/// incluyendo identificador, título, autor, precio y número de serie.
/// </summary>
public class ProductoBBDD
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public decimal Precio { get; set; }
    public string NumeroSerie { get; set; }
}
