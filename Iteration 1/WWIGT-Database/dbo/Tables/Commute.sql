CREATE TABLE [dbo].[Commutes]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_Commutes_Routes_Id_UserId] FOREIGN KEY ([Column]) REFERENCES [ToTable]([ToTableColumn])
)
