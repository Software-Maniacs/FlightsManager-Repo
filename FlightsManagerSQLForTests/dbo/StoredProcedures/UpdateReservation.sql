CREATE PROCEDURE [dbo].[UpdateReservation]
	@ID as NVARCHAR(450),
	@FlightID as NVARCHAR(450)
AS
	UPDATE dbo.Reservation
	SET FlightID = @FlightID
	WHERE ID = @ID
