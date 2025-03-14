using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/// <summary>
/// Controlador que expone los endpoints para gestionar Balon.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BalonController : ControllerBase
{
    /// <summary>
    /// Servicio utilizado para gestionar la lógica de negocio.
    /// </summary>
    private readonly IBalonService _service;
    
    /// <summary>
    /// Constructor que inyecta el servicio.
    /// </summary>
    /// <param name="service">Servicio de Balon.</param>
    public BalonController(IBalonService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene todos los balones.
    /// GET: api/balon
    /// </summary>
    /// <returns>Lista de balones.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Balon>> Get()
    {
        var balones = _service.ObtenerTodos();
        return Ok(balones);
    }

    /// <summary>
    /// Obtiene un balon por su identificador.
    /// GET: api/balonautoria/{id}
    /// </summary>
    /// <param name="id">Identificador del balon.</param>
    /// <returns>Balon encontrado o NotFound si no existe.</returns>
    [HttpGet("{id}")]
    public ActionResult<Balon> Get(int id)
    {
        var balon = _service.ObtenerPorId(id);
        if (balon == null)
            return NotFound();
        return Ok(balon);
    }

    /// <summary>
    /// Crea un nuevo balon.
    /// POST: api/balon
    /// </summary>
    /// <param name="balon">Balon a crear.</param>
    /// <returns>Balon creado con su nuevo identificador.</returns>
    [HttpPost]
    public ActionResult Post([FromBody] Balon balon)
    {
        _service.Crear(balon);
        // Retorna 201 Created junto con la ubicación del nuevo recurso.
        return CreatedAtAction(nameof(Get), new { id = balon.Id }, balon);
    }

    /// <summary>
    /// Actualiza un balon existente.
    /// PUT: api/balon/{id}
    /// </summary>
    /// <param name="id">Identificador del balon a actualizar.</param>
    /// <param name="balon">Datos actualizados del balon.</param>
    /// <returns>Código HTTP adecuado según la operación.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Balon balon)
    {
        if (id != balon.Id)
            return BadRequest("El ID de la URL no coincide con el ID del balon.");

        var existente = _service.ObtenerPorId(id);
        if (existente == null)
            return NotFound();

        _service.Actualizar(balon);
        // Retorna 204 No Content indicando que la operación fue exitosa.
        return NoContent();
    }

    /// <summary>
    /// Elimina un balon por su identificador.
    /// DELETE: api/balon/{id}
    /// </summary>
    /// <param name="id">Identificador del balon a eliminar.</param>
    /// <returns>Código HTTP adecuado según la operación.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existente = _service.ObtenerPorId(id);
        if (existente == null)
            return NotFound();

        _service.Eliminar(id);
        // Retorna 204 No Content indicando que la eliminación fue exitosa.
        return NoContent();
    }
}
