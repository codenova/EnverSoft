

--Create database
CREATE DATABASE EnverSoft_BD


--Create CompanyDetail table
DROP TABLE IF EXISTS CompanyDetail
GO
CREATE TABLE CompanyDetail (
    CompanyDetailID  INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
	Telephone NVARCHAR(255) NOT NULL
);


--Save CompanyDetail sp
DROP PROCEDURE IF EXISTS [dbo].[Save_CompanyDetail]
GO

CREATE PROCEDURE [dbo].[Save_CompanyDetail]
(
	@name nvarchar(250),
	@telephone nvarchar(250)
)
AS
BEGIN

SET NOCOUNT ON;
    INSERT INTO CompanyDetail ([Name],[Telephone]) VALUES(@name,@telephone)

END
GO


--Search CompanyDetail telephone
DROP PROCEDURE IF EXISTS [dbo].[Search_CompanyDetail]
GO
CREATE PROCEDURE [dbo].[Search_CompanyDetail]
(
	@name nvarchar(250)
)
AS
BEGIN

SET NOCOUNT ON;
    SELECT [Telephone] FROM  CompanyDetail WHERE [Name] = @name

END
GO