INSERT INTO usuario (dni, email, contraseña, nombre, apellidos, tlf, tarjeta, cvv_tarjeta, fecha_exp_tarjeta) VALUES
('123456789', 'juan@example.com', 'password123', 'Juan', 'Perez', 123456789, 1234123412341234, 123, '12/24'),
('987654321', 'maria@example.com', 'password456', 'Maria', 'Gonzalez', 987654321, 4321432143214321, 321, '11/23');

-- Sample Data for table: categoria
INSERT INTO dbo.categoria (nombre, origen, logo) VALUES
('Nike', 'USA', 'nike.png'),
('Adidas', 'Germany', 'Logo_Adidas.png');


select * from dbo.usuario;