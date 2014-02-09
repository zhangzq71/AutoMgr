CREATE TABLE [dbo].[customer_contact]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [customer_id] INT NOT NULL, 
    [contact_id] INT NOT NULL, 
    CONSTRAINT [FK_customer_contact_customer] FOREIGN KEY ([customer_id]) REFERENCES [customer]([id]), 
    CONSTRAINT [FK_customer_contact_contact] FOREIGN KEY ([contact_id]) REFERENCES [contact]([id])
)
