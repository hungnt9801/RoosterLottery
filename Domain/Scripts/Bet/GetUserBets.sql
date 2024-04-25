CREATE PROCEDURE GetUserBets(@UserId INT)
AS
BEGIN
    SELECT LU.Name, LU.DateOfBirth, LU.PhoneNumber, B.BetTime, B.BetNumber, DOL.WinningNumber
    FROM LotteryUsers LU
    JOIN Bets B ON B.UserId = LU.Id
    JOIN DialOpenLotteries DOL ON DOL.SlotTimeHourId = B.SlotTimeHourId
    WHERE LU.ID = @UserId
END