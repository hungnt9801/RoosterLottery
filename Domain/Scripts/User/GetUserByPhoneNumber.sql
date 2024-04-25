CREATE PROCEDURE [dbo].[GetUserByPhoneNumber] (@PhoneNumber NVARCHAR(15))
AS
BEGIN
  SELECT top 1 * FROM LotteryUsers WHERE PhoneNumber = @PhoneNumber;
END;


