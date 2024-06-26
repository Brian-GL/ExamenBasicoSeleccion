USE [master]
GO
/****** Object:  Database [BdiExamen]    Script Date: 22/05/2024 12:03:16 a. m. ******/
CREATE DATABASE [BdiExamen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BdiExamen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BdiExamen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BdiExamen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BdiExamen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BdiExamen] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BdiExamen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BdiExamen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BdiExamen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BdiExamen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BdiExamen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BdiExamen] SET ARITHABORT OFF 
GO
ALTER DATABASE [BdiExamen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BdiExamen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BdiExamen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BdiExamen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BdiExamen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BdiExamen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BdiExamen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BdiExamen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BdiExamen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BdiExamen] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BdiExamen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BdiExamen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BdiExamen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BdiExamen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BdiExamen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BdiExamen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BdiExamen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BdiExamen] SET RECOVERY FULL 
GO
ALTER DATABASE [BdiExamen] SET  MULTI_USER 
GO
ALTER DATABASE [BdiExamen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BdiExamen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BdiExamen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BdiExamen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BdiExamen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BdiExamen] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BdiExamen', N'ON'
GO
ALTER DATABASE [BdiExamen] SET QUERY_STORE = ON
GO
ALTER DATABASE [BdiExamen] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BdiExamen]
GO
/****** Object:  Table [dbo].[tblExamen]    Script Date: 22/05/2024 12:03:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblExamen](
	[IdExamen] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[Descripcion] [varchar](255) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_tblExamen] PRIMARY KEY CLUSTERED 
(
	[IdExamen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblExamen] ADD  CONSTRAINT [DF_tblExamen_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  StoredProcedure [dbo].[spActualizar]    Script Date: 22/05/2024 12:03:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brian Gaytan>
-- Create date: <21/05/2024,>
-- Description:	<Permite actualziar un exámen en la tabla dbo.tblExamen>
-- =============================================
CREATE PROCEDURE [dbo].[spActualizar]
	@IdExamen INT,
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255)
AS
BEGIN
	
	DECLARE @Codigo INT = 0;
	DECLARE @Mensaje VARCHAR(4000) = 'Registro actualizado satisfactoriamente';

	
	BEGIN TRY

		-- Validamos que exista el registro a actualizar
		IF NOT EXISTS(
			SELECT 
				T0.IdExamen
			FROM dbo.tblExamen T0 WITH(NOLOCK)
				WHERE T0.IdExamen = @IdExamen
				AND T0.Activo = 1
		)
		BEGIN
			SET @Codigo = -1;
			SET @Mensaje = 'El registro a actualizar no se encuentra disponible';
		END

		IF @Codigo > -1
		BEGIN

			-- Validar entradas:
			IF @Nombre IS NULL OR TRIM(@Nombre) IS NULL
			BEGIN
				SET @Codigo = -2;
				SET @Mensaje = 'El campo @Nombre es requerido y no debe de contener espacios en blanco por completo';
			END

			IF @Descripcion IS NULL OR TRIM(@Descripcion) IS NULL
			BEGIN
				SET @Codigo = -3;
				SET @Mensaje = 'El campo @Descripcion es requerido y no debe de contener espacios en blanco por completo';
			END
			
			IF @Codigo > -1
			BEGIN

				-- Limpiamos las entradas
				SET @Nombre = TRIM(@Nombre);
				SET @Descripcion = TRIM(@Descripcion);

				-- Validamos que no exista un registro con el mismo nombre y que este mismo no sea el registro a actualizar
				IF EXISTS(
					SELECT 
						T0.IdExamen
					FROM dbo.tblExamen T0 WITH(NOLOCK)
						WHERE T0.Nombre = @Nombre
						AND T0.IdExamen <> @IdExamen
						AND T0.Activo = 1
				)
				BEGIN
					SET @Codigo = -4;
					SET @Mensaje = CONCAT('El nombre "', @Nombre, '" ya se encuentra en uso en otro registro de exámen');
				END

				IF @Codigo > -1
				BEGIN
				
					-- Iniciamos la transaccion:
					BEGIN TRANSACTION

					-- Actualizar en la tabla tblExamen:
					UPDATE T0
						SET 
							T0.Nombre = @Nombre,
							T0.Descripcion = @Descripcion
						FROM dbo.tblExamen T0 WITH(NOLOCK)
							WHERE t0.IdExamen = @IdExamen
							AND T0.Activo = 1;

					-- Confirmamos la transaccion
					COMMIT TRANSACTION 

				END

			END
		END

		-- Regresar el resultado
		SELECT 
			@Codigo AS Codigo,
			@Mensaje AS Mensaje;

	END TRY
	BEGIN CATCH

		-- Ocurrió un error, deshacemos los cambios
		ROLLBACK TRANSACTION

		SET @Codigo = ERROR_NUMBER() * -1;
		SET @Mensaje = ERROR_MESSAGE();
		
		SELECT 
			@Codigo AS Codigo,
			@Mensaje AS Mensaje;

	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spAgregar]    Script Date: 22/05/2024 12:03:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brian Gaytan>
-- Create date: <21/05/2024,>
-- Description:	<Permite agregar un nuevo exámen en la tabla dbo.tblExamen>
-- =============================================
CREATE PROCEDURE [dbo].[spAgregar]
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255)
AS
BEGIN
	
	DECLARE @Codigo INT = 0;
	DECLARE @Mensaje VARCHAR(4000) = 'Registro insertado satisfactoriamente';

	BEGIN TRY

		-- Validar entradas:
		IF @Nombre IS NULL OR TRIM(@Nombre) IS NULL
		BEGIN
			SET @Codigo = -1;
			SET @Mensaje = 'El campo @Nombre es requerido y no debe de contener espacios en blanco por completo';
		END

		IF @Descripcion IS NULL OR TRIM(@Descripcion) IS NULL
		BEGIN
			SET @Codigo = -2;
			SET @Mensaje = 'El campo @Descripcion es requerido y no debe de contener espacios en blanco por completo';
		END
			
		IF @Codigo > -1
		BEGIN

			-- Limpiamos las entradas
			SET @Nombre = TRIM(@Nombre);
			SET @Descripcion = TRIM(@Descripcion);

			-- Validamos que no exista un registro con el mismo nombre
			IF EXISTS(
				SELECT 
					T0.IdExamen
				FROM dbo.tblExamen T0 WITH(NOLOCK)
					WHERE T0.Nombre = @Nombre
					AND T0.Activo = 1
			)
			BEGIN
				SET @Codigo = -3;
				SET @Mensaje = CONCAT('El registro con nombre "', @Nombre, '" ya se encuentra registrado');
			END

			IF @Codigo > -1
			BEGIN
				
				-- Iniciamos la transaccion:
				BEGIN TRANSACTION

				-- Insertar en la tabla tblExamen:
				INSERT INTO [dbo].[tblExamen](
					Nombre,
					Descripcion)
				VALUES(
					@Nombre,
					@Descripcion);

				-- Confirmamos la transaccion
				COMMIT TRANSACTION 

				-- Establecer el id creado como el Codigo de salida:
				SET @Codigo = SCOPE_IDENTITY();

			END

		END

		-- Regresar el resultado
		SELECT 
			@Codigo AS Codigo,
			@Mensaje AS Mensaje;

	END TRY
	BEGIN CATCH

		-- Ocurrió un error, deshacemos los cambios
		ROLLBACK TRANSACTION

		SET @Codigo = ERROR_NUMBER() * -1;
		SET @Mensaje = ERROR_MESSAGE();
		
		SELECT 
			@Codigo AS Codigo,
			@Mensaje AS Mensaje;

	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spConsultar]    Script Date: 22/05/2024 12:03:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brian Gaytan>
-- Create date: <21/05/2024>
-- Description:	<Permite consultar los registros de la tabla dbo.tlbExamen de acuerdo a los filtros establecidos>
-- =============================================
CREATE PROCEDURE [dbo].[spConsultar]
	@IdExamen INT,
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255)
AS
BEGIN
	
	BEGIN TRY

		SELECT 
			T0.IdExamen,
			T0.Nombre,
			T0.Descripcion
			FROM dbo.tblExamen T0 WITH(NOLOCK)
		WHERE 
			T0.IdExamen = ISNULL(@IdExamen, T0.IdExamen)
			AND ISNULL(T0.Nombre, '1') = ISNULL(@Nombre, ISNULL(T0.Nombre, '1'))
			AND ISNULL(T0.Descripcion, '1') = ISNULL(@Descripcion, ISNULL(T0.Descripcion, '1'))
			AND T0.Activo = 1;

	END TRY
	BEGIN CATCH
		
		SELECT TOP 0
			-1 AS IdExamen,
			'' As Nombre,
			'' AS Descripcion;

	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[spEliminar]    Script Date: 22/05/2024 12:03:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brian Gaytan>
-- Create date: <21/05/2024>
-- Description:	<Permite eliminar un registro en la tabla dbo.tblExamen>
-- =============================================
CREATE PROCEDURE [dbo].[spEliminar]
	@IdExamen INT
AS
BEGIN
	
	DECLARE @Codigo INT = 0;
	DECLARE @Mensaje VARCHAR(4000) = 'Registro eliminado satisfactoriamente';

	BEGIN TRY

		-- Validamos que exista el registro a eliminar
		IF NOT EXISTS(
			SELECT 
				T0.IdExamen
			FROM dbo.tblExamen T0 WITH(NOLOCK)
				WHERE T0.IdExamen = @IdExamen
				AND T0.Activo = 1
		)
		BEGIN
			SET @Codigo = -1;
			SET @Mensaje = 'El registro a eliminar no se encuentra disponible';
		END

		IF @Codigo > -1
		BEGIN

			-- Iniciamos la transaccion:
			BEGIN TRANSACTION

			-- Remover en la tabla tblExamen para generar la eliminación:
			DELETE
				FROM dbo.tblExamen
					WHERE IdExamen = @IdExamen
					AND Activo = 1;

			-- Confirmamos la transaccion
			COMMIT TRANSACTION 

		END

		-- Regresar el resultado
		SELECT 
			@Codigo AS Codigo,
			@Mensaje AS Mensaje;

	END TRY
	BEGIN CATCH

		-- Ocurrió un error, deshacemos los cambios
		ROLLBACK TRANSACTION

		SET @Codigo = ERROR_NUMBER() * -1;
		SET @Mensaje = ERROR_MESSAGE();
		
		SELECT 
			@Codigo AS Codigo,
			@Mensaje AS Mensaje;

	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarLogico]    Script Date: 22/05/2024 12:03:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brian Gaytan>
-- Create date: <21/05/2024>
-- Description:	<Permite remover/eliminar (eliminación lógica) un registro en la tabla dbo.tblExamen>
-- =============================================
CREATE PROCEDURE [dbo].[spEliminarLogico]
	@IdExamen INT
AS
BEGIN
	
	DECLARE @Codigo INT = 0;
	DECLARE @Mensaje VARCHAR(4000) = 'Registro eliminado satisfactoriamente';

	-- Iniciamos la transaccion:
	BEGIN TRANSACTION
	BEGIN TRY

		-- Validamos que exista el registro a eliminar
		IF NOT EXISTS(
			SELECT 
				T0.IdExamen
			FROM dbo.tblExamen T0 WITH(NOLOCK)
				WHERE T0.IdExamen <> @IdExamen
				AND T0.Activo = 1
		)
		BEGIN
			SET @Codigo = -1;
			SET @Mensaje = 'El registro a eliminar no se encuentra disponible';
		END

		IF @Codigo > -1
		BEGIN

			-- Actualizar en la tabla tblExamen para generar la eliminación lógica:
			UPDATE T0
				SET 
					T0.Activo = 0
				FROM dbo.tblExamen T0 WITH(NOLOCK)
					WHERE t0.IdExamen = @IdExamen
					AND T0.Activo = 1;

			-- Confirmamos la transaccion
			COMMIT TRANSACTION 

		END

		-- Regresar el resultado
		SELECT 
			@Codigo AS Codigo,
			@Mensaje AS Mensaje;

	END TRY
	BEGIN CATCH

		-- Ocurrió un error, deshacemos los cambios
		ROLLBACK TRANSACTION

		SET @Codigo = ERROR_NUMBER() * -1;
		SET @Mensaje = ERROR_MESSAGE();
		
		SELECT 
			@Codigo AS Codigo,
			@Mensaje AS Mensaje;

	END CATCH

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de catálogos de exámenes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblExamen'
GO
USE [master]
GO
ALTER DATABASE [BdiExamen] SET  READ_WRITE 
GO
