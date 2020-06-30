USE [RabbitLadbon]
GO

/****** Object:  StoredProcedure [dbo].[lfSP_GetData]    Script Date: 2019-02-08 17:59:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Ladbon Fragari>
-- Create date: <19.02.06>
-- Description:	<lfSP_GetData gets the data from the table>
-- =============================================
CREATE PROCEDURE [dbo].[lfSP_GetData]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT  Message, Date FROM [dbo].[lfT_Message]
END
GO

