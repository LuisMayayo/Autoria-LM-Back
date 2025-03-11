using System.Collections.Generic;

/// <summary>
/// Define los métodos CRUD para gestionar productos en la base de datos MSSQL.
/// </summary>
public interface IProductoBBDDRepository
{
    /// <summary>
    /// Obtiene todos los productos.
    /// </summary>
    IEnumerable<ProductoBBDD> GetAll();

    /// <summary>
    /// Obtiene un producto por su identificador.
    /// </summary>
    ProductoBBDD GetById(int id);

    /// <summary>
    /// Agrega un nuevo producto.
    /// </summary>
    void Add(ProductoBBDD producto);

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    void Update(ProductoBBDD producto);

    /// <summary>
    /// Elimina un producto por su identificador.
    /// </summary>
    void Delete(int id);
}
