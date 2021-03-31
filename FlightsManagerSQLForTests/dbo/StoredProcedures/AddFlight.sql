CREATE PROCEDURE [dbo].[AddFlight]
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
	INSERT INTO dbo.Flight (AirplaneID, DestinationFrom,
	DestinationTo, TakesOff, Landing, AirplaneType, PilotName, Capacity,
	BusinessClassCapacity)
	VALUES (@AirplaneID, @DestinationFrom,
	@DestinationTo, @TakesOff, @Landing, @AirplaneType, @PilotName, @Capacity,
	@BusinessClassCapacity)

