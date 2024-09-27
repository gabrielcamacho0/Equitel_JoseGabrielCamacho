--*****************************************1. CREACIÓN DE OBJETOS*****************************************
--CREATE DATABASE PruebaEquitelJGC

--*****************************************2. CREACIÓN DE TABLAS*****************************************
--CREATE TABLE Rol (
--    IdRol int PRIMARY KEY IDENTITY(1,1),
--    Rol varchar(50) NOT NULL,
--    Estado bit NOT NULL DEFAULT 1
--);

--CREATE TABLE Usuario (
--    IdUsuario int PRIMARY KEY IDENTITY(1,1),
--    NombreUsuario varchar(50) NOT NULL,
--    Logueo varchar(150) NOT NULL,
--    Clave varchar(max) NOT NULL,
--    Rol int FOREIGN KEY REFERENCES Rol(IdRol),
--	Estado bit NOT NULL DEFAULT 1
--);

--CREATE TABLE Proveedor (
--    IdProveedor int PRIMARY KEY IDENTITY(1,1),
--    RazonSocial varchar(255) NOT NULL,
--    Nit varchar(20) NOT NULL,
--    Estado bit NOT NULL DEFAULT 1
--);

--CREATE TABLE Producto (
--    IdProducto int PRIMARY KEY IDENTITY(1,1),
--    NombreProducto varchar(255) NOT NULL,
--    DescripcionProducto varchar(50) NOT NULL,
--    ModeloProducto int NOT NULL,
--    ValorProducto decimal(18,2) NOT NULL,
--	IdProveedor int FOREIGN KEY REFERENCES Proveedor(IdProveedor),
--    Estado bit NOT NULL DEFAULT 1,
--	CantidadProducto int NOT NULL
--);


--CREATE TABLE Venta (
--    IdVenta int PRIMARY KEY IDENTITY(1,1),
--	FechaVenta DATE NOT NULL,
--    IdVendedor int FOREIGN KEY REFERENCES Usuario(IdUsuario),
--    TotalVenta decimal(18,2) NOT NULL
--);

--CREATE TABLE DetalleVenta (
--    IdDetalleVenta int PRIMARY KEY IDENTITY(1,1),
--    IdVenta int FOREIGN KEY REFERENCES Venta(IdVenta),
--    IdProducto int FOREIGN KEY REFERENCES Producto(IdProducto),
--    CantidadVendida int NOT NULL,
--    ValorUnitario decimal(18,2) NOT NULL
--);

--CREATE TABLE Auditoria (
--    IdAuditoria int PRIMARY KEY IDENTITY(1,1),
--    Fecha DATE NOT NULL,
--    IdUsuario int FOREIGN KEY REFERENCES Usuario(IdUsuario),
--    Accion varchar(255) NOT NULL,
--);

--*****************************************INSERCIÓN DE DATA INICIAL*****************************************
--INSERT INTO 
--	Rol
--VALUES
--	('Administrador',1),
--	('Vendedor',1);

--INSERT INTO
--	Usuario
--VALUES
--	('ADMINISTRADOR DEL SISTEMA', 'ADMIN', 'e10adc3949ba59abbe56e057f20f883e',1,1),
--	('VENDEDOR 1', 'VENDEDOR1', 'e10adc3949ba59abbe56e057f20f883e',2,1);

--INSERT INTO 
--	Proveedor
--VALUES
--	('PROVEEDOR 1', '123.456.789-1',1),
--	('PROVEEDOR 2', '987.654.321-1',1);

--*****************************************CREACIÓN DE PROCEDIMIENTOS ALMACENADOS--*****************************************
--CREATE PROCEDURE [dbo].[SP_Usuario]

--@Action INT = NULL,
--@IdUsuario INT = NULL,
--@NombreUsuario NVARCHAR(150) = NULL,
--@Logueo NVARCHAR(150) = NULL,
--@Clave NVARCHAR(MAX) = NULL,
--@Rol INT = NULL,
--@Estado BIT = NULL

--AS

--BEGIN 
--	--LOGIN
--	IF @Action = 0
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Usuario
--		WHERE
--			Logueo = @Logueo
--			AND Clave = @Clave
--			AND Estado = 1
--	END

--	--CARGAR TABLA DE USUARIOS
--	IF @Action = 1
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Usuario
--		WHERE 
--			Estado = 1
--	END

--	--VALIDAR QUE UN USUARIO YA EXISTE
--	IF @Action = 2
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Usuario
--		WHERE
--			Logueo = @Logueo
--			AND IdUsuario != @IdUsuario
--			AND Estado = 1
--	END

--	--CREAR USUARIO
--	IF @Action = 3
--	BEGIN
--		INSERT INTO
--			PruebaEquitelJGC.dbo.Usuario
--		VALUES
--			(@NombreUsuario,
--			@Logueo,
--			@Clave,
--			@Rol,
--			1)
--	END

--	--EDITAR USUARIO
--	IF @Action = 4
--	BEGIN
--		UPDATE
--			PruebaEquitelJGC.dbo.Usuario
--		SET
--			NombreUsuario = @NombreUsuario,
--			Logueo = @Logueo,
--			Clave = @Clave,
--			Rol = @Rol
--		WHERE
--			IdUsuario = @IdUsuario
--	END

--	--ELIMINAR USUARIO
--	IF @Action = 5
--	BEGIN
--		UPDATE
--			PruebaEquitelJGC.dbo.Usuario
--		SET
--			Estado = 0
--		WHERE
--			IdUsuario = @IdUsuario
--	END

--	--TRAER INFORMACIÓN DE UN USUARIO
--	IF @Action = 6
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Usuario
--		WHERE
--			IdUsuario = @IdUsuario
--	END
--END;


--CREATE PROCEDURE [dbo].[SP_Producto]

--@Action INT = NULL,
--@IdProducto INT = NULL,
--@NombreProducto VARCHAR(255) = NULL,
--@DescripcionProducto VARCHAR(50) = NULL,
--@ModeloProducto INT = NULL,
--@ValorProducto DECIMAL (18,2) = NULL,
--@IdProveedor INT = NULL,
--@Estado BIT = NULL,
--@CantidadProducto INT = NULL

--AS

--BEGIN 
--	--CARGAR TABLA DE PRODUCTOS
--	IF @Action = 0
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Producto
--		WHERE 
--			Estado = 1
--	END

--	--VALIDAR QUE UN PRODUCTO YA EXISTE
--	IF @Action = 1
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Producto
--		WHERE
--			NombreProducto = @NombreProducto
--			AND IdProducto != @IdProducto
--			AND Estado = 1
--			AND ModeloProducto = @ModeloProducto
--	END

--	--CREAR PRODUCTO
--	IF @Action = 2
--	BEGIN
--		INSERT INTO
--			PruebaEquitelJGC.dbo.Producto
--		VALUES
--			(@NombreProducto,
--			@DescripcionProducto,
--			@ModeloProducto,
--			@ValorProducto,
--			@IdProveedor,
--			1,
--			@CantidadProducto)
--	END

--	--EDITAR PRODUCTO
--	IF @Action = 3
--	BEGIN
--		UPDATE
--			PruebaEquitelJGC.dbo.Producto
--		SET
--			NombreProducto = @NombreProducto,
--			DescripcionProducto = @DescripcionProducto,
--			ModeloProducto = @ModeloProducto,
--			IdProveedor = @IdProveedor,
--			CantidadProducto = @CantidadProducto
--		WHERE
--			IdProducto = @IdProducto
--	END

--	--ELIMINAR PRODUCTO
--	IF @Action = 4
--	BEGIN
--		UPDATE
--			PruebaEquitelJGC.dbo.Producto
--		SET
--			Estado = 0
--		WHERE
--			IdProducto = @IdProducto
--	END

--	--TRAER INFORMACIÓN DE UN Producto
--	IF @Action = 5
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Producto
--		WHERE
--			IdProducto = @IdProducto
--	END
--END;

--CREATE PROCEDURE [dbo].[SP_Venta]

--@Action INT = NULL,
--@IdVenta INT = NULL,
--@FechaVenta DATE = NULL,
--@IdVendedor INT = NULL,
--@TotalVenta DECIMAL(18,2) = NULL

--AS

--BEGIN 
--	--CARGAR TABLA DE VENTAS DEL DÍA
--	IF @Action = 0
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Venta
--		WHERE 
--			FechaVenta = GETDATE()
--	END
	
--	--INSERTAR UNA NUEVA VENTA Y DEVOLVER EL ID DE LA VENTA
--	IF @Action = 1
--	BEGIN
--		INSERT INTO
--			PruebaEquitelJGC.dbo.Venta
--			OUTPUT inserted.IdVenta
--		VALUES
--		(GETDATE(),
--		@IdVendedor,
--		@TotalVenta)
--	END

--	--CONSULTAR LA INFORMACIÓN DE UNA VENTA
--	IF @Action = 2
--	BEGIN
--		SELECT
--			*
--		FROM
--			PruebaEquitelJGC.dbo.Venta
--		WHERE 
--			IdVenta = @IdVenta
--	END
----TOTAL DE VENTAS AL DIA
--	IF @Action = 3
--	BEGIN
--		SELECT 
--			SUM(TotalVenta) AS TotalVentas
--		FROM
--			PruebaEquitelJGC.dbo.Venta
--		WHERE
--			FechaVenta = CONVERT(DATE,GETDATE())
--	END
--END;

--CREATE PROCEDURE [dbo].[SP_DetalleVenta]

--@Action INT = NULL,
--@IdDetalleVenta INT = NULL,
--@IdVenta INT = NULL,
--@IdProducto INT = NULL,
--@CantidadVendida INT = NULL,
--@ValorUnitario DECIMAL (18,2) = NULL

--AS

--BEGIN 
--	--INSERTAR UN NUEVO PRODUCTO A LA VENTA
--	IF @Action = 0
--	BEGIN
--		INSERT INTO
--			PruebaEquitelJGC.dbo.DetalleVenta
--		VALUES
--		(@IdVenta,
--		@IdProducto,
--		@CantidadVendida,
--		@ValorUnitario)
--	END
	
--	--RESTAR AL STOCK
--	IF @Action = 1
--	BEGIN
--		UPDATE
--			PruebaEquitelJGC.dbo.Producto
--		SET
--			CantidadProducto = (CantidadProducto - @CantidadVendida)
--		WHERE
--			IdProducto = @IdProducto
--	END
----CARGAR DETALLE DE VENTAS
--	IF @Action = 2
--	BEGIN
--			SELECT 
--			V.IdVenta,
--			U.Logueo,
--			P.NombreProducto,
--			DV.ValorUnitario,
--			DV.CantidadVendida,
--			V.TotalVenta
--			FROM VENTA V 
--				INNER JOIN DetalleVenta DV ON V.IdVenta = DV.IdVenta
--				INNER JOIN Producto P ON DV.IdProducto = P.IdProducto
--				INNER JOIN Usuario U ON U.IdUsuario = V.IdVendedor
--			WHERE
--				V.FechaVenta = CONVERT(DATE,GETDATE())
--	END
--END;

--CREATE PROCEDURE [dbo].[SP_Auditoria]

--@Action INT = NULL,
--@IdAuditoria INT = NULL,
--@Fecha DATE = NULL,
--@IdUsuario INT = NULL,
--@Accion VARCHAR(255) = NULL

--AS

--BEGIN 
--	--CARGAR TABLA DE AUDITORIAS
--	IF @Action = 0
--	BEGIN
--		SELECT
--			A.IdAuditoria,
--			A.Fecha,
--			U.NombreUsuario,
--			Accion
--		FROM
--			PruebaEquitelJGC.dbo.Auditoria A
--			INNER JOIN PruebaEquitelJGC.dbo.Usuario U ON A.IdUsuario = U.IdUsuario
--	END

----INSERTAR CAMBIO PARA AUDITORIA
--	IF @Action = 1
--	BEGIN
--		INSERT INTO
--			PruebaEquitelJGC.dbo.Auditoria
--		VALUES
--			(CONVERT(DATE,GETDATE()),
--			@IdUsuario,
--			@Accion)
--	END
--END;