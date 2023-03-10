USE [XMLink_IBT]
GO
/****** Object:  StoredProcedure [dbo].[SP_IBT_XML_WEB_SV_CATEGORIA]    Script Date: 10/30/2012 11:21:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_IBT_XML_WEB_SV_CATEGORIA]
@IDCATEGORIA int,
@IDEMPRESA int,
@CODIGO varchar(20) = NULL,
@CATEGORIA nvarchar(100) = NULL,
@DATACRIADO datetime = NULL
AS
BEGIN

	SET NOCOUNT ON
	
	UPDATE TB_IBT_XML_Categoria_cat
       SET cat_Codigo_chr = @CODIGO,
           cat_Categoria_chr = @CATEGORIA,
           cat_DataSync_dtm = GETDATE(),
           cat_Criado_dtm= @DATACRIADO,
           cat_Ativo_ind = 1
	 WHERE cat_Categoria_int_PK = @IDCATEGORIA
       AND emp_Empresa_int_FK = @IDEMPRESA

	IF @@ROWCOUNT = 0
		BEGIN
			IF @IDCategoria = 0
				BEGIN
					SELECT @IDCATEGORIA = MAX(cat_Categoria_int_PK) FROM TB_IBT_XML_Categoria_cat (NOLOCK) WHERE emp_Empresa_int_FK = @IDEMPRESA
		 			SET @IDCATEGORIA = ISNULL(@IDCATEGORIA, 0) + 1
			 	END


			INSERT INTO TB_IBT_XML_Categoria_cat
				(
				cat_Categoria_int_PK,
				emp_Empresa_int_FK,
				cat_Codigo_chr,
				cat_Categoria_chr,
				cat_DataSync_dtm,
				cat_Criado_dtm,
				cat_Ativo_ind
				)
			VALUES
				(
				@IDCATEGORIA,
				@IDEMPRESA,
				@CODIGO,
				@CATEGORIA,
				GETDATE(),
				@DATACRIADO,
				1
				)

		END

	EXEC SP_IBT_XML_WEB_SE_CATEGORIA @IDCATEGORIA, @IDEMPRESA

END
