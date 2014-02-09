CREATE TABLE [dbo].[shelf_io]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[branch_id] INT NOT NULL, 
    [repair_id] INT NULL, 
    [sale_id] INT NULL, 
    [procure_id] INT NULL, 
    [inventory_id] INT NULL, 
    [goods_id] INT NOT NULL, 
    [quantity] DECIMAL(8, 2) NOT NULL, 
    [datetime] DATETIME NOT NULL
    CONSTRAINT [FK_shelf_io_sale] FOREIGN KEY ([sale_id]) REFERENCES [sale]([id]), 
    CONSTRAINT [FK_shelf_io_repair] FOREIGN KEY ([repair_id]) REFERENCES [repair]([id]), 
    CONSTRAINT [FK_shelf_io_procure] FOREIGN KEY ([procure_id]) REFERENCES [procure]([id]), 
    CONSTRAINT [FK_shelf_io_inventory] FOREIGN KEY ([inventory_id]) REFERENCES [inventory]([id]), 
    CONSTRAINT [FK_shelf_io_goods] FOREIGN KEY ([goods_id]) REFERENCES [goods]([id]), 
    CONSTRAINT [FK_shelf_io_branch] FOREIGN KEY ([branch_id]) REFERENCES [branch]([id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'盘点记录',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'shelf_io',
    @level2type = N'COLUMN',
    @level2name = N'inventory_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'进出数量，正数是进，负数是出',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'shelf_io',
    @level2type = N'COLUMN',
    @level2name = N'quantity'