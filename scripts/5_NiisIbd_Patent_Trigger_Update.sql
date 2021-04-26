USE [dbNiis]
GO

CREATE TRIGGER NiisIbd_Update
ON BT_BASE_PATENT
AFTER UPDATE
AS
DECLARE @id INT,
		@typeId INT,
        @gosNumber NVARCHAR(MAX),
		@gosDate DATE

SELECT 
@id = [U_ID],
@gosNumber = [GOS_NUMBER_11],
@gosDate = [GOS_DATE_11],
@typeId = [TYPE_ID]
FROM INSERTED
IF (@typeId IN (1,2,3,4,5,6,7,72) AND @gosNumber IS NOT NULL OR @gosNumber <> '' AND @gosDate IS NOT NULL)
BEGIN
	EXEC [dbo].[NiisIbdCreateContractRequest] @id;
END