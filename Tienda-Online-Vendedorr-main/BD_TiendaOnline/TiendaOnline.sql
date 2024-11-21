CREATE DATABASE TiendaOnline;
USE TiendaOnline;

CREATE TABLE Vendedores (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    CUIT VARCHAR(20) NOT NULL,
    Domicilio VARCHAR(255) NOT NULL,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    Contraseña VARCHAR(255) NOT NULL
);

CREATE TABLE Productos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    VendedorId INT,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    Precio DECIMAL(10, 2) NOT NULL,
    Categoria VARCHAR(50) NOT NULL,
    CantidadStock INT NOT NULL,
    URL VARCHAR(255),
    FOREIGN KEY (VendedorId) REFERENCES Vendedores(Id)
);

CREATE TABLE Publicaciones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProductoId INT,
    Activo BOOLEAN DEFAULT TRUE,
    Url VARCHAR(45),
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE Compras (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    VendedorId INT,
    Fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    PrecioTotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (VendedorId) REFERENCES Vendedores(Id)
);

CREATE TABLE Carrito (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Cantidad INT NOT NULL
);

CREATE TABLE CarritoProducto (
    CarritoId INT,
    ProductoId INT,
    PRIMARY KEY (CarritoId, ProductoId),
    FOREIGN KEY (CarritoId) REFERENCES Carrito(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductoId) REFERENCES Producto(Id) ON DELETE CASCADE
);

CREATE TABLE CompraProductos (
    Id INT PRIMARY KEY IDENTITY,
    CompraId INT FOREIGN KEY REFERENCES Compras(Id),
    ProductoId INT FOREIGN KEY REFERENCES Productos(Id)
);




-- -----------------------------------------------------
-- function CalcularPrecioTotal
-- -----------------------------------------------------
DELIMITER //
CREATE FUNCTION CalcularPrecioTotal(carritoId INT) 
RETURNS DECIMAL(10, 2)
BEGIN
    DECLARE total DECIMAL(10, 2);
    SELECT SUM(p.Precio * c.Cantidad) INTO total
    FROM Carrito c
    JOIN Producto p ON c.IdProducto = p.Id
    WHERE c.Id = carritoId;
    
    RETURN total;
END //
DELIMITER ;

-- -----------------------------------------------------
-- procedure AgregarProductoCarrito
-- -----------------------------------------------------
DELIMITER //
CREATE PROCEDURE AgregarProductoCarrito(IN vendedorId INT, IN productoId INT, IN cantidad INT)
BEGIN
    DECLARE nuevoCarritoId INT;

    -- Agregar el producto al carrito
    INSERT INTO Carrito (IdVendedor, Cantidad) VALUES (vendedorId, cantidad);

    SET nuevoCarritoId = LAST_INSERT_ID();
    
    -- Retornar el ID del carrito nuevo
    SELECT nuevoCarritoId AS CarritoId;
END //
DELIMITER ;

-- -----------------------------------------------------
-- procedure RealizarCompra
-- -----------------------------------------------------
DELIMITER //
CREATE PROCEDURE RealizarCompra(IN vendedorId INT)
BEGIN
    DECLARE total DECIMAL(10, 2);
    
    -- Calcular el total
    SET total = CalcularPrecioTotal(vendedorId);
    
    -- Insertar la compra
    INSERT INTO Compra (IdVendedor, PrecioTotal) VALUES (vendedorId, total);
END //
DELIMITER ;


-- -----------------------------------------------------
-- procedure CambiarEstadoPublicacion
-- -----------------------------------------------------
DELIMITER //
CREATE PROCEDURE CambiarEstadoPublicacion(IN publicacionId INT, IN estado BOOLEAN)
BEGIN
    UPDATE Publicacion SET Activo = estado WHERE Id = publicacionId;
END //
DELIMITER ;


-- Ejemplo de inserción de un vendedor
--INSERT INTO Vendedor (Nombre, Apellido, Email, CUIT, Domicilio, NombreUsuario, Contraseña)
--VALUES ('Juan', 'Pérez', 'juan.perez@example.com', '20-12345678-9', 'Calle Falsa 123', 'juanp', 'contraseña123');

--  Ejemplo de inserción de un producto
-- INSERT INTO Producto (Nombre, Descripcion, Precio, Categoria, CantidadStock, URL, IdVendedor)
-- VALUES ('Producto A', 'Descripción del Producto A', 100.00, 'Categoría 1', 10, 'http://example.com/productoA.jpg', 1);

