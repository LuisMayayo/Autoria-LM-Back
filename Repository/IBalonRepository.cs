using System.Collections.Generic;

/// <summary>
/// Define la interfaz para el repositorio de Balon, 
/// especificando las operaciones básicas de CRUD.
/// </summary>
public interface IBalonRepository
{
    /// <summary>
    /// Obtiene todos los balones de autoría.
    /// </summary>
    /// <returns>Una colección de balones.</returns>
    IEnumerable<Balon> GetAll();

    /// <summary>
    /// Obtiene un balon de autoría por su identificador.
    /// </summary>
    /// <param name="id">Identificador del balon.</param>
    /// <returns>El balon encontrado o null si no existe.</returns>
    Balon GetById(int id);

    /// <summary>
    /// Agrega un nuevo balon de autoría.
    /// </summary>
    /// <param name="balon">El balon a agregar.</param>
    void Add(Balon balon);

    /// <summary>
    /// Actualiza la información de un balon existente.
    /// </summary>
    /// <param name="balon">El balon con los datos actualizados.</param>
    void Update(Balon balon);

    /// <summary>
    /// Elimina un balon de autoría por su identificador.
    /// </summary>
    /// <param name="id">Identificador del balon a eliminar.</param>
    void Delete(int id);
}
