USE GestionPruebas
GO

INSERT INTO dbo.Usuarios
(
    NombreUsuario,
    Email,
    PasswordHash,
    Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
(   N'Admin',N'admin@admin.com','ce15783bfcf4948b2af9ba591172225be9cb2b10',1,1,GETDATE());

INSERT INTO dbo.TipoDocumentos
(
    Descripcion,
    Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
(   N'CC',1,1,GETDATE()),
(   N'TI',1,1,GETDATE());

INSERT INTO dbo.EstadoPruebas
(
    Descripcion,
    Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
(   N'Registrada',1,1,GETDATE()),
(   N'En Proceso',1,1,GETDATE()),
(   N'Terminada',1,1,GETDATE()),
(   N'Anulada',1,1,GETDATE());

INSERT INTO dbo.TipoPruebas
(
    Descripcion,
    Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
(   N'Técnica',1,1,GETDATE()),
(   N'Práctica',1,1,GETDATE());

INSERT INTO dbo.LenguajeProgramacion
(
    Descripcion,
    Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
(   N'.NET',1,1,GETDATE()),
(   N'Java',1,1,GETDATE()),
(   N'Python',1,1,GETDATE()),
(   N'JavaScript',1,1,GETDATE());

INSERT INTO dbo.Nivel
(
    Descripcion,
    Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
(   N'Junior',1,1,GETDATE()),
(   N'Middle',1,1,GETDATE()),
(   N'Senior',1,1,GETDATE());

INSERT INTO dbo.Aspirantes
(
    IdTipoDocumento,
    NumeroDocumento,
    Nombre,
    Apellido,
    Direccion,
    Telefono,
    Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
(1, '123456789', 'Juan', 'Perez', 'Calle 123', '1234567890', 1,  1, GETDATE()),
(2, '987654321', 'Maria', 'Gomez', 'Carrera 456', '9876543210', 1,  1, GETDATE()),
(1, '555555555', 'Luis', 'Martinez', 'Avenida 789', '5555555555', 1, 1, GETDATE()),
(2, '111111111', 'Ana', 'Rodriguez', 'Calle 567', '1111111111', 1,  1, GETDATE()),
(1, '222222222', 'Pedro', 'Lopez', 'Calle 890', '2222222222', 1, 1, GETDATE()),
(2, '333333333', 'Laura', 'Hernandez', 'Avenida 123', '3333333333', 1, 1, GETDATE()),
(1, '444444444', 'Carlos', 'Gutierrez', 'Calle 456', '4444444444', 1, 1, GETDATE()),
(2, '666666666', 'Isabel', 'Diaz', 'Carrera 789', '6666666666', 1,1, GETDATE()),
(1, '777777777', 'Miguel', 'Santos', 'Avenida 012', '7777777777', 1, 1, GETDATE()),
(2, '999999999', 'Sofia', 'Fernandez', 'Calle 345', '9999999999', 1, 1, GETDATE());


INSERT INTO dbo.Preguntas
(
    Descripcion,
	IdLenguajeProgramacion,
	Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
('Explique el concepto de CLR en .NET.', 1,1,1, GETDATE()),
('¿Qué es C# y cuáles son sus principales características?', 1,1,1, GETDATE()),
('Explique el manejo de excepciones en C#.', 1,1,1, GETDATE()),
('¿Cuál es la diferencia entre una clase y un struct en C#?', 1,1,1, GETDATE()),
('Explique el concepto de delegados en C#.', 1,1,1, GETDATE()),
('¿Cómo se implementa la herencia en C#?', 1,1,1, GETDATE()),
('Explique el uso de LINQ en .NET.', 1,1,1, GETDATE()),
('¿Qué es ASP.NET y para qué se utiliza?', 1,1,1, GETDATE()),
('Explique el patrón de diseño MVC en el contexto de .NET.', 1,1,1, GETDATE()),
('¿Qué es Entity Framework y cuál es su función en .NET?', 1,1,1, GETDATE());

INSERT INTO dbo.Preguntas
(
    Descripcion,
	IdLenguajeProgramacion,
	Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
('¿Qué es la JVM?', 2,1,1, GETDATE()),
('Explique el concepto de polimorfismo en Java.', 2,1,1, GETDATE()),
('¿Cuál es la diferencia entre una clase abstracta e interfaz en Java?', 2,1,1, GETDATE()),
('Explique el manejo de excepciones en Java.', 2,1,1, GETDATE()),
('¿Qué es un objeto en Java?', 2,1,1, GETDATE()),
('Explique el concepto de herencia en Java.', 2,1,1, GETDATE()),
('¿Cómo se realiza la entrada de datos por teclado en Java?', 2,1,1, GETDATE()),
('Explique el ciclo de vida de un hilo en Java.', 2,1,1, GETDATE()),
('¿Cuándo usar la palabra clave "super" en Java?', 2,1,1, GETDATE()),
('Explique el funcionamiento de la clase String en Java.', 2,1,1, GETDATE());

INSERT INTO dbo.Preguntas
(
    Descripcion,
	IdLenguajeProgramacion,
	Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
('¿Qué es Python y por qué es popular en el desarrollo web?', 3,1,1, GETDATE()),
('Explique la diferencia entre una lista y una tupla en Python.', 3,1,1, GETDATE()),
('¿Cómo se gestionan los errores en Python?',3, 1, 1,GETDATE()),
('Explique el funcionamiento de las list comprehensions en Python.',3, 1,1, GETDATE()),
('¿Qué es un diccionario en Python y cómo se utiliza?', 3,1,1, GETDATE()),
('Explique el concepto de herencia múltiple en Python.', 3,1,1, GETDATE()),
('¿Qué es un decorador en Python?', 3,1,1, GETDATE()),
('Explique el uso de la función lambda en Python.',3, 1,1, GETDATE()),
('¿Cómo se manejan los archivos en Python?',3, 1,1, GETDATE()),
('Explique el concepto de virtualenv en Python.',3, 1,1, GETDATE());

INSERT INTO dbo.Preguntas
(
    Descripcion,
	IdLenguajeProgramacion,
	Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
('Explique el concepto de callback en JavaScript.', 4,1,1, GETDATE()),
('¿Qué es el DOM y cómo interactúa con JavaScript?', 4,1,1, GETDATE()),
('Explique el concepto de clousure en JavaScript.', 4,1,1, GETDATE()),
('¿Cómo se realiza la manipulación del DOM con JavaScript?', 4,1,1, GETDATE()),
('Explique el uso de AJAX en JavaScript.', 4,1,1, GETDATE()),
('¿Qué es JSON y cómo se utiliza en JavaScript?', 4,1,1, GETDATE()),
('Explique el funcionamiento de las Promesas en JavaScript.', 4,1,1, GETDATE()),
('¿Cuál es la diferencia entre "==" y "===" en JavaScript?', 4,1,1, GETDATE()),
('Explique el concepto de hoisting en JavaScript.', 4,1,1, GETDATE()),
('¿Qué es el Event Bubbling en JavaScript?', 4,1,1, GETDATE());

INSERT INTO dbo.Preguntas
(
    Descripcion,
	IdLenguajeProgramacion,
	Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
('Desarrolle una solución para el siguiente problema .NET Junior.', 1,1,1, GETDATE()),
('Desarrolle una solución para el siguiente problema Java Junior.', 2,1,1, GETDATE()),
('Desarrolle una solución para el siguiente problema Python Junior.', 3,1,1, GETDATE()),
('Desarrolle una solución para el siguiente problema JavaScript Junior.', 4,1,1, GETDATE());

INSERT INTO dbo.PruebaSeleccion
(
    NombreDescripcion,
    IdTipoPrueba,
    IdLenguajeProgramacion,
    CantidadPreguntas,
    IdNivel,
	Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
('Prueba Técnica .NET Nivel Junior', 1, 1, 5, 1, 1,1, GETDATE()),
('Prueba Técnica .NET Nivel Middle', 1, 1, 5, 2, 1,1, GETDATE()),
('Prueba Técnica .NET Nivel Senior', 1, 1, 5, 3, 1,1, GETDATE()),
('Prueba Técnica Java Nivel Junior', 1, 2, 5, 1, 1,1, GETDATE()),
('Prueba Técnica Java Nivel Middle', 1, 2, 5, 2, 1,1, GETDATE()),
('Prueba Técnica Java Nivel Senior', 1, 2, 5, 3, 1,1, GETDATE()),
('Prueba Técnica Python Nivel Junior', 1, 3, 5, 1, 1,1, GETDATE()),
('Prueba Técnica Python Nivel Middle', 1, 3, 5, 2, 1,1, GETDATE()),
('Prueba Técnica Python Nivel Senior', 1, 3, 5, 3, 1,1, GETDATE()),
('Prueba Técnica JavaScript Nivel Junior', 1, 4, 5, 1, 1,1, GETDATE()),
('Prueba Técnica JavaScript Nivel Middle', 1, 4, 5, 2, 1,1, GETDATE()),
('Prueba Técnica JavaScript Nivel Senior', 1, 4, 5, 3, 1,1, GETDATE()),
('Prueba Práctica .NET Nivel Junior', 2, 1, 1, 1, 1,1, GETDATE()),
('Prueba Práctica Java Nivel Junior', 2, 2, 1, 1, 1,1, GETDATE()),
('Prueba Práctica Python Nivel Junior', 2, 3, 1, 1, 1,1, GETDATE()),
('Prueba Práctica JavaScript Nivel Junior', 2, 4, 1, 1, 1,1, GETDATE());

INSERT INTO dbo.PreguntasPruebaSeleccion
(
    IdPregunta,
    IdPruebaSeleccion,
	Estado,
    IdUsuarioActualizacion,
    FechaActualizacion
)
VALUES
(1,1,1,1,GETDATE()),
(2,1,1,1,GETDATE()),
(3,1,1,1,GETDATE()),
(4,1,1,1,GETDATE()),
(5,1,1,1,GETDATE()),
(6,2,1,1,GETDATE()),
(7,2,1,1,GETDATE()),
(8,2,1,1,GETDATE()),
(9,2,1,1,GETDATE()),
(10,2,1,1,GETDATE()),
(6,3,1,1,GETDATE()),
(7,3,1,1,GETDATE()),
(8,3,1,1,GETDATE()),
(9,3,1,1,GETDATE()),
(10,3,1,1,GETDATE()),

(11,4,1,1,GETDATE()),
(12,4,1,1,GETDATE()),
(13,4,1,1,GETDATE()),
(14,4,1,1,GETDATE()),
(15,4,1,1,GETDATE()),
(16,5,1,1,GETDATE()),
(17,5,1,1,GETDATE()),
(18,5,1,1,GETDATE()),
(19,5,1,1,GETDATE()),
(20,5,1,1,GETDATE()),
(16,6,1,1,GETDATE()),
(17,6,1,1,GETDATE()),
(18,6,1,1,GETDATE()),
(19,6,1,1,GETDATE()),
(20,6,1,1,GETDATE()),

(21,7,1,1,GETDATE()),
(22,7,1,1,GETDATE()),
(23,7,1,1,GETDATE()),
(24,7,1,1,GETDATE()),
(25,7,1,1,GETDATE()),
(26,8,1,1,GETDATE()),
(27,8,1,1,GETDATE()),
(28,8,1,1,GETDATE()),
(29,8,1,1,GETDATE()),
(30,8,1,1,GETDATE()),
(26,9,1,1,GETDATE()),
(27,9,1,1,GETDATE()),
(28,9,1,1,GETDATE()),
(29,9,1,1,GETDATE()),
(30,9,1,1,GETDATE()),

(31,10,1,1,GETDATE()),
(32,10,1,1,GETDATE()),
(33,10,1,1,GETDATE()),
(34,10,1,1,GETDATE()),
(35,10,1,1,GETDATE()),
(36,11,1,1,GETDATE()),
(37,11,1,1,GETDATE()),
(38,11,1,1,GETDATE()),
(39,11,1,1,GETDATE()),
(40,11,1,1,GETDATE()),
(36,12,1,1,GETDATE()),
(37,12,1,1,GETDATE()),
(38,12,1,1,GETDATE()),
(39,12,1,1,GETDATE()),
(40,12,1,1,GETDATE()),

(41,13,1,1,GETDATE()),
(42,14,1,1,GETDATE()),
(43,15,1,1,GETDATE()),
(44,16,1,1,GETDATE());