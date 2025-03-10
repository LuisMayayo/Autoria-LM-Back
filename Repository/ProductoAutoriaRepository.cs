using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implementación del repositorio de ProductoAutoria usando una lista en memoria,
/// con productos pre-cargados para tener ejemplos.
/// </summary>
public class ProductoAutoriaRepository : IProductoAutoriaRepository
{
    /// <summary>
    /// Lista en memoria que simula la base de datos.
    /// </summary>
    private readonly List<ProductoAutoria> _productos = new List<ProductoAutoria>();

    /// <summary>
    /// Contador para asignar identificadores únicos a los productos.
    /// </summary>
    private int _nextId = 1;

    /// <summary>
    /// Constructor: se agregan algunos productos de ejemplo.
    /// </summary>
    public ProductoAutoriaRepository()
    {
        // Se agregan productos de ejemplo con los nuevos campos

        _productos.Add(new ProductoAutoria 
        { 
            Id = _nextId++, 
            Titulo = "La sombra del viento", 
            Autor = "Carlos Ruiz Zafón",
            Precio = 15.99m,
            NumeroSerie = "SZ-001"
        });
        
        _productos.Add(new ProductoAutoria 
        { 
            Id = _nextId++, 
            Titulo = "Cien años de soledad", 
            Autor = "Gabriel García Márquez",
            Precio = 20.50m,
            NumeroSerie = "CY-002"
        });
        
        _productos.Add(new ProductoAutoria 
        { 
            Id = _nextId++, 
            Titulo = "El nombre de la rosa", 
            Autor = "Umberto Eco",
            Precio = 18.75m,
            NumeroSerie = "NR-003"
        });
    }

    /// <inheritdoc/>
    public IEnumerable<ProductoAutoria> GetAll() => _productos;

    /// <inheritdoc/>
    public ProductoAutoria GetById(int id) =>
        _productos.FirstOrDefault(p => p.Id == id);

    /// <inheritdoc/>
    public void Add(ProductoAutoria producto)
    {
        // Se asigna un identificador único al producto y se añade a la lista.
        producto.Id = _nextId++;
        _productos.Add(producto);
    }

    /// <inheritdoc/>
    public void Update(ProductoAutoria producto)
    {
        // Busca el índice del producto a actualizar.
        var index = _productos.FindIndex(p => p.Id == producto.Id);
        if (index != -1)
        {
            _productos[index] = producto;
        }
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        var producto = GetById(id);
        if (producto != null)
        {
            _productos.Remove(producto);
        }
    }
}
