CREATE TABLE [dbo].[supplyer]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [company] NVARCHAR(20) NOT NULL, 
    [address] NVARCHAR(50) NULL, 
    [phone] NVARCHAR(20) NULL
)
