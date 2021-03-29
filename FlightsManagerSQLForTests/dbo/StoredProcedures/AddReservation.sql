CREATE PROCEDURE [dbo].[AddReservation]
	@ID as NVARCHAR(450),
	@FlightID as NVARCHAR(450)
AS
	INSERT INTO dbo.Reservation (ID, FlightID)
	VALUES (@ID, @FlightID)

