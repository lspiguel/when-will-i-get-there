CREATE TABLE [dbo].[Commutes]
(
	[Id] INT IDENTITY(1, 1) NOT NULL, 
	[RouteId] INT NOT NULL, 
    [Start] DATETIME NOT NULL, 
    [Stop] DATETIME NULL,
	PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Commutes_Routes_Id_UserId] FOREIGN KEY ([RouteId]) REFERENCES [Routes]([Id])
)
