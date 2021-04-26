USE [dbNiis]
GO

CREATE VIEW [dbo].[NiisIbdContractTypes]
AS
SELECT [U_ID] AS [Id]
      ,[NAME_ML_RU] AS [NameRu]
      ,[NAME_ML_KZ] AS [NameKz]
  FROM [dbNiis].[dbo].[SPT_PAT_SUBT]
  WHERE [TYPE_ID] = 72
GO


