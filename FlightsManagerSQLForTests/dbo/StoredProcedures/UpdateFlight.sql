CREATE PROCEDURE [dbo].[UpdateFlight]
	@AirplaneID as NVARCHAR(450),
	@PilotName as NVARCHAR (MAX)
AS
	UPDATE dbo.Flight
	SET PilotName = @PilotName
	WHERE AirplaneID = @AirplaneID
