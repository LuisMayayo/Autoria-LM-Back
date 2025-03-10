using System.Collections.Generic;

/// <summary>
/// Define la interfaz para el repositorio de ProductoAutoria, 
/// especificando las operaciones básicas de CRUD.
/// </summary>
public interface IProductoAutoriaRepository
{
    /// <summary>
    /// Obtiene todos los productos de autoría.
    /// </summary>
    /// <returns>Una colección de productos.</returns>
    IEnumerable<ProductoAutoria> GetAll();

    /// <summary>
    /// Obtiene un producto de autoría por su identificador.
    /// </summary>
    /// <param name="id">Identificador del producto.</param>
    /// <returns>El producto encontrado o null si no existe.</returns>
    ProductoAutoria GetById(int id);

    /// <summary>
    /// Agrega un nuevo producto de autoría.
    /// </summary>
    /// <param name="producto">El producto a agregar.</param>
    void Add(ProductoAutoria producto);

    /// <summary>
    /// Actualiza la información de un producto existente.
    /// </summary>
    /// <param name="producto">El producto con los datos actualizados.</param>
    void Update(ProductoAutoria producto);

    /// <summary>
    /// Elimina un producto de autoría por su identificador.
    /// </summary>
    /// <param name="id">Identificador del producto a eliminar.</param>
    void Delete(int id);
}
