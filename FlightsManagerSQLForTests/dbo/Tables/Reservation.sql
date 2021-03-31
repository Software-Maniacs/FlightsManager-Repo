CREATE TABLE [dbo].[Reservation] (
    [ID]       NVARCHAR (450) NOT NULL,
    [FlightID] NVARCHAR (450) NULL,
    CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Reservation_Flight_FlightID] FOREIGN KEY ([FlightID]) REFERENCES [dbo].[Flight] ([AirplaneID])
);




GO
CREATE NONCLUSTERED INDEX [IX_Reservation_FlightID]
    ON [dbo].[Reservation]([FlightID] ASC);

