IF NOT EXISTS (SELECT * FROM sys.schemas WHERE SCHEMA_NAME(schema_id) LIKE 'dict')
EXEC('CREATE SCHEMA dict');
GO

IF EXISTS (SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dict' AND name LIKE 'BodyType')
DROP TABLE dict.BodyType;
GO

CREATE TABLE dict.BodyType(
  Id int IDENTITY(1,1) PRIMARY KEY,
  Name nvarchar(max) not null,
  Desription nvarchar(max) not null
)