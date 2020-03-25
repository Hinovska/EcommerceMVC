USE [Ecommerce]
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Insert Vendedor
	-- =============================================
	CREATE PROCEDURE [dbo].[ins_VENDEDOR]
		@CODIGO INT OUTPUT,
		@NOMBRE NVARCHAR(20),
		@APELLIDO NVARCHAR(20),
		@NUMERO_IDENTIFICACION BIGINT,
		@CODIGO_CIUDAD INT
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		IF EXISTS(SELECT TOP 1 CODIGO FROM CIUDAD WHERE CODIGO = @CODIGO_CIUDAD)
		BEGIN
			INSERT INTO VENDEDOR (NOMBRE, APELLIDO, NUMERO_IDENTIFICACION, CODIGO_CIUDAD) 
			VALUES (@NOMBRE, @APELLIDO, @NUMERO_IDENTIFICACION, @CODIGO_CIUDAD);
			SELECT @CODIGO = @@IDENTITY;
		END
	END
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Get Vendedor
	-- =============================================
	CREATE PROCEDURE [dbo].[get_VENDEDOR]
		@CODIGO INT
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		SELECT * FROM VENDEDOR (NOLOCK) WHERE CODIGO = @CODIGO;
	END
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Update Vendedor
	-- =============================================
	CREATE PROCEDURE [dbo].[upd_VENDEDOR]
		@CODIGO INT,
		@NOMBRE NVARCHAR(20),
		@APELLIDO NVARCHAR(20),
		@NUMERO_IDENTIFICACION BIGINT,
		@CODIGO_CIUDAD INT
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		UPDATE VENDEDOR 
		SET NOMBRE = @NOMBRE,
		APELLIDO = @APELLIDO,
		NUMERO_IDENTIFICACION = @NUMERO_IDENTIFICACION,
		CODIGO_CIUDAD = @CODIGO_CIUDAD
		WHERE CODIGO = @CODIGO;
	END
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Delete Vendedor
	-- =============================================
	CREATE PROCEDURE [dbo].[del_VENDEDOR]
		@CODIGO INT
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		DELETE VENDEDOR WHERE CODIGO = @CODIGO;
	END
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Listing Vendedor
	-- =============================================
	CREATE PROCEDURE [dbo].[lst_VENDEDOR]		
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		SELECT * FROM VENDEDOR (NOLOCK);
	END
GO