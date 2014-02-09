CREATE TABLE [dbo].[repair_item_detail]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [repair_id] INT NOT NULL, 
    [cate_id] INT NULL, 
    [item_id] INT NOT NULL, 
    [department_id] INT NOT NULL, 
    [start_time] DATETIME NULL, 
    [end_time] DATETIME NULL, 
    CONSTRAINT [FK_repair_item_detail_repair] FOREIGN KEY ([repair_id]) REFERENCES [repair]([id]), 
    CONSTRAINT [FK_repair_item_detail_repair_cate] FOREIGN KEY ([cate_id]) REFERENCES [repair_cate]([id]), 
    CONSTRAINT [FK_repair_item_detail_repair_item] FOREIGN KEY ([item_id]) REFERENCES [repair_item]([id]), 
    CONSTRAINT [FK_repair_item_detail_department] FOREIGN KEY ([department_id]) REFERENCES [department]([id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'如果选了cate，将cate中的各项写到这里',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair_item_detail',
    @level2type = N'COLUMN',
    @level2name = N'item_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'如果维修项目不在类别中选取是NULL',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair_item_detail',
    @level2type = N'COLUMN',
    @level2name = N'cate_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'计算班组的开始维修时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair_item_detail',
    @level2type = N'COLUMN',
    @level2name = N'start_time'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'计算班组的结束维修时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'repair_item_detail',
    @level2type = N'COLUMN',
    @level2name = N'end_time'