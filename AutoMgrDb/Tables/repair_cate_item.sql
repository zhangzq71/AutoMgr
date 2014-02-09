CREATE TABLE [dbo].[repair_cate_item]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [cate_id] INT NOT NULL, 
    [item_id] INT NOT NULL, 
    CONSTRAINT [FK_repair_cate_item_repair_cate] FOREIGN KEY ([cate_id]) REFERENCES [repair_cate]([id]), 
    CONSTRAINT [FK_repair_cate_item_repair_item] FOREIGN KEY ([item_id]) REFERENCES [repair_item]([id])
)
