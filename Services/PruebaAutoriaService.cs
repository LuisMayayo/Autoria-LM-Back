/// <summary>
/// Implementación del servicio que encapsula la lógica de negocio para PruebaAutoria.
/// </summary>
public class PruebaAutoriaService : IPruebaAutoriaService
{
    /// <summary>
    /// Repositorio utilizado para acceder a los datos.
    /// </summary>
    private readonly IPruebaAutoriaRepository _repository;
    
    /// <summary>
    /// Constructor que inyecta el repositorio.
    /// </summary>
    /// <param name="repository">Repositorio de PruebaAutoria.</param>
    public PruebaAutoriaService(IPruebaAutoriaRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc/>
    public IEnumerable<PruebaAutoria> ObtenerTodos() => _repository.GetAll();

    /// <inheritdoc/>
    public PruebaAutoria ObtenerPorId(int id) => _repository.GetById(id);

    /// <inheritdoc/>
    public void Crear(PruebaAutoria prueba) => _repository.Add(prueba);

    /// <inheritdoc/>
    public void Actualizar(PruebaAutoria prueba) => _repository.Update(prueba);

    /// <inheritdoc/>
    public void Eliminar(int id) => _repository.Delete(id);
}
