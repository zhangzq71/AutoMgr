CREATE TABLE [dbo].[sale_detail]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [sale_id] INT NOT NULL, 
    [goods_id] INT NOT NULL, 
    [price] DECIMAL(10, 2) NOT NULL, 
    [order_quantity] DECIMAL(10, 2) NOT NULL, 
    [stock_quantity] DECIMAL(10, 2) NULL, 
    [packet] BIT NOT NULL DEFAULT 0, 
    [shelf_io_id] INT NULL, 
    CONSTRAINT [FK_sale_detail_sale] FOREIGN KEY ([sale_id]) REFERENCES [sale]([id]), 
    CONSTRAINT [FK_sale_detail_goods] FOREIGN KEY ([goods_id]) REFERENCES [goods]([id]), 
    CONSTRAINT [FK_sale_detail_shelf_io] FOREIGN KEY ([shelf_io_id]) REFERENCES [shelf_io]([id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'销售单价',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'sale_detail',
    @level2type = N'COLUMN',
    @level2name = N'price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'销售数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'sale_detail',
    @level2type = N'COLUMN',
    @level2name = N'order_quantity'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库实出数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'sale_detail',
    @level2type = N'COLUMN',
    @level2name = N'stock_quantity'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否已装箱',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'sale_detail',
    @level2type = N'COLUMN',
    @level2name = N'packet'