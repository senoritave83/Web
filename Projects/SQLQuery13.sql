USE [XMPromotores]
GO
/****** Object:  StoredProcedure [dbo].[SP_REP_WEB_SE_PROPRIEDADE]    Script Date: 02/05/2013 16:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_REP_WEB_SE_PROPRIEDADE]
@IDPROPRIEDADE AS int,
@IDEMPRESA AS int
AS
BEGIN
	SET NOCOUNT ON

  SELECT cao_CampoAdicionalOpcao_int_PK IDPropriedade
	    ,cao_CampoAdicionalOpcao_chr Propriedade
        ,emp_Empresa_int_FK IDEMPRESA
        ,cao_ativo_ind IdStatus
        ,cao_ordem_int Ordem
	  FROM [TB_REP_CampoAdicionalOpcao_cao] (NOLOCK)
	  WHERE cao_CampoAdicionalOpcao_int_PK = @IDPROPRIEDADE
       AND emp_Empresa_int_FK = @IDEMPRESA
END

