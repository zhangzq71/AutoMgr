CREATE TABLE [dbo].[repair_photo]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [repair_id] INT NOT NULL, 
    [photo] IMAGE NOT NULL, 
    CONSTRAINT [FK_repair_photo_repair] FOREIGN KEY ([repair_id]) REFERENCES [repair]([id]),
)
