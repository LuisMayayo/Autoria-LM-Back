using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implementación del repositorio de ProductoAutoria usando una lista en memoria.
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

    /// <inheritdoc/>
    public IEnumerable<ProductoAutoria> GetAll() => _productos;

    /// <inheritdoc/>
    public ProductoAutoria GetById(int id) =>
        _productos.FirstOrDefault(p => p.Id == id);

    /// <inheritdoc/>
    public void Add(ProductoAutoria producto)
    {
        // Asigna un identificador único al producto y lo añade a la lista.
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
            // Si se encuentra, actualiza el producto en la lista.
            _productos[index] = producto;
        }
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        // Obtiene el producto por su id.
        var producto = GetById(id);
        if (producto != null)
        {
            // Elimina el producto de la lista.
            _productos.Remove(producto);
        }
    }
}
