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

