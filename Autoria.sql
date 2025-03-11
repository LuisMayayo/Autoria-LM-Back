-- Crear la tabla ProductoBBDD
CREATE TABLE ProductoBBDD (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(200) NOT NULL,
    Autor NVARCHAR(200) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    NumeroSerie NVARCHAR(50) NOT NULL
);

-- Insertar algunos productos de ejemplo
INSERT INTO ProductoBBDD (Titulo, Autor, Precio, NumeroSerie)
VALUES 
('La sombra del viento', 'Carlos Ruiz Zafón', 15.99, 'SZ-001'),
('Cien años de soledad', 'Gabriel García Márquez', 20.50, 'CY-002'),
('El nombre de la rosa', 'Umberto Eco', 18.75, 'NR-003');
