CREATE TABLE [dbo].[inventory]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[branch_id] INT NOT NULL, 
    [date] DATETIME NOT NULL, 
    [staff_id] INT NOT NULL, 
    CONSTRAINT [FK_inventory_branch] FOREIGN KEY ([branch_id]) REFERENCES [branch]([id]), 
    CONSTRAINT [FK_inventory_staff] FOREIGN KEY ([staff_id]) REFERENCES [staff]([id]),
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'盘点日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'inventory',
    @level2type = N'COLUMN',
    @level2name = N'date'