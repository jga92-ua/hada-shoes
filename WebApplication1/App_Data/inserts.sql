


-- Sample Data for table: usuario
INSERT INTO usuario (dni, email, contraseña, nombre, apellidos, tlf, tarjeta, cvv_tarjeta, fecha_exp_tarjeta) VALUES
('123456789', 'juan@example.com', 'password123', 'Juan', 'Perez', 123456789, 1234123412341234, 123, '12/24'),
('987654321', 'maria@example.com', 'password456', 'Maria', 'Gonzalez', 987654321, 4321432143214321, 321, '11/23');
select * from usuario;

select * from tipo_producto;

-- Sample Data for table: tipo_producto
INSERT INTO dbo.tipo_producto (tipo_producto) VALUES
('Running Shoes'),
('Casual Shoes');

select * from categoria;


-- Sample Data for table: categoria
INSERT INTO dbo.categoria (nombre, origen, logo) VALUES
('Nike', 'USA', 'nike.png'),
('Adidas', 'Germany', 'Logo_Adidas.png');


select * from producto;

-- Sample Data for table: producto
INSERT INTO producto (id_producto, nombre, descripcion, precio, imagen, tipo_producto, categoria) VALUES
(10001, 'Nike Air Max', 'Comfortable running shoes', 120.00, 'src/NikeAirMax.png', 'Running Shoes', 'Nike'),
(10002, 'Adidas Ultraboost', 'High-performance running shoes', 150.00, 'src/adidasForum.png', 'Running Shoes', 'Adidas'),
(10003, 'Nike Air Force 1', 'Classic casual shoes', 90.00, 'src/airForce.png', 'Casual Shoes', 'Nike');

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


