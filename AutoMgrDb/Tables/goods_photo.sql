CREATE TABLE [dbo].[goods_photo]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [goods_id] INT NOT NULL, 
    [photo] IMAGE NOT NULL, 
    CONSTRAINT [FK_goods_photo_goods] FOREIGN KEY (goods_id) REFERENCES [goods]([id]),
)
