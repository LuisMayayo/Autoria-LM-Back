using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/// <summary>
/// Controlador que expone los endpoints para gestionar ProductoBBDD.
/// </summary>
[ApiController]
[Route("api/productobbdd")] // Ruta fija para esta entidad
public class ProductoBBDDController : ControllerBase
{
    private readonly IProductoBBDDService _service;

    /// <summary>
    /// Inyecta el servicio para gestionar los productos.
    /// </summary>
    public ProductoBBDDController(IProductoBBDDService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene todos los productos.
    /// GET: api/productobbdd
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<ProductoBBDD>> Get()
    {
        var productos = _service.ObtenerTodos();
        return Ok(productos);
    }

    /// <summary>
    /// Obtiene un producto por su identificador.
    /// GET: api/productobbdd/{id}
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<ProductoBBDD> Get(int id)
    {
        var producto = _service.ObtenerPorId(id);
        if (producto == null)
            return NotFound();
        return Ok(producto);
    }

    /// <summary>
    /// Crea un nuevo producto.
    /// POST: api/productobbdd
    /// </summary>
    [HttpPost]
    public ActionResult Post([FromBody] ProductoBBDD producto)
    {
        _service.Crear(producto);
        return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
    }

    /// <summary>
    /// Actualiza un producto existente.
    /// PUT: api/productobbdd/{id}
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] ProductoBBDD producto)
    {
        if (id != producto.Id)
            return BadRequest("El ID de la URL no coincide con el ID del producto.");
        
        var existente = _service.ObtenerPorId(id);
        if (existente == null)
            return NotFound();

        _service.Actualizar(producto);
        return NoContent();
    }

    /// <summary>
    /// Elimina un producto por su identificador.
    /// DELETE: api/productobbdd/{id}
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
