

CREATE PROCEDURE DialOpenLottery
AS
BEGIN
    DECLARE @SlotTimeHourId INT
	DECLARE @WinningNumber INT
    
	DECLARE @dtCurTime DATETIME
    SET @dtCurTime = GETDATE()

    -- Calculate SlotTimeHourId using the GetSlotTimeHourId function
    SET @SlotTimeHourId = DATEDIFF(HOUR, '2000-01-01 00:00:00', @dtCurTime)

    -- Check if SlotTimeHourId exists in DialOpenLotteries table
    IF NOT EXISTS (SELECT 1 FROM DialOpenLotteries WHERE SlotTimeHourId = @SlotTimeHourId)
    BEGIN
        -- Insert a record with default values into DialOpenLotteries
		SET @WinningNumber = FLOOR(RAND() * 9  + 1) 

        INSERT INTO DialOpenLotteries (SlotTimeHourId, OpenTime, WinningNumber, CreatedDate, UpdatedDate)
        VALUES (@SlotTimeHourId, @dtCurTime, @WinningNumber, GETDATE(), GETDATE())

	END
END;
