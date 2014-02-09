CREATE TABLE [dbo].[repair_item]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(20) NOT NULL, 
    [warking_hour] DECIMAL(6, 2) NULL, 
    [price] DECIMAL(8, 2) NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'维修项目名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair_item',
    @level2type = N'COLUMN',
    @level2name = N'name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工时',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair_item',
    @level2type = N'COLUMN',
    @level2name = N'warking_hour'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'维修价格',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair_item',
    @level2type = N'COLUMN',
    @level2name = N'price'
GO
