USE [dmab0918_1074178]
GO

DECLARE @Id int = 3
DECLARE @Name varchar(50) = 'Bob Bobson'
DECLARE @Phone varchar(50) = '12349999'
DECLARE @Email varchar(50) = 'Updated@mail.com'
DECLARE @RowVer timestamp = (SELECT RowVer FROM Employee WHERE Id = 3)

EXECUTE [dbo].[spEmployee_Update] 
   @Id
  ,@Name
  ,@Phone
  ,@Email
  ,@RowVer
GO


