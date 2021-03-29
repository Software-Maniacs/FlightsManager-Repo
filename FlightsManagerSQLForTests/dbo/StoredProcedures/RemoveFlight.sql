CREATE PROCEDURE [dbo].[RemoveFlight]
	@AirplaneID AS NVARCHAR(450),
	@DestinationFrom AS NVARCHAR(MAX),
	@DestinationTo AS NVARCHAR(MAX),
	@TakesOff as DATETIME2(7),
	@Landing as DATETIME2(7),
	@AirplaneType as NVARCHAR(MAX),
	@PilotName as NVARCHAR(MAX),
	@Capacity as INT,
	@BusinessClassCapacity as INT
AS
	DELETE FROM dbo.Flight WHERE AirplaneID = @AirplaneID
	AND DestinationFrom = @DestinationFrom
	AND DestinationTo = @DestinationTo
	AND TakesOff = @TakesOff
	AND Landing = @Landing
	AND AirplaneType = @AirplaneType
	AND PilotName = @PilotName
	AND Capacity = @Capacity
	AND BusinessClassCapacity = @BusinessClassCapacity

