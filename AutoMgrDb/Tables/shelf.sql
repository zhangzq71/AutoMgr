CREATE TABLE [dbo].[shelf]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [branch_id] INT NOT NULL, 
    [barcode] VARCHAR(50) NOT NULL, 
	[name] NVARCHAR(20) NOT NULL,
    [goods_id] INT NOT NULL, 
    [quantity] DECIMAL(10, 2) NOT NULL, 
    CONSTRAINT [FK_shelf_branch] FOREIGN KEY ([branch_id]) REFERENCES [branch]([id]), 
    CONSTRAINT [FK_shelf_goods] FOREIGN KEY ([goods_id]) REFERENCES [goods]([id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'属于那个分部的',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'shelf',
    @level2type = N'COLUMN',
    @level2name = N'branch_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'存放货物的ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'shelf',
    @level2type = N'COLUMN',
    @level2name = N'goods_id'