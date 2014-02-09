CREATE TABLE [dbo].[procure_detail]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [procure_id] INT NOT NULL, 
    [goods_id] INT NOT NULL, 
    [quantity] DECIMAL(10, 2) NOT NULL, 
    [price] DECIMAL(10, 2) NOT NULL, 
    CONSTRAINT [FK_procure_detail_procure] FOREIGN KEY ([procure_id]) REFERENCES [procure]([id]), 
    CONSTRAINT [FK_procure_detail_goods] FOREIGN KEY ([goods_id]) REFERENCES [goods]([id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'采购价',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'procure_detail',
    @level2type = N'COLUMN',
    @level2name = N'price'