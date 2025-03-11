/// <summary>
/// Implementa la lógica de negocio para ProductoBBDD utilizando el repositorio.
/// </summary>
public class ProductoBBDDService : IProductoBBDDService
{
    private readonly IProductoBBDDRepository _repository;

    /// <summary>
    /// Inyecta el repositorio en el servicio.
    /// </summary>
    public ProductoBBDDService(IProductoBBDDRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ProductoBBDD> ObtenerTodos()
    {
        return _repository.GetAll();
    }

    public ProductoBBDD ObtenerPorId(int id)
    {
        return _repository.GetById(id);
    }

    public void Crear(ProductoBBDD producto)
    {
        _repository.Add(producto);
    }

    public void Actualizar(ProductoBBDD producto)
    {
        _repository.Update(producto);
    }

    public void Eliminar(int id)
    {
        _repository.Delete(id);
    }
}
