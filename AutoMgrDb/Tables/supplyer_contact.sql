CREATE TABLE [dbo].[supplyer_contact]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [supplyer_id] INT NOT NULL, 
    [contact_id] INT NOT NULL, 
    CONSTRAINT [FK_supplyer_contact_supplyer] FOREIGN KEY ([supplyer_id]) REFERENCES [supplyer]([id]), 
    CONSTRAINT [FK_supplyer_contact_contact] FOREIGN KEY ([contact_id]) REFERENCES [contact]([id])
)
