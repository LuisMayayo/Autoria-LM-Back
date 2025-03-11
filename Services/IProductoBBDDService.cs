using System.Collections.Generic;

/// <summary>
/// Define los métodos para gestionar la lógica de negocio de ProductoBBDD.
/// </summary>
public interface IProductoBBDDService
{
    IEnumerable<ProductoBBDD> ObtenerTodos();
    ProductoBBDD ObtenerPorId(int id);
    void Crear(ProductoBBDD producto);
    void Actualizar(ProductoBBDD producto);
    void Eliminar(int id);
}
