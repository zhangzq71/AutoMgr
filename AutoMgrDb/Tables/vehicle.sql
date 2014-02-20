CREATE TABLE [dbo].[vehicle]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [car_num] NVARCHAR(15) NOT NULL, 
    [engine_num] NVARCHAR(20) NOT NULL, 
    [frame_num] NVARCHAR(20) NOT NULL, 
    [brand] NVARCHAR(10) NOT NULL, 
    [model] NVARCHAR(10) NOT NULL, 
    [customer_id] INT NOT NULL, 
    CONSTRAINT [FK_vehicle_customer] FOREIGN KEY ([customer_id]) REFERENCES [customer]([id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'车架号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'vehicle',
    @level2type = N'COLUMN',
    @level2name = N'frame_num'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'发动机号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'vehicle',
    @level2type = N'COLUMN',
    @level2name = N'engine_num'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'车牌号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'vehicle',
    @level2type = N'COLUMN',
    @level2name = N'car_num'