# RoosterLottery

1.Kiến trúc source code
Source code được tổ chức theo kiến trúc Clean Architecture + Domain Driven Design
-Client: Tầng xử lý giao diện
-Application: xử lý logic ứng dụng
-Domain: xử lý logic nghiệp vụ
-Infastructure: xử lý database, background job, ...
-WebApi: nhận và trả request từ Client
Ghi chú: ứng dụng sẽ chạy 1 backgroud job trong RoosterLottery.Infastructure/BackgroundJobs để tự động quay và mở số

2.Cài đặt và chạy ứng dụng
-Visual Studio 2022
-.Net 8
-Setting Solution properties -> Multiple startup project: Start Client, WebApi 
-Tạo database trong SQL Server, chỉnh thông tin kết nối  database trong file RoosterLottery.WebApi/appsetting.json 
-Chạy migration để tạo các table cho database
-Chạy tất cả script trong folder RoosterLottery.Domain/Scripts để tạo các store procedure xử lý nghiệp vụ
-F5 để chạy ứng dụng, VS sẽ start đồng thời Client và WebApi

3.Tạo dữ liệu mẫu để test chương trình
Để test nhanh ứng dụng, có thể chạy các script dưới đây để tạo dữ liệu test

--Insert user Sarah Jones
INSERT INTO [dbo].[LotteryUsers]  ([Name], [DateOfBirth] ,[PhoneNumber], [CreatedDate] ,[CreatedBy] ,[UpdatedDate] ,[UpdatedBy])
     VALUES ('Sarah Jones','1993-06-12','0983758971',GETDATE(),'Admin',GETDATE(),'Admin')

--Insert 5 bet of user Sarah Jones
INSERT INTO [dbo].[Bets] ([UserId],[BetNumber],[BetTime],[SlotTimeHourId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])
     VALUES (1,1,'2024-04-24 7:10:10',213156,GETDATE(),'Admin',GETDATE(),'Admin')
INSERT INTO [dbo].[Bets] ([UserId],[BetNumber],[BetTime],[SlotTimeHourId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])
     VALUES (1,2,'2024-04-24 8:10:10',213156,GETDATE(),'Admin',GETDATE(),'Admin')
INSERT INTO [dbo].[Bets] ([UserId],[BetNumber],[BetTime],[SlotTimeHourId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])
     VALUES (1,3,'2024-04-24 9:10:10',213156,GETDATE(),'Admin',GETDATE(),'Admin')
INSERT INTO [dbo].[Bets] ([UserId],[BetNumber],[BetTime],[SlotTimeHourId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])
     VALUES (1,4,'2024-04-24 10:10:10',213156,GETDATE(),'Admin',GETDATE(),'Admin')
INSERT INTO [dbo].[Bets] ([UserId],[BetNumber],[BetTime],[SlotTimeHourId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])
     VALUES (1,5,'2024-04-24 11:10:10',213156,GETDATE(),'Admin',GETDATE(),'Admin')

--Insert 5 open lottery of system with 2 win of Sarah Jones
INSERT INTO [dbo].[DialOpenLotteries]([SlotTimeHourId],[OpenTime],[WinningNumber],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])   
  VALUES(1,'2024-04-24 8:10:10',1,GETDATE(),'Admin',GETDATE(),'Admin')
INSERT INTO [dbo].[DialOpenLotteries]([SlotTimeHourId],[OpenTime],[WinningNumber],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])   
  VALUES(2,'2024-04-24 9:10:10',9,GETDATE(),'Admin',GETDATE(),'Admin')
INSERT INTO [dbo].[DialOpenLotteries]([SlotTimeHourId],[OpenTime],[WinningNumber],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])   
  VALUES(3,'2024-04-24 10:10:10',8,GETDATE(),'Admin',GETDATE(),'Admin')
INSERT INTO [dbo].[DialOpenLotteries]([SlotTimeHourId],[OpenTime],[WinningNumber],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])   
  VALUES(8,'2024-04-24 11:10:10',7,GETDATE(),'Admin',GETDATE(),'Admin')
INSERT INTO [dbo].[DialOpenLotteries]([SlotTimeHourId],[OpenTime],[WinningNumber],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])   
  VALUES(9,'2024-04-24 12:10:10',5,GETDATE(),'Admin',GETDATE(),'Admin')
