using System.Collections.Generic;

/// <summary>
/// Define la interfaz para el repositorio de cocheAutoria, 
/// especificando las operaciones básicas de CRUD.
/// </summary>
public interface ICocheAutoriaRepository
{
    /// <summary>
    /// Obtiene todos los coches de autoría.
    /// </summary>
    /// <returns>Una colección de coches.</returns>
    IEnumerable<CocheAutoria> GetAll();

    /// <summary>
    /// Obtiene un coche de autoría por su identificador.
    /// </summary>
    /// <param name="id">Identificador del coche.</param>
    /// <returns>El coche encontrado o null si no existe.</returns>
    CocheAutoria GetById(int id);

    /// <summary>
    /// Agrega un nuevo coche de autoría.
    /// </summary>
    /// <param name="coche">El coche a agregar.</param>
    void Add(CocheAutoria coche);

    /// <summary>
    /// Actualiza la información de un coche existente.
    /// </summary>
    /// <param name="coche">El coche con los datos actualizados.</param>
    void Update(CocheAutoria coche);

    /// <summary>
    /// Elimina un coche de autoría por su identificador.
    /// </summary>
    /// <param name="id">Identificador del coche a eliminar.</param>
    void Delete(int id);
}
