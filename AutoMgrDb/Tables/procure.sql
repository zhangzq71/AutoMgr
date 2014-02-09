CREATE TABLE [dbo].[procure]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[branch_id] INT NOT NULL,
    [stuff_id] INT NOT NULL, 
    [supplyer_id] INT NOT NULL, 
    [contact_id] INT NOT NULL, 
    [date] DATETIME NOT NULL, 
    [closed] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_procure_branch] FOREIGN KEY ([branch_id]) REFERENCES [branch]([id]), 
    CONSTRAINT [FK_procure_stuff] FOREIGN KEY ([stuff_id]) REFERENCES [stuff]([id]), 
    CONSTRAINT [FK_procure_supplyer] FOREIGN KEY ([supplyer_id]) REFERENCES [supplyer]([id]), 
    CONSTRAINT [FK_procure_contact] FOREIGN KEY ([contact_id]) REFERENCES [contact]([id])
)
