USE [dbNiis]
GO

CREATE VIEW [dbo].[NiisIbdProperty]
AS
SELECT        U_ID AS Id, TYPE_ID AS Type, GOS_NUMBER_11 AS ProtectionNumber, REQ_DATE_22 AS RegistrationDate, dbo.NiisIbdGetNotNullValue(NAME_540_RU, NAME_540_EN, NAME_540_KZ) AS Name, ISNULL(STZ17, STZ176) 
                         AS ValidityDate
FROM            dbo.BT_BASE_PATENT
WHERE        (TYPE_ID IN (1, 2, 3, 4, 5, 6, 7))
GO