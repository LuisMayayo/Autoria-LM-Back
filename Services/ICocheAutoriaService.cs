using System.Collections.Generic;

/// <summary>
/// Define la interfaz del servicio para gestionar cocheAutoria,
/// encapsulando la lógica de negocio.
/// </summary>
public interface ICocheAutoriaService
{
    /// <summary>
    /// Obtiene todos los coches de autoría.
    /// </summary>
    /// <returns>Una colección de coches.</returns>
    IEnumerable<CocheAutoria> ObtenerTodos();

    /// <summary>
    /// Obtiene un coche por su identificador.
    /// </summary>
    /// <param name="id">Identificador del coche.</param>
    /// <returns>El coche encontrado o null si no existe.</returns>
    CocheAutoria ObtenerPorId(int id);

    /// <summary>
    /// Crea un nuevo coche de autoría.
    /// </summary>
    /// <param name="coche">El coche a crear.</param>
    void Crear(CocheAutoria coche);

    /// <summary>
    /// Actualiza un coche existente.
    /// </summary>
    /// <param name="coche">El coche con los datos actualizados.</param>
    void Actualizar(CocheAutoria coche);

    /// <summary>
    /// Elimina un coche por su identificador.
    /// </summary>
    /// <param name="id">Identificador del coche a eliminar.</param>
    void Eliminar(int id);
}
