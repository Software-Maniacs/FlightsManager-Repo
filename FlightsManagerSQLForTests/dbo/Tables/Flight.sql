CREATE TABLE [dbo].[Flight] (
    [AirplaneID]            NVARCHAR (450) NOT NULL,
    [DestinationFrom]       NVARCHAR (MAX) NULL,
    [DestinationTo]         NVARCHAR (MAX) NULL,
    [TakesOff]              DATETIME2 (7)  NOT NULL,
    [Landing]               DATETIME2 (7)  NOT NULL,
    [AirplaneType]          NVARCHAR (MAX) NULL,
    [PilotName]             NVARCHAR (MAX) NULL,
    [Capacity]              INT            NOT NULL,
    [BusinessClassCapacity] INT            NOT NULL,
    CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED ([AirplaneID] ASC)
);

