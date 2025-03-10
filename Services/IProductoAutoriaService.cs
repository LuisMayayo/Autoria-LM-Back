using System.Collections.Generic;

/// <summary>
/// Define la interfaz del servicio para gestionar ProductoAutoria,
/// encapsulando la lógica de negocio.
/// </summary>
public interface IProductoAutoriaService
{
    /// <summary>
    /// Obtiene todos los productos de autoría.
    /// </summary>
    /// <returns>Una colección de productos.</returns>
    IEnumerable<ProductoAutoria> ObtenerTodos();

    /// <summary>
    /// Obtiene un producto por su identificador.
    /// </summary>
    /// <param name="id">Identificador del producto.</param>
    /// <returns>El producto encontrado o null si no existe.</returns>
    ProductoAutoria ObtenerPorId(int id);

    /// <summary>
    /// Crea un nuevo producto de autoría.
    /// </summary>
    /// <param name="producto">El producto a crear.</param>
    void Crear(ProductoAutoria producto);

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    /// <param name="producto">El producto con los datos actualizados.</param>
    void Actualizar(ProductoAutoria producto);

    /// <summary>
    /// Elimina un producto por su identificador.
    /// </summary>
    /// <param name="id">Identificador del producto a eliminar.</param>
    void Eliminar(int id);
}
