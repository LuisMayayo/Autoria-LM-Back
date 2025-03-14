using System.Collections.Generic;

/// <summary>
/// Define los métodos CRUD para gestionar coches en la base de datos MSSQL.
/// </summary>
public interface ICocheBBDDRepository
{
    /// <summary>
    /// Obtiene todos los coches.
    /// </summary>
    IEnumerable<CocheBBDD> GetAll();

    /// <summary>
    /// Obtiene un coche por su identificador.
    /// </summary>
    CocheBBDD GetById(int id);

    /// <summary>
    /// Agrega un nuevo coche.
    /// </summary>
    void Add(CocheBBDD coche);

    /// <summary>
    /// Actualiza un coche existente.
    /// </summary>
    void Update(CocheBBDD coche);

    /// <summary>
    /// Elimina un coche por su identificador.
    /// </summary>
    void Delete(int id);
}
