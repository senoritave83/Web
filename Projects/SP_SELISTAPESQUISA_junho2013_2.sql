/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [IdModalidade]
      ,[DescricaoModalidade]
  FROM [ITC_Producao_27082009].[dbo].[TB_Modalidades_mod]
  
  
  alter table [TB_Modalidades_mod] add Ordenacao int
  