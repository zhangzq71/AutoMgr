CREATE TABLE [dbo].[contact]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(10) NOT NULL, 
    [mobile] VARCHAR(20) NULL, 
    [phone] VARCHAR(20) NULL, 
    [email] VARCHAR(50) NULL
)
