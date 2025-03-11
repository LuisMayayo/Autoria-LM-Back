/// <summary>
/// Implementación del servicio que encapsula la lógica de negocio para cocheAutoria.
/// </summary>
public class CocheAutoriaService : ICocheAutoriaService
{
    /// <summary>
    /// Repositorio utilizado para acceder a los datos.
    /// </summary>
    private readonly ICocheAutoriaRepository _repository;
    
    /// <summary>
    /// Constructor que inyecta el repositorio.
    /// </summary>
    /// <param name="repository">Repositorio de CocheAutoriaService.</param>
    public CocheAutoriaService(ICocheAutoriaRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc/>
    public IEnumerable<CocheAutoria> ObtenerTodos() => _repository.GetAll();

    /// <inheritdoc/>
    public CocheAutoria ObtenerPorId(int id) => _repository.GetById(id);

    /// <inheritdoc/>
    public void Crear(CocheAutoria coche) => _repository.Add(coche);

    /// <inheritdoc/>
    public void Actualizar(CocheAutoria coche) => _repository.Update(coche);

    /// <inheritdoc/>
    public void Eliminar(int id) => _repository.Delete(id);
}
