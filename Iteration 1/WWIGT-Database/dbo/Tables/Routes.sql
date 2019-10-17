CREATE TABLE [dbo].[Routes]
(
	[Id] INT IDENTITY (1,1) NOT NULL , 
    [UserId] NVARCHAR(128) NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Trips_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id])
)
