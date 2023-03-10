USE [XMPromotores]
GO
/****** Object:  StoredProcedure [dbo].[SP_REP_WEB_SV_PROPRIEDADE]    Script Date: 02/07/2013 16:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[SP_REP_WEB_SV_PROPRIEDADE]
@IDPROPRIEDADE	int,
@IDEMPRESA		int,
@PROPRIEDADE	varchar(50) = NULL,
@IDSTATUS       int 
 
AS
BEGIN

	SET NOCOUNT ON
	
	IF @IDPROPRIEDADE = 0
	
	BEGIN
	     
	     	declare @Ordem int
			select	@Ordem = max(cao_ordem_int) 
			from	TB_REP_CampoAdicionalOpcao_cao (nolock) 
			where	emp_Empresa_int_fk = @idempresa
			set		@Ordem = isnull(@Ordem,0) + 1

	    
	   
		INSERT INTO TB_REP_CampoAdicionalOpcao_cao
				(
				cad_CampoAdicional_int_FK,
				emp_Empresa_int_FK,
				cao_CampoAdicionalOpcao_chr,
				cao_ativo_ind
				)
			VALUES
				(
				4,
				@IDEMPRESA,
				@PROPRIEDADE,
				1
				)
			SET @IDPROPRIEDADE = @@IDENTITY
		END
		
		ELSE
	
	UPDATE TB_REP_CampoAdicionalOpcao_cao
       SET  cao_CampoAdicionalOpcao_chr = @PROPRIEDADE,
            cao_ativo_ind = @IDSTATUS
           WHERE cao_CampoAdicionalOpcao_int_PK = @IDPROPRIEDADE
       AND emp_Empresa_int_FK = @IDEMPRESA

	

	EXEC [SP_REP_WEB_SE_PROPRIEDADE] @IDPROPRIEDADE, @IDEMPRESA
END




