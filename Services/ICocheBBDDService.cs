using System.Collections.Generic;

/// <summary>
/// Define los métodos para gestionar la lógica de negocio de CocheBBDD.
/// </summary>
public interface ICocheBBDDService
{
    IEnumerable<CocheBBDD> ObtenerTodos();
    CocheBBDD ObtenerPorId(int id);
    void Crear(CocheBBDD coche);
    void Actualizar(CocheBBDD coche);
    void Eliminar(int id);
}
