/// <summary>
/// Implementa la lógica de negocio para CocheBBDD utilizando el repositorio.
/// </summary>
public class CocheBBDDService : ICocheBBDDService
{
    private readonly ICocheBBDDRepository _repository;

    /// <summary>
    /// Inyecta el repositorio en el servicio.
    /// </summary>
    public CocheBBDDService(ICocheBBDDRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<CocheBBDD> ObtenerTodos()
    {
        return _repository.GetAll();
    }

    public CocheBBDD ObtenerPorId(int id)
    {
        return _repository.GetById(id);
    }

    public void Crear(CocheBBDD coche)
    {
        _repository.Add(coche);
    }

    public void Actualizar(CocheBBDD coche)
    {
        _repository.Update(coche);
    }

    public void Eliminar(int id)
    {
        _repository.Delete(id);
    }
}
