CREATE TABLE [dbo].[Commutes]
(
	[Id] INT IDENTITY(1, 1) NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [Start] DATETIME NOT NULL, 
    [Stop] DATETIME NULL,
	PRIMARY KEY ([Id], [UserId]),
    CONSTRAINT [FK_Commutes_Routes_Id_UserId] FOREIGN KEY ([Id], [UserId]) REFERENCES [Routes]([Id], [UserId])
)
