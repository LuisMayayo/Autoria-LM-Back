/// <summary>
/// Representa un producto con autoría, incluyendo identificador, título, autor, precio y número de serie.
/// </summary>
public class CocheBBDD
{
    /// <summary>
    /// Identificador único del producto.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Título o nombre del producto.
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Nombre del autor o creador del producto.
    /// </summary>
    public string Marca { get; set; }

    /// <summary>
    /// Precio del producto.
    /// </summary>
    public decimal Precio { get; set; }

    /// <summary>
    /// Número de serie del producto.
    /// </summary>
    public string DescripcionCoche { get; set; }
}
