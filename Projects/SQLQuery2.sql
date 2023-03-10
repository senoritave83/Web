USE [XMPromotores]
GO
/****** Object:  StoredProcedure [dbo].[SP_REP_WEB_NV_PROPRIEDADES]    Script Date: 02/05/2013 11:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_REP_WEB_NV_PROPRIEDADES]
@IDEMPRESA   AS INT,
@FILTRO      AS VARCHAR(100) = '',
@IDSTATUS	 as int = 2/*todos*/,
@PAGE        AS INT = 0,
@PAGESIZE    AS INT = 10,
@ORDER       AS VARCHAR(20) = '',		
@DESC        AS BIT = 0
AS
BEGIN
	SET NOCOUNT ON
	
	IF CHARINDEX('%', @FILTRO) = 0
		SET @FILTRO = '%' + @FILTRO + '%'

	CREATE TABLE #LISTA
		(
		INDEX_INT int identity(1,1) NOT NULL, 
		cao_CampoAdicionalOpcao_int_PK int,
		cao_CampoAdicionalOpcao_chr varchar(100) NULL,
		cao_ativo_ind tinyint,
		cao_ordem_int int NULL
		)

	INSERT INTO #LISTA
	
		(  cao_CampoAdicionalOpcao_int_PK,
           cao_CampoAdicionalOpcao_chr,
           cao_ativo_ind ,
           cao_ordem_int 
         )
	SELECT cao_CampoAdicionalOpcao_int_PK IDPropriedade,
           cao_CampoAdicionalOpcao_chr Propriedade,
           cao_ativo_ind IdStatus,
           cao_ordem_int ordem
            FROM TB_REP_CampoAdicionalOpcao_cao cao (NOLOCK)
     WHERE cao.emp_Empresa_int_FK = @IDEMPRESA
       AND (cao_CampoAdicionalOpcao_chr like @FILTRO)
       AND (cao_ativo_ind=1)
          ORDER BY CASE WHEN @DESC = 1 THEN NULL
--                   WHEN @ORDER = 'IDCategoria' THEN RIGHT('0000000000' + CAST(cat_Categoria_int_PK AS VARCHAR), 10)
                   WHEN @ORDER = 'CampoAdicional' THEN cao_CampoAdicionalOpcao_chr
--                   WHEN @ORDER = 'Criado' THEN CONVERT(varchar, cat_Criado_dtm, 120)
--                   WHEN @ORDER = 'Ordem' THEN RIGHT('0000000000' + CAST(cat_Ordem_int AS VARCHAR), 10)
                   ELSE cao_CampoAdicionalOpcao_chr
              END,
 		      CASE WHEN @DESC = 0 THEN NULL
--                   WHEN @ORDER = 'IDCategoria' THEN RIGHT('0000000000' + CAST(cat_Categoria_int_PK AS VARCHAR), 10)
                   WHEN @ORDER = 'CampoAdicional' THEN cao_CampoAdicionalOpcao_chr
--                   WHEN @ORDER = 'Criado' THEN CONVERT(varchar, cat_Criado_dtm, 120)
--                   WHEN @ORDER = 'Ordem' THEN RIGHT('0000000000' + CAST(cat_Ordem_int AS VARCHAR), 10)
                   ELSE cao_CampoAdicionalOpcao_chr
              END DESC


	SELECT @@ROWCOUNT Total

	SELECT cao_CampoAdicionalOpcao_int_PK IDPropriedade,
	       cao_CampoAdicionalOpcao_chr Propriedade,
	       cao_ativo_ind  IdStatus,
	       cao_ordem_int ordem
                 FROM #LISTA TMP (NOLOCK)
	 WHERE INDEX_INT > @PAGE * @PAGESIZE AND (INDEX_INT <= ((@PAGE * @PAGESIZE) + @PAGESIZE) OR @PAGESIZE = 0)
	 ORDER BY INDEX_INT

	DROP TABLE #LISTA

END


