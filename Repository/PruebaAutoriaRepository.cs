using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implementación del repositorio de PruebaAutoria usando una lista en memoria,
/// con pruebas pre-cargados para tener ejemplos.
/// </summary>
public class PruebaAutoriaRepository : IPruebaAutoriaRepository
{
    /// <summary>
    /// Lista en memoria que simula la base de datos.
    /// </summary>
    private readonly List<PruebaAutoria> _pruebas = new List<PruebaAutoria>();

    /// <summary>
    /// Contador para asignar identificadores únicos a los pruebas.
    /// </summary>
    private int _nextId = 1;

    /// <summary>
    /// Constructor: se agregan algunos pruebas de ejemplo.
    /// </summary>
    public PruebaAutoriaRepository()
    {
        // Se agregan pruebas de ejemplo con los nuevos campos

        _pruebas.Add(new PruebaAutoria 
        { 
            Id = _nextId++, 
            Titulo = "La sombra del viento", 
            Autor = "Carlos Ruiz Zafón",
            Precio = 15.99m,
            NumeroSerie = "SZ-001"
        });
        
        _pruebas.Add(new PruebaAutoria 
        { 
            Id = _nextId++, 
            Titulo = "Cien años de soledad", 
            Autor = "Gabriel García Márquez",
            Precio = 20.50m,
            NumeroSerie = "CY-002"
        });
        
        _pruebas.Add(new PruebaAutoria 
        { 
            Id = _nextId++, 
            Titulo = "El nombre de la rosa", 
            Autor = "Umberto Eco",
            Precio = 18.75m,
            NumeroSerie = "NR-003"
        });
    }

    /// <inheritdoc/>
    public IEnumerable<PruebaAutoria> GetAll() => _pruebas;

    /// <inheritdoc/>
    public PruebaAutoria GetById(int id) =>
        _pruebas.FirstOrDefault(p => p.Id == id);

    /// <inheritdoc/>
    public void Add(PruebaAutoria prueba)
    {
        // Se asigna un identificador único al prueba y se añade a la lista.
        prueba.Id = _nextId++;
        _pruebas.Add(prueba);
    }

    /// <inheritdoc/>
    public void Update(PruebaAutoria prueba)
    {
        // Busca el índice del prueba a actualizar.
        var index = _pruebas.FindIndex(p => p.Id == prueba.Id);
        if (index != -1)
        {
            _pruebas[index] = prueba;
        }
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        var prueba = GetById(id);
        if (prueba != null)
        {
            _pruebas.Remove(prueba);
        }
    }
}
