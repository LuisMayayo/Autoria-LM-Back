using System.Collections.Generic;

/// <summary>
/// Define la interfaz del servicio para gestionar Balon,
/// encapsulando la lógica de negocio.
/// </summary>
public interface IBalonService
{
    /// <summary>
    /// Obtiene todos los balones de autoría.
    /// </summary>
    /// <returns>Una colección de balones.</returns>
    IEnumerable<Balon> ObtenerTodos();

    /// <summary>
    /// Obtiene un balon por su identificador.
    /// </summary>
    /// <param name="id">Identificador del balon.</param>
    /// <returns>El balon encontrado o null si no existe.</returns>
    Balon ObtenerPorId(int id);

    /// <summary>
    /// Crea un nuevo balon de autoría.
    /// </summary>
    /// <param name="balon">El balon a crear.</param>
    void Crear(Balon balon);

    /// <summary>
    /// Actualiza un balon existente.
    /// </summary>
    /// <param name="balon">El balon con los datos actualizados.</param>
    void Actualizar(Balon balon);

    /// <summary>
    /// Elimina un balon por su identificador.
    /// </summary>
    /// <param name="id">Identificador del balon a eliminar.</param>
    void Eliminar(int id);
}
