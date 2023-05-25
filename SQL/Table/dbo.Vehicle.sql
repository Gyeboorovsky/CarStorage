IF EXISTS (SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Vehicle')
DROP TABLE dbo.Vehicle;
GO

Create table dbo.Vehicle(
  Id int IDENTITY(1,1) PRIMARY KEY,
  Brand nvarchar(max) not null,
  Model nvarchar(max) not null,
  BodyTypeId int not null,
  RegistrationNumber nvarchar(max) not null,
  VIN nvarchar(max) not null,
  ProductionYear int not null,
  Mileage int not null,
  Image varbinary(max) not null
)