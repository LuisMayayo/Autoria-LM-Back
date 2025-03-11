using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implementación del repositorio de cocheAutoria usando una lista en memoria,
/// con coches pre-cargados para tener ejemplos.
/// </summary>
public class CocheAutoriaRepository : ICocheAutoriaRepository
{
    /// <summary>
    /// Lista en memoria que simula la base de datos.
    /// </summary>
    private readonly List<CocheAutoria> _coches = new List<CocheAutoria>();

    /// <summary>
    /// Contador para asignar identificadores únicos a los coches.
    /// </summary>
    private int _nextId = 1;

    /// <summary>
    /// Constructor: se agregan algunos coches de ejemplo.
    /// </summary>
    public CocheAutoriaRepository()
    {
        // Se agregan coches de ejemplo con los nuevos campos

        _coches.Add(new CocheAutoria 
        { 
            Id = _nextId++, 
            Nombre = "11 sombra del viento", 
            Marca = "1Carlos Ruiz Zafón",
            Precio = 115.99m,
            Descripción = "1SZ-001"
        });
        
        _coches.Add(new CocheAutoria 
        { 
            Id = _nextId++, 
            Nombre = "22 sombra del viento", 
            Marca = "2Carlos Ruiz Zafón",
            Precio = 125.99m,
            Descripción = "2SZ-001"
        });
        
        _coches.Add(new CocheAutoria 
        { 
            Id = _nextId++, 
            Nombre = "33 sombra del viento", 
            Marca = "3Carlos Ruiz Zafón",
            Precio = 135.99m,
            Descripción = "3SZ-001"
        });
    }

    /// <inheritdoc/>
    public IEnumerable<CocheAutoria> GetAll() => _coches;

    /// <inheritdoc/>
    public CocheAutoria GetById(int id) =>
        _coches.FirstOrDefault(p => p.Id == id);

    /// <inheritdoc/>
    public void Add(CocheAutoria coche)
    {
        // Se asigna un identificador único al coche y se añade a la lista.
        coche.Id = _nextId++;
        _coches.Add(coche);
    }

    /// <inheritdoc/>
    public void Update(CocheAutoria coche)
    {
        // Busca el índice del coche a actualizar.
        var index = _coches.FindIndex(p => p.Id == coche.Id);
        if (index != -1)
        {
            _coches[index] = coche;
        }
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        var coche = GetById(id);
        if (coche != null)
        {
            _coches.Remove(coche);
        }
    }
}
