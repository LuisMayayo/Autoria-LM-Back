using System.Collections.Generic;

/// <summary>
/// Define la interfaz para el repositorio de PruebaAutoria, 
/// especificando las operaciones básicas de CRUD.
/// </summary>
public interface IPruebaAutoriaRepository
{
    /// <summary>
    /// Obtiene todos los pruebas de autoría.
    /// </summary>
    /// <returns>Una colección de pruebas.</returns>
    IEnumerable<PruebaAutoria> GetAll();

    /// <summary>
    /// Obtiene un prueba de autoría por su identificador.
    /// </summary>
    /// <param name="id">Identificador del prueba.</param>
    /// <returns>El prueba encontrado o null si no existe.</returns>
    PruebaAutoria GetById(int id);

    /// <summary>
    /// Agrega un nuevo prueba de autoría.
    /// </summary>
    /// <param name="prueba">El prueba a agregar.</param>
    void Add(PruebaAutoria prueba);

    /// <summary>
    /// Actualiza la información de un prueba existente.
    /// </summary>
    /// <param name="prueba">El prueba con los datos actualizados.</param>
    void Update(PruebaAutoria prueba);

    /// <summary>
    /// Elimina un prueba de autoría por su identificador.
    /// </summary>
    /// <param name="id">Identificador del prueba a eliminar.</param>
    void Delete(int id);
}
