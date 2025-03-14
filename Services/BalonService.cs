/// <summary>
/// Implementación del servicio que encapsula la lógica de negocio para Balon.
/// </summary>
public class BalonService : IBalonService
{
    /// <summary>
    /// Repositorio utilizado para acceder a los datos.
    /// </summary>
    private readonly IBalonRepository _repository;
    
    /// <summary>
    /// Constructor que inyecta el repositorio.
    /// </summary>
    /// <param name="repository">Repositorio de BalonService.</param>
    public BalonService(IBalonRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc/>
    public IEnumerable<Balon> ObtenerTodos() => _repository.GetAll();

    /// <inheritdoc/>
    public Balon ObtenerPorId(int id) => _repository.GetById(id);

    /// <inheritdoc/>
    public void Crear(Balon balon) => _repository.Add(balon);

    /// <inheritdoc/>
    public void Actualizar(Balon balon) => _repository.Update(balon);

    /// <inheritdoc/>
    public void Eliminar(int id) => _repository.Delete(id);
}
