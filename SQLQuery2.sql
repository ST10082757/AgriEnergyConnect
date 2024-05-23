
CREATE TABLE [dbo].[agriEmployee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (11, 101),
	[Name] NVARCHAR(MAX) NULL,
	[Email] NVARCHAR(MAX) NULL,
	[Password] NVARCHAR(MAX) NULL
)

CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (11, 101),
	[Name] NVARCHAR(MAX) NULL,
	[Category] NVARCHAR(MAX) NULL,
	[ProdDate] DATE NULL
)
drop table [dbo].[Products];


CREATE TABLE [dbo].[Farmer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (11, 101),
	[Name] NVARCHAR(MAX) NULL,
	[Email] NVARCHAR(MAX) NULL,
	[Password] NVARCHAR(MAX) NULL,
    CONSTRAINT Fk_product FOREIGN KEY (Id) REFERENCES [dbo].[Products]([Id])

)

CREATE TABLE Roles
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[roleName] NVARCHAR(MAX) NULL,
)
Drop table Roles;