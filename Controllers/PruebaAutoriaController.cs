using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/// <summary>
/// Controlador que expone los endpoints para gestionar PruebaAutoria.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PruebaAutoriaController : ControllerBase
{
    /// <summary>
    /// Servicio utilizado para gestionar la lógica de negocio.
    /// </summary>
    private readonly IPruebaAutoriaService _service;
    
    /// <summary>
    /// Constructor que inyecta el servicio.
    /// </summary>
    /// <param name="service">Servicio de PruebaAutoria.</param>
    public PruebaAutoriaController(IPruebaAutoriaService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene todos los pruebas.
    /// GET: api/pruebaautoria
    /// </summary>
    /// <returns>Lista de pruebas.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PruebaAutoria>> Get()
    {
        var pruebas = _service.ObtenerTodos();
        return Ok(pruebas);
    }

    /// <summary>
    /// Obtiene un prueba por su identificador.
    /// GET: api/pruebaautoria/{id}
    /// </summary>
    /// <param name="id">Identificador del prueba.</param>
    /// <returns>Prueba encontrado o NotFound si no existe.</returns>
    [HttpGet("{id}")]
    public ActionResult<PruebaAutoria> Get(int id)
    {
        var prueba = _service.ObtenerPorId(id);
        if (prueba == null)
            return NotFound();
        return Ok(prueba);
    }

    /// <summary>
    /// Crea un nuevo prueba.
    /// POST: api/pruebaautoria
    /// </summary>
    /// <param name="prueba">Prueba a crear.</param>
    /// <returns>Prueba creado con su nuevo identificador.</returns>
    [HttpPost]
    public ActionResult Post([FromBody] PruebaAutoria prueba)
    {
        _service.Crear(prueba);
        // Retorna 201 Created junto con la ubicación del nuevo recurso.
        return CreatedAtAction(nameof(Get), new { id = prueba.Id }, prueba);
    }

    /// <summary>
    /// Actualiza un prueba existente.
    /// PUT: api/pruebaautoria/{id}
    /// </summary>
    /// <param name="id">Identificador del prueba a actualizar.</param>
    /// <param name="prueba">Datos actualizados del prueba.</param>
    /// <returns>Código HTTP adecuado según la operación.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] PruebaAutoria prueba)
    {
        if (id != prueba.Id)
            return BadRequest("El ID de la URL no coincide con el ID del prueba.");

        var existente = _service.ObtenerPorId(id);
        if (existente == null)
            return NotFound();

        _service.Actualizar(prueba);
        // Retorna 204 No Content indicando que la operación fue exitosa.
        return NoContent();
    }

    /// <summary>
    /// Elimina un prueba por su identificador.
    /// DELETE: api/pruebaautoria/{id}
    /// </summary>
    /// <param name="id">Identificador del prueba a eliminar.</param>
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
