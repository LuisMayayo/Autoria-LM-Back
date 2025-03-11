/// <summary>
/// Representa un prueba con autoría, incluyendo identificador, título, autor, precio y número de serie.
/// </summary>
public class PruebaAutoria
{
    /// <summary>
    /// Identificador único del prueba.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Título o nombre del prueba.
    /// </summary>
    public string Titulo { get; set; }

    /// <summary>
    /// Nombre del autor o creador del prueba.
    /// </summary>
    public string Autor { get; set; }

    /// <summary>
    /// Precio del prueba.
    /// </summary>
    public decimal Precio { get; set; }

    /// <summary>
    /// Número de serie del prueba.
    /// </summary>
    public string NumeroSerie { get; set; }
}
