


-- Table: usuario
CREATE TABLE usuario (
    dni VARCHAR(9) PRIMARY KEY,
    email VARCHAR(30) UNIQUE,
    contraseña VARCHAR(16) NOT NULL,
    nombre VARCHAR(20) NOT NULL,
    apellidos VARCHAR(40) NOT NULL,
    tlf DECIMAL(9),
    tarjeta DECIMAL(16),
    cvv_tarjeta DECIMAL(3),
    fecha_exp_tarjeta VARCHAR(5)
);

-- Table: producto
CREATE TABLE producto (
    id_producto DECIMAL(5) PRIMARY KEY,
    nombre VARCHAR(50),
    descripcion VARCHAR(500),
    precio DECIMAL(4,2),
    imagen VARCHAR(100),
    tipo_producto VARCHAR(50) NOT NULL,
    categoria VARCHAR(30) NOT NULL,
    FOREIGN KEY (tipo_producto) REFERENCES tipo_producto(tipo_producto),
    FOREIGN KEY (categoria) REFERENCES categoria(nombre)
);



-- Table: categoria
CREATE TABLE categoria (
    nombre VARCHAR(30) PRIMARY KEY,
    origen VARCHAR(30),
    logo VARCHAR(100)
);

-- Table: cesta
CREATE TABLE cesta (
    numCesta DECIMAL(10) PRIMARY KEY,
    usuario_dni VARCHAR(9),
    fecha DATETIME,
    FOREIGN KEY (usuario_dni) REFERENCES usuario(dni)
);

-- Table: linCest
CREATE TABLE linCest (
    numCesta DECIMAL(10),
    linea DECIMAL(5),
    producto DECIMAL(5),
    importe DECIMAL(4,2) NOT NULL,
    cantidad DECIMAL(3),
    PRIMARY KEY (numCesta, linea),
    FOREIGN KEY (numCesta) REFERENCES cesta(numCesta),
    FOREIGN KEY (producto) REFERENCES producto(id_producto)
);

-- Table: pedido
CREATE TABLE pedido (
    numPedido decimal(11) PRIMARY KEY,
    usuario VARCHAR(9) NOT NULL,
    fecha DATETIME NOT NULL,
    FOREIGN KEY (usuario) REFERENCES usuario(dni)
);

-- Table: linPed
CREATE TABLE linPed (
    num_pedido DECIMAL(11),
    linea DECIMAL(5),
    producto DECIMAL(5) NOT NULL,
    importe DECIMAL(9,2) NOT NULL,
    cantidad DECIMAL(3),
    PRIMARY KEY (linea, num_pedido),
    FOREIGN KEY (producto) REFERENCES producto(id_producto),
    FOREIGN KEY (num_pedido) REFERENCES pedido(numPedido)
);

-- Table: valoracion
CREATE TABLE valoracion (
    usuario VARCHAR(9),
    producto DECIMAL(5),
    texto VARCHAR(200),
    puntuacion DECIMAL(1) NOT NULL,
    PRIMARY KEY (usuario, producto),
    FOREIGN KEY (usuario) REFERENCES usuario(dni),
    FOREIGN KEY (producto) REFERENCES producto(id_producto)
);

-- Table: tipo_producto
CREATE TABLE tipo_producto (
    tipo_producto VARCHAR(50) PRIMARY KEY
);

-- Sample Data for table: usuario
INSERT INTO usuario (dni, email, contraseña, nombre, apellidos, tlf, tarjeta, cvv_tarjeta, fecha_exp_tarjeta) VALUES
('123456789', 'juan@example.com', 'password123', 'Juan', 'Perez', 123456789, 1234123412341234, 123, '12/24'),
('987654321', 'maria@example.com', 'password456', 'Maria', 'Gonzalez', 987654321, 4321432143214321, 321, '11/23');


select * from tipo_producto;

-- Sample Data for table: tipo_producto
INSERT INTO dbo.tipo_producto (tipo_producto) VALUES
('Running Shoes'),
('Casual Shoes');

-- Sample Data for table: categoria
INSERT INTO dbo.categoria (nombre, origen, logo) VALUES
('Nike', 'USA', 'nike.png'),
('Adidas', 'Germany', 'Logo_Adidas.png');

-- Sample Data for table: producto
INSERT INTO producto (id_producto, nombre, descripcion, precio, imagen, tipo_producto, categoria) VALUES
(10001, 'Nike Air Max', 'Comfortable running shoes', 120.00, 'NikeAirMax.png', 'Running Shoes', 'Nike'),
(10002, 'Adidas Ultraboost', 'High-performance running shoes', 150.00, 'adidasForum.png', 'Running Shoes', 'Adidas'),
(10003, 'Nike Air Force 1', 'Classic casual shoes', 90.00, 'airForce.png', 'Casual Shoes', 'Nike');

-- Sample Data for table: cesta
INSERT INTO cesta (numCesta, usuario_dni, fecha) VALUES
(1, '123456789', '2024-05-15 10:00:00'),
(2, '987654321', '2024-05-15 11:00:00');

-- Sample Data for table: linCest
INSERT INTO linCest (numCesta, linea, producto, importe, cantidad) VALUES
(1, 1, 10001, 120.00, 1),
(1, 2, 10003, 90.00, 1),
(2, 1, 10002, 150.00, 1),
(2, 2, 10004, 80.00, 2);

-- Sample Data for table: pedido
INSERT INTO pedido (numPedido, usuario, fecha) VALUES
(1, '123456789', '2024-05-15 12:00:00'),
(2, '987654321', '2024-05-15 13:00:00');

-- Sample Data for table: linPed
INSERT INTO linPed (num_pedido, linea, producto, importe, cantidad) VALUES
(1, 1, 10001, 120.00, 1),
(1, 2, 10003, 90.00, 1),
(2, 1, 10002, 150.00, 1),
(2, 2, 10004, 160.00, 2);

-- Sample Data for table: valoracion
INSERT INTO valoracion (usuario, producto, texto, puntuacion) VALUES
('123456789', 10001, 'Very comfortable and stylish!', 5),
('987654321', 10002, 'Great performance shoes!', 4);


