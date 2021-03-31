CREATE PROCEDURE [dbo].[DeleteReservation]
	@ID as NVARCHAR(450),
	@FlightID as NVARCHAR(450)
AS
	DELETE FROM dbo.Reservation WHERE ID = @ID
	AND FlightID = @FlightID

