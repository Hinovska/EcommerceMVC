USE [Ecommerce]
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Insert Ciudad
	-- =============================================
	CREATE PROCEDURE [dbo].[ins_CIUDAD]
		@CODIGO INT OUTPUT,
		@DESCRIPCION NVARCHAR(20)
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		INSERT INTO CIUDAD (DESCRIPCION) VALUES (@DESCRIPCION);
		SELECT @CODIGO = @@IDENTITY;
	END
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Get Ciudad
	-- =============================================
	CREATE PROCEDURE [dbo].[get_CIUDAD]
		@CODIGO INT
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		SELECT * FROM CIUDAD (NOLOCK) WHERE CODIGO = @CODIGO;
	END
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Update Ciudad
	-- =============================================
	CREATE PROCEDURE [dbo].[upd_CIUDAD]
		@CODIGO INT,
		@DESCRIPCION NVARCHAR(20)
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		UPDATE CIUDAD SET DESCRIPCION = @DESCRIPCION WHERE CODIGO = @CODIGO;
	END
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Delete Ciudad
	-- =============================================
	CREATE PROCEDURE [dbo].[del_CIUDAD]
		@CODIGO INT
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		DELETE CIUDAD WHERE CODIGO = @CODIGO;
	END
GO
	-- =============================================
	-- Author:		Andres Gomez
	-- Create date: 25/03/2020
	-- Description:	Listing Ciudad
	-- =============================================
	CREATE PROCEDURE [dbo].[lst_CIUDAD]		
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		SELECT * FROM CIUDAD (NOLOCK);
	END
GO