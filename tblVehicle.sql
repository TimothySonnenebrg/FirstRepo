﻿CREATE TABLE [dbo].[tblVehicle]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ColorId] UNIQUEIDENTIFIER NOT NULL, 
    [MakeId] UNIQUEIDENTIFIER NOT NULL, 
    [ModelId] UNIQUEIDENTIFIER NOT NULL, 
    [VIN] NVARCHAR(50) NOT NULL, 
    [Year] INT NOT NULL
)
