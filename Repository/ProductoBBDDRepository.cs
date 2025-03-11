using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


/// <summary>
/// Implementa la interfaz IProductoBBDDRepository utilizando ADO.NET para comunicarse con MSSQL.
/// </summary>
public class ProductoBBDDRepository : IProductoBBDDRepository
{
    /// <summary>
    /// Cadena de conexión a la base de datos MSSQL.
    /// </summary>
    private readonly string _connectionString;

    /// <summary>
    /// Constructor que recibe la cadena de conexión.
    /// </summary>
    public ProductoBBDDRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <inheritdoc/>
    public IEnumerable<ProductoBBDD> GetAll()
    {
        var productos = new List<ProductoBBDD>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Consulta para obtener todos los productos de la tabla ProductoBBDD
            string query = "SELECT Id, Titulo, Autor, Precio, NumeroSerie FROM ProductoBBDD";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new ProductoBBDD
                        {
                            Id = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Autor = reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            NumeroSerie = reader.GetString(4)
                        };
                        productos.Add(producto);
                    }
                }
            }
        }
        return productos;
    }

    /// <inheritdoc/>
    public ProductoBBDD GetById(int id)
    {
        ProductoBBDD producto = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Consulta para obtener un producto en base a su Id
            string query = "SELECT Id, Titulo, Autor, Precio, NumeroSerie FROM ProductoBBDD WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new ProductoBBDD
                        {
                            Id = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Autor = reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            NumeroSerie = reader.GetString(4)
                        };
                    }
                }
            }
        }
        return producto;
    }

    /// <inheritdoc/>
    public void Add(ProductoBBDD producto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Inserta el producto y obtiene el nuevo Id asignado
            string query = @"INSERT INTO ProductoBBDD (Titulo, Autor, Precio, NumeroSerie)
                             VALUES (@Titulo, @Autor, @Precio, @NumeroSerie);
                             SELECT SCOPE_IDENTITY();";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Titulo", producto.Titulo);
                command.Parameters.AddWithValue("@Autor", producto.Autor);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@NumeroSerie", producto.NumeroSerie);
                var result = command.ExecuteScalar();
                producto.Id = Convert.ToInt32(result);
            }
        }
    }

    /// <inheritdoc/>
    public void Update(ProductoBBDD producto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Actualiza los datos del producto existente en la tabla
            string query = "UPDATE ProductoBBDD SET Titulo = @Titulo, Autor = @Autor, Precio = @Precio, NumeroSerie = @NumeroSerie WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Titulo", producto.Titulo);
                command.Parameters.AddWithValue("@Autor", producto.Autor);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@NumeroSerie", producto.NumeroSerie);
                command.Parameters.AddWithValue("@Id", producto.Id);
                command.ExecuteNonQuery();
            }
        }
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Elimina el producto con el Id especificado
            string query = "DELETE FROM ProductoBBDD WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
