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


-- Crear la tabla CocheBBDD
CREATE TABLE CocheBBDD (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(200) NOT NULL,
    Marca NVARCHAR(200) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    DescripcionCoche NVARCHAR(50) NOT NULL
);

-- Insertar algunos coches de ejemplo
INSERT INTO CocheBBDD (Nombre, Marca, Precio, DescripcionCoche)
VALUES 
('Mustang', 'Ford', 55000.00, 'Deportivo clásico'),
('Model S', 'Tesla', 80000.00, 'Eléctrico premium'),
('Civic', 'Honda', 25000.00, 'Sedán confiable');
