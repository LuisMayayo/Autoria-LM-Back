using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


/// <summary>
/// Implementa la interfaz ICocheBBDDRepository utilizando ADO.NET para comunicarse con MSSQL.
/// </summary>
public class CocheBBDDRepository : ICocheBBDDRepository
{
    /// <summary>
    /// Cadena de conexión a la base de datos MSSQL.
    /// </summary>
    private readonly string _connectionString;

    /// <summary>
    /// Constructor que recibe la cadena de conexión.
    /// </summary>
    public CocheBBDDRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <inheritdoc/>
    public IEnumerable<CocheBBDD> GetAll()
    {
        var coches = new List<CocheBBDD>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Consulta para obtener todos los coches de la tabla CocheBBDD
            string query = "SELECT Id, Nombre, Marca, Precio, DescripcionCoche FROM CocheBBDD";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var coche = new CocheBBDD
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Marca = reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            DescripcionCoche = reader.GetString(4)
                        };
                        coches.Add(coche);
                    }
                }
            }
        }
        return coches;
    }

    /// <inheritdoc/>
    public CocheBBDD GetById(int id)
    {
        CocheBBDD coche = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Consulta para obtener un coche en base a su Id
            string query = "SELECT Id, Nombre, Marca, Precio, DescripcionCoche FROM CocheBBDD WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        coche = new CocheBBDD
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Marca = reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            DescripcionCoche = reader.GetString(4)
                        };
                    }
                }
            }
        }
        return coche;
    }

    /// <inheritdoc/>
    public void Add(CocheBBDD coche)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Inserta el coche y obtiene el nuevo Id asignado
            string query = @"INSERT INTO CocheBBDD (Nombre, Marca, Precio, DescripcionCoche)
                             VALUES (@Nombre, @Marca, @Precio, @DescripcionCoche);
                             SELECT SCOPE_IDENTITY();";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", coche.Nombre);
                command.Parameters.AddWithValue("@Marca", coche.Marca);
                command.Parameters.AddWithValue("@Precio", coche.Precio);
                command.Parameters.AddWithValue("@DescripcionCoche", coche.DescripcionCoche);
                var result = command.ExecuteScalar();
                coche.Id = Convert.ToInt32(result);
            }
        }
    }

    /// <inheritdoc/>
    public void Update(CocheBBDD coche)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            // Actualiza los datos del coche existente en la tabla
            string query = "UPDATE CocheBBDD SET Nombre = @Nombre, Marca = @Marca, Precio = @Precio, DescripcionCoche = @DescripcionCoche WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", coche.Nombre);
                command.Parameters.AddWithValue("@Marca", coche.Marca);
                command.Parameters.AddWithValue("@Precio", coche.Precio);
                command.Parameters.AddWithValue("@DescripcionCoche", coche.DescripcionCoche);
                command.Parameters.AddWithValue("@Id", coche.Id);
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
            // Elimina el coche con el Id especificado
            string query = "DELETE FROM CocheBBDD WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
