CREATE TABLE [dbo].[repair]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[branch_id] INT NOT NULL, 
    [recv_stuff_id] INT NOT NULL, 
    [recv_date] DATETIME NOT NULL, 
    [quote_only] BIT NOT NULL DEFAULT 0, 
    [parts_price] DECIMAL(10, 2) NOT NULL DEFAULT 0, 
    [repair_price] DECIMAL(10, 2) NOT NULL DEFAULT 0, 
    [discount] DECIMAL(4, 2) NOT NULL DEFAULT 0, 
    [real_price] DECIMAL(10, 2) NOT NULL DEFAULT 0, 
    [out_date] DATETIME NULL, 
    [vehicle_id] INT NOT NULL,
    CONSTRAINT [FK_repair_stuff] FOREIGN KEY ([recv_stuff_id]) REFERENCES [staff]([id]), 
    CONSTRAINT [FK_repair_vehicle] FOREIGN KEY ([vehicle_id]) REFERENCES [vehicle]([id]), 
    CONSTRAINT [FK_repair_branch] FOREIGN KEY ([branch_id]) REFERENCES [branch]([id]), 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是哪个员工接车',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair',
    @level2type = N'COLUMN',
    @level2name = N'recv_stuff_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'接车时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair',
    @level2type = N'COLUMN',
    @level2name = N'recv_date'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'只是报价，0不是报价，1是报价',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair',
    @level2type = N'COLUMN',
    @level2name = N'quote_only'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'零件费用',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair',
    @level2type = N'COLUMN',
    @level2name = N'parts_price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工时费用',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair',
    @level2type = N'COLUMN',
    @level2name = N'repair_price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'折扣',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair',
    @level2type = N'COLUMN',
    @level2name = N'discount'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'实收',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair',
    @level2type = N'COLUMN',
    @level2name = N'real_price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'出厂日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair',
    @level2type = N'COLUMN',
    @level2name = N'out_date'
GO
