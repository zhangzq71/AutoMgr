CREATE TABLE [dbo].[vehicle]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [car_num] NVARCHAR(15) NOT NULL, 
    [engine_num] NVARCHAR(20) NOT NULL, 
    [frame_num] NVARCHAR(20) NOT NULL, 
    [brand] NVARCHAR(10) NOT NULL, 
    [model] NVARCHAR(10) NOT NULL, 
    [customer_id] INT NOT NULL, 
    [photo] IMAGE NULL, 
    CONSTRAINT [FK_vehicle_customer] FOREIGN KEY ([customer_id]) REFERENCES [customer]([id])
)
