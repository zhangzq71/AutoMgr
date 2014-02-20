CREATE TABLE [dbo].[goods]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL, 
    [barcode] NVARCHAR(50) NOT NULL, 
    [unit] NVARCHAR(6) NOT NULL, 
    [price] DECIMAL(8, 2) NOT NULL, 
    [brand] NVARCHAR(20) NULL, 
    [origin] NVARCHAR(50) NULL, 
    [model] NVARCHAR(50) NULL, 
    [limit] REAL NULL, 
    [length] REAL NULL, 
    [width] REAL NULL, 
    [height] REAL NULL, 
    [weight] REAL NULL, 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'这是公开的销售价',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单位',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'unit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'品牌',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'brand'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'产地',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'origin'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'适用车型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'model'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'库存下限数量，以unit为单位',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'limit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'货物长度，单位米',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'length'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'货物宽度，单位米',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'width'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'货物高度，单位米',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'height'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'货物重量，单位公斤',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods',
    @level2type = N'COLUMN',
    @level2name = N'weight'