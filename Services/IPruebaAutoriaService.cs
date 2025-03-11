using System.Collections.Generic;

/// <summary>
/// Define la interfaz del servicio para gestionar PruebaAutoria,
/// encapsulando la lógica de negocio.
/// </summary>
public interface IPruebaAutoriaService
{
    /// <summary>
    /// Obtiene todos los pruebas de autoría.
    /// </summary>
    /// <returns>Una colección de pruebas.</returns>
    IEnumerable<PruebaAutoria> ObtenerTodos();

    /// <summary>
    /// Obtiene un prueba por su identificador.
    /// </summary>
    /// <param name="id">Identificador del prueba.</param>
    /// <returns>El prueba encontrado o null si no existe.</returns>
    PruebaAutoria ObtenerPorId(int id);

    /// <summary>
    /// Crea un nuevo prueba de autoría.
    /// </summary>
    /// <param name="prueba">El prueba a crear.</param>
    void Crear(PruebaAutoria prueba);

    /// <summary>
    /// Actualiza un prueba existente.
    /// </summary>
    /// <param name="prueba">El prueba con los datos actualizados.</param>
    void Actualizar(PruebaAutoria prueba);

    /// <summary>
    /// Elimina un prueba por su identificador.
    /// </summary>
    /// <param name="id">Identificador del prueba a eliminar.</param>
    void Eliminar(int id);
}
