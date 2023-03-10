/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [loj_Loja_int_PK],     
        [emp_Empresa_int_FK]
      ,[cli_Cliente_int_FK]
      ,[loj_Codigo_chr]
      ,[loj_Loja_chr]
      ,[loj_CNPJ_chr]
      ,[loj_IE_chr]
      ,[loj_Endereco_chr]
      ,[loj_Numero_chr]
      ,[loj_Complemento_chr]
      ,[loj_Bairro_chr]
      ,[loj_Cidade_chr]
      ,[loj_UF_chr]
      ,[loj_Cep_chr]
      ,[loj_Contato_chr]
      ,[loj_Cargo_chr]
      ,[loj_Telefone_chr]
      ,[loj_Celular_chr]
      ,[loj_Fax_chr]
      ,[loj_Email_chr]
      ,[tlj_TipoLoja_int_FK]
      ,[loj_Shopping_int_FK]
      ,[vis_UltimaVisita_int_FK]
      ,[loj_DataSync_dtm]
      ,[reg_Regiao_int_FK]
      ,[loj_Status_ind]
      ,[loj_Classificacao_chr]
      ,[loj_Filial_chr]
      ,[loj_RazaoSocial_chr]
      ,[cls_ClassificacaoConsumo_int_FK]
      ,[cls_ClassificacaoLoja_int_FK]
      ,[cat_Segmento_int_FK]
      ,[ope_Operadora_int_FK]
      ,[loj_Tamanho_chr]
      ,[loj_TamanhoEletronicos_chr]
      ,[loj_GerenteConta_chr]
      ,[loj_GerenteLoja_chr]
      ,[loj_ContatoFoto_chr]
      ,[loj_Observacao_chr]
  FROM [XMPromotores_Predilecta].[dbo].[TB_REP_Loja_loj]
  WHERE loj_Loja_int_PK IN(377,459,119,464,197,85,213,69,249,325,139,292,93
,495,53,315,429,136,29,102,70,205,14,323,366,500,412,422,482,159,411,413,99,304,142,288,
13,37,380,403,477,71,407,441,335,337,160,479,338,129,91,430,434,355,57,212,12,60,307,426,250,
384,266,182,358,164,485,341,472,332,63,352,168,252,507,282,298,52,108,66,4, 47,264,408,328,192,62,243,9,
130,435,16,444,476,450,428,360,363,170,61,92,89,200,202,204,217,206,208,214,209,211,210,216,241,218,219,221,
223,224,225,226,227,228,230,231,232,233,234,235,236,237,238,239,240,152,506,406,299,262,3,6,98,465,20,110,504,
502,505,508,191,163,276,503,305,378,368,470,327,7,111,45,405,370,404,469,329,300,364,178,175,121,21,357,48,427,
483,452,137,361,320,455,90,445,418,461,437,161)