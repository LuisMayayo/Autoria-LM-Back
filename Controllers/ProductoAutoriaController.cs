using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/// <summary>
/// Controlador que expone los endpoints para gestionar ProductoAutoria.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductoAutoriaController : ControllerBase
{
    /// <summary>
    /// Servicio utilizado para gestionar la lógica de negocio.
    /// </summary>
    private readonly IProductoAutoriaService _service;
    
    /// <summary>
    /// Constructor que inyecta el servicio.
    /// </summary>
    /// <param name="service">Servicio de ProductoAutoria.</param>
    public ProductoAutoriaController(IProductoAutoriaService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene todos los productos.
    /// GET: api/productoautoria
    /// </summary>
    /// <returns>Lista de productos.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ProductoAutoria>> Get()
    {
        var productos = _service.ObtenerTodos();
        return Ok(productos);
    }

    /// <summary>
    /// Obtiene un producto por su identificador.
    /// GET: api/productoautoria/{id}
    /// </summary>
    /// <param name="id">Identificador del producto.</param>
    /// <returns>Producto encontrado o NotFound si no existe.</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductoAutoria> Get(int id)
    {
        var producto = _service.ObtenerPorId(id);
        if (producto == null)
            return NotFound();
        return Ok(producto);
    }

    /// <summary>
    /// Crea un nuevo producto.
    /// POST: api/productoautoria
    /// </summary>
    /// <param name="producto">Producto a crear.</param>
    /// <returns>Producto creado con su nuevo identificador.</returns>
    [HttpPost]
    public ActionResult Post([FromBody] ProductoAutoria producto)
    {
        _service.Crear(producto);
        // Retorna 201 Created junto con la ubicación del nuevo recurso.
        return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
    }

    /// <summary>
    /// Actualiza un producto existente.
    /// PUT: api/productoautoria/{id}
    /// </summary>
    /// <param name="id">Identificador del producto a actualizar.</param>
    /// <param name="producto">Datos actualizados del producto.</param>
    /// <returns>Código HTTP adecuado según la operación.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] ProductoAutoria producto)
    {
        if (id != producto.Id)
            return BadRequest("El ID de la URL no coincide con el ID del producto.");

        var existente = _service.ObtenerPorId(id);
        if (existente == null)
            return NotFound();

        _service.Actualizar(producto);
        // Retorna 204 No Content indicando que la operación fue exitosa.
        return NoContent();
    }

    /// <summary>
    /// Elimina un producto por su identificador.
    /// DELETE: api/productoautoria/{id}
    /// </summary>
    /// <param name="id">Identificador del producto a eliminar.</param>
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
