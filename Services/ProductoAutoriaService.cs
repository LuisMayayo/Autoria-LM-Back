/// <summary>
/// Implementación del servicio que encapsula la lógica de negocio para ProductoAutoria.
/// </summary>
public class ProductoAutoriaService : IProductoAutoriaService
{
    /// <summary>
    /// Repositorio utilizado para acceder a los datos.
    /// </summary>
    private readonly IProductoAutoriaRepository _repository;
    
    /// <summary>
    /// Constructor que inyecta el repositorio.
    /// </summary>
    /// <param name="repository">Repositorio de ProductoAutoria.</param>
    public ProductoAutoriaService(IProductoAutoriaRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc/>
    public IEnumerable<ProductoAutoria> ObtenerTodos() => _repository.GetAll();

    /// <inheritdoc/>
    public ProductoAutoria ObtenerPorId(int id) => _repository.GetById(id);

    /// <inheritdoc/>
    public void Crear(ProductoAutoria producto) => _repository.Add(producto);

    /// <inheritdoc/>
    public void Actualizar(ProductoAutoria producto) => _repository.Update(producto);

    /// <inheritdoc/>
    public void Eliminar(int id) => _repository.Delete(id);
}
