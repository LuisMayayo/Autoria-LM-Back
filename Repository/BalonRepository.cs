using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implementación del repositorio de Balon usando una lista en memoria,
/// con balones pre-cargados para tener ejemplos.
/// </summary>
public class BalonRepository : IBalonRepository
{
    /// <summary>
    /// Lista en memoria que simula la base de datos.
    /// </summary>
    private readonly List<Balon> _balones = new List<Balon>();

    /// <summary>
    /// Contador para asignar identificadores únicos a los balones.
    /// </summary>
    private int _nextId = 1;

    /// <summary>
    /// Constructor: se agregan algunos balones de ejemplo.
    /// </summary>
    public BalonRepository()
    {
        // Se agregan balones de ejemplo con los nuevos campos

        _balones.Add(new Balon 
        { 
            Id = _nextId++, 
            Nombre = "1La sombra del viento", 
            Marca = "1Carlos Ruiz Zafón",
            Precio = 115.99m,
            Descripción = "1SZ-001",
            Tamaño = "110.30cm"
        });
        
        _balones.Add(new Balon 
        { 
            Id = _nextId++, 
            Nombre = "2La sombra del viento", 
            Marca = "2Carlos Ruiz Zafón",
            Precio = 215.99m,
            Descripción = "2SZ-001",
            Tamaño = "210.30cm"
        });
        
        _balones.Add(new Balon 
        { 
            Id = _nextId++, 
            Nombre = "3La sombra del viento", 
            Marca = "3Carlos Ruiz Zafón",
            Precio = 315.99m,
            Descripción = "3SZ-001",
            Tamaño = "310.30cm"
        });
    }

    /// <inheritdoc/>
    public IEnumerable<Balon> GetAll() => _balones;

    /// <inheritdoc/>
    public Balon GetById(int id) =>
        _balones.FirstOrDefault(p => p.Id == id);

    /// <inheritdoc/>
    public void Add(Balon balon)
    {
        // Se asigna un identificador único al balon y se añade a la lista.
        balon.Id = _nextId++;
        _balones.Add(balon);
    }

    /// <inheritdoc/>
    public void Update(Balon balon)
    {
        // Busca el índice del balon a actualizar.
        var index = _balones.FindIndex(p => p.Id == balon.Id);
        if (index != -1)
        {
            _balones[index] = balon;
        }
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        var balon = GetById(id);
        if (balon != null)
        {
            _balones.Remove(balon);
        }
    }
}
