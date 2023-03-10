/****** Script for SelectTopNRows command from SSMS  ******/
SELECT
 [vis_Visita_int_PK] IDVISITA,
 vis_DataInicio_dtm DATA_INICIO_VISITAR,
 vis_DataFinalizacao_dtm DATA_FINAL_VISITA,
 vis_Data_dtm DATA_VISITA,
 vis_NumProdutosVisita_int NUMERO_DE_PRODUTOS_VISITA,
 tjf_TipoJustificativa_int_FK TIPO_JUSTIFICATIVA,
 vis_LatitudeInicio_num LATITUDE_INICIO_VISITA,
 vis_LatitudeFinalizacao_num LATITUDE_FINAL_VISITA,
 vis_LongitudeInicio_num LONGITUDE_INICIO_VISITA,
 vis_LongitudeFinalizacao_num LONGITUDE_FINAL_VISITA,
 CASE WHEN [vis_StatusVisita_ind]=0 THEN 'NÃO'ELSE 'SIM' END [FOI VISITADO],
 pro_Promotor_int_FK ID_PROMOTOR,
  pro_Promotor_chr NOME_PROMOTOR,
  loj_Loja_int_FK ID_LOJA
   ,loj_Loja_chr NOME_LOJA
   ,[prd_Produto_int_FK]ID_PRODUTO
    ,prd_Descricao_chr DESCRICAO_PRODUTO
    ,CASE WHEN[vsp_Encontrado_ind]=0 THEN 'NÃO' ELSE 'SIM' END [PRODUTO ENCONTRADO]
    ,[vsp_Preco_cur] PREÇO_PRODUTO
    , CASE WHEN [vsp_VisualizouEstoque_ind]=0 THEN 'NAO' ELSE 'SIM' END [ VISUALIZOU ESTOQUE]
    ,[vsp_Estoque_int] ESTOQUE
    ,[vsp_Data_dtm] DATA
    ,[vsp_StatusPesquisa_ind] STATUS_PESQUISA
      ,[vsp_StatusPergunta_ind] STATUS_PERGUNTA
      ,[jrp_JustificativaRuptura_int_FK] JUSTIFICATIVA_RUPTURA
      ,prg.prg_Pergunta_int_PK ID_PERGUNTA,
      prg.prg_Pergunta_chr DESCRIÇAO_PERGUNTA,
    -- vir_ItemResposta_int,
      vir_Resposta_chr DESCRICAO_REPOSTA
       FROM XMPromotores_Predilecta.dbo.TB_REP_VisitaProduto_vsp vsp
  INNER JOIN TB_REP_Visita_vis vis ON vsp.vis_Visita_int_FK=vis.vis_Visita_int_PK AND vis.emp_Empresa_int_FK = vsp.emp_Empresa_int_FK
  INNER JOIN TB_REP_Loja_loj loj ON vis.loj_Loja_int_FK= loj.loj_Loja_int_PK AND vis.emp_Empresa_int_FK= loj.emp_Empresa_int_FK
  INNER JOIN TB_REP_Produto_prd prd ON vsp.prd_Produto_int_FK = prd.prd_Produto_int_PK AND vsp.emp_Empresa_int_FK =prd.emp_Empresa_int_FK
  INNER JOIN TB_REP_VisitaResposta_vir vir ON vis.vis_Visita_int_PK=vir.vis_Visita_int_FK AND  vir.emp_Empresa_int_FK=vis.emp_Empresa_int_FK AND vir_TipoEntidade_ind=1
  INNER JOIN TB_REP_Pergunta_prg prg ON vir.prg_Pergunta_int_FK= prg.prg_Pergunta_int_PK AND prg.emp_Empresa_int_FK= vir.emp_Empresa_int_FK  
  INNER JOIN TB_REP_Promotor_pro pro ON pro.pro_Promotor_int_PK = vis.pro_Promotor_int_FK AND pro.emp_Empresa_int_FK= vis.emp_Empresa_int_FK
  WHERE loj_Loja_int_FK IN(377,459,119,464,197,85,213,69,249,325,139,292,93
,495,53,315,429,136,29,102,70,205,14,323,366,500,412,422,482,159,411,413,99,304,142,288,
13,37,380,403,477,71,407,441,335,337,160,479,338,129,91,430,434,355,57,212,12,60,307,426,250,
384,266,182,358,164,485,341,472,332,63,352,168,252,507,282,298,52,108,66,4, 47,264,408,328,192,62,243,9,
130,435,16,444,476,450,428,360,363,170,61,92,89,200,202,204,217,206,208,214,209,211,210,216,241,218,219,221,
223,224,225,226,227,228,230,231,232,233,234,235,236,237,238,239,240,152,506,406,299,262,3,6,98,465,20,110,504,
502,505,508,191,163,276,503,305,378,368,470,327,7,111,45,405,370,404,469,329,300,364,178,175,121,21,357,48,427,
483,452,137,361,320,455,90,445,418,461,437,161) 
 AND prd.prd_Produto_int_PK = vir.vir_Referencia_int_FK