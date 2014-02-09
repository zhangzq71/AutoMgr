CREATE TABLE [dbo].[repair_parts]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [repair_id] INT NOT NULL, 
    [goods_id] INT NOT NULL, 
    [price] DECIMAL(10, 2) NOT NULL, 
    [quote_only] BIT NOT NULL DEFAULT 0, 
    [shelf_io_id] INT NULL, 
    CONSTRAINT [FK_repair_parts_repair] FOREIGN KEY ([repair_id]) REFERENCES [repair]([id]), 
    CONSTRAINT [FK_repair_parts_goods] FOREIGN KEY ([goods_id]) REFERENCES [goods]([id]), 
    CONSTRAINT [FK_repair_parts_shelf_io] FOREIGN KEY ([shelf_io_id]) REFERENCES [shelf_io]([id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'只作报价用',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair_parts',
    @level2type = N'COLUMN',
    @level2name = N'quote_only'