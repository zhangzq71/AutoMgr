CREATE TABLE [dbo].[goods_alias]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [goods_id] INT NOT NULL, 
    [alias] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_goods_alias_goods] FOREIGN KEY ([goods_id]) REFERENCES [goods]([id]),
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'别名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'goods_alias',
    @level2type = N'COLUMN',
    @level2name = N'alias'