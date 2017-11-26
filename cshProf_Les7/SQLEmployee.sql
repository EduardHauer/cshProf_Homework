﻿CREATE TABLE[dbo].[Employee]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR(MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Age] NVARCHAR(MAX) NOT NULL,
	[Salary] NVARCHAR(MAX) NOT NULL,
	[DepartmentId] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT[PK_dbo.Employee] PRIMARY KEY CLUSTERED([Id] ASC)
);