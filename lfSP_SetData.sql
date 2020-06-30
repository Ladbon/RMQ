USE [RabbitLadbon]
GO

/****** Object:  StoredProcedure [dbo].[lfSP_SetData]    Script Date: 2019-02-08 18:00:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Ladbon Fragari>
-- Create date: <19.02.06>
-- Description:	<lfSP_SetData sets the data from the table>
-- =============================================
CREATE PROCEDURE [dbo].[lfSP_SetData]

    @param1 nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO  lfT_Message (Message, Date) 
	VALUES (@param1, GETDATE())
END
GO

