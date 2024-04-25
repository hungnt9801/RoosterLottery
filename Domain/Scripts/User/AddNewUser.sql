
CREATE PROCEDURE [dbo].[AddNewUser] (@Name NVARCHAR(50), @DateOfBirth datetime, @PhoneNumber NVARCHAR(15))
AS
BEGIN
	DECLARE @DateOfBirthDT datetime;
	SET @DateOfBirthDT = CONVERT(DATETIME, @DateOfBirth);

	INSERT INTO LotteryUsers (Name, DateOfBirth, PhoneNumber, CreatedDate, UpdatedDate)
	VALUES (@Name, @DateOfBirth, @PhoneNumber, GETDATE(), GETDATE());

	RETURN 1
END;


