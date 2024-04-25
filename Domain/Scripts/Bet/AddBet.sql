CREATE PROCEDURE [dbo].[AddBet] (@UserId INT, @BetNumber INT, @BetTime DATETIME)
AS
BEGIN
  DECLARE @SlotTimeHourId INT
  
  SET @SlotTimeHourId = DATEDIFF(HOUR, '2000-01-01 00:00:00', GETDATE()) + 1

  IF NOT EXISTS (SELECT 1 FROM Bets WHERE UserId = @UserId AND SlotTimeHourId = @SlotTimeHourId)
  BEGIN
	  INSERT INTO Bets (UserId, BetNumber, BetTime, SlotTimeHourId, CreatedDate, UpdatedDate)
	  VALUES (@UserId, @BetNumber, @BetTime, @SlotTimeHourId, GETDATE(), GETDATE());
  END

END;