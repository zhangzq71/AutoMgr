CREATE TABLE [dbo].[sale]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[branch_id] INT NOT NULL, 
    [stuff_id] INT NOT NULL, 
    [customer_id] INT NOT NULL, 
    [parts_price] DECIMAL(10, 2) NOT NULL, 
    [express_fee] DECIMAL(6, 2) NULL, 
    [express_id] INT NULL    
    CONSTRAINT [FK_sale_stuff] FOREIGN KEY ([stuff_id]) REFERENCES [staff]([id]), 
    CONSTRAINT [FK_sale_express] FOREIGN KEY ([express_id]) REFERENCES [express]([id]), 
    CONSTRAINT [FK_sale_customer] FOREIGN KEY ([customer_id]) REFERENCES [customer]([id])
)
