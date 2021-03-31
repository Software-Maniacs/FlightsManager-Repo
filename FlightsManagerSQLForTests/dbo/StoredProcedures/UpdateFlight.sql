CREATE PROCEDURE [dbo].[UpdateFlight]
	@AirplaneID as INT,
	@PilotName as NVARCHAR (MAX)
AS
	UPDATE dbo.Flight
	SET PilotName = @PilotName
	WHERE AirplaneID = @AirplaneID
