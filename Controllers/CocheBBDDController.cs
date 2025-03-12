using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/// <summary>
/// Controlador que expone los endpoints para gestionar CocheBBDD.
/// </summary>
[ApiController]
[Route("api/cochebbdd")] // Ruta fija para esta entidad
public class CocheBBDDController : ControllerBase
{
    private readonly ICocheBBDDService _service;

    /// <summary>
    /// Inyecta el servicio para gestionar los coches.
    /// </summary>
    public CocheBBDDController(ICocheBBDDService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene todos los coches.
    /// GET: api/cochebbdd
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<CocheBBDD>> Get()
    {
        var coches = _service.ObtenerTodos();
        return Ok(coches);
    }

    /// <summary>
    /// Obtiene un coche por su identificador.
    /// GET: api/cochebbdd/{id}
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<CocheBBDD> Get(int id)
    {
        var coche = _service.ObtenerPorId(id);
        if (coche == null)
            return NotFound();
        return Ok(coche);
    }

    /// <summary>
    /// Crea un nuevo coche.
    /// POST: api/cochebbdd
    /// </summary>
    [HttpPost]
    public ActionResult Post([FromBody] CocheBBDD coche)
    {
        _service.Crear(coche);
        return CreatedAtAction(nameof(Get), new { id = coche.Id }, coche);
    }

    /// <summary>
    /// Actualiza un coche existente.
    /// PUT: api/cochebbdd/{id}
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] CocheBBDD coche)
    {
        if (id != coche.Id)
            return BadRequest("El ID de la URL no coincide con el ID del coche.");
        
        var existente = _service.ObtenerPorId(id);
        if (existente == null)
            return NotFound();

        _service.Actualizar(coche);
        return NoContent();
    }

    /// <summary>
    /// Elimina un coche por su identificador.
    /// DELETE: api/cochebbdd/{id}
    /// </summary>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existente = _service.ObtenerPorId(id);
        if (existente == null)
            return NotFound();

        _service.Eliminar(id);
        return NoContent();
    }
}
