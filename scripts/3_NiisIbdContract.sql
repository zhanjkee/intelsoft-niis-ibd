USE [dbNiis]
GO

CREATE VIEW [dbo].[NiisIbdContract]
AS
SELECT ROW_NUMBER() OVER(ORDER BY [P].[U_ID] ASC) AS [Id]
	  ,[P].[U_ID] AS [ContractId]
	  ,[Owner].[Xin] AS [Xin]
	  ,[Owner].[PatentHolderRu] AS [Name]
	  ,[R].[flChildDocId] AS [PropertyId]
	  ,[dbo].[FUNC_PATENT_STORONA2_XIN]([P].[U_ID]) AS [AssigneeXin]
	  ,[dbo].[FUNC_PATENT_STORONA2]([P].[U_ID]) AS [AssigneeName]
      ,[P].[GOS_NUMBER_11] AS [ContractNumber]
      ,[P].[REQ_DATE_22] AS [ContractRegistrationDate]
	  ,ISNULL([P].[SUBTYPE_ID], [P].[TYPE_ID]) AS [TypeId]
      ,[P].[STZ17] AS [ContractValidityDate]
	  ,ISNULL([P].[date_create], [P].[REQ_DATE_22]) AS [CreatedDate]
  FROM [dbNiis].[dbo].[BT_BASE_PATENT] AS [P]
  INNER JOIN [dbNiis].[dbo].[RF_PAT_PAT] AS [R]
  ON [P].[U_ID] = [R].[flParentDocId]
  INNER JOIN [dbNiis].[dbo].[RefPatentPatentHolders] AS [Owner]
  ON [Owner].[PATENT_ID] = [R].[flChildDocId]
  WHERE [P].[TYPE_ID] = 72 AND
		[P].[GOS_NUMBER_11] IS NOT NUll AND
		[P].[GOS_DATE_11] IS NOT NULL AND
		[P].[DBY] IS NOT NULL
GO


