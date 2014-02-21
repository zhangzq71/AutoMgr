CREATE TABLE [dbo].[barcode_goods]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [barcode] VARCHAR(50) NOT NULL, 
    [goods_id] INT NOT NULL, 
    CONSTRAINT [FK_barcode_goods_goods] FOREIGN KEY ([goods_id]) REFERENCES [goods]([id]),
)
