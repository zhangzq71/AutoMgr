CREATE TABLE [dbo].[customer]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [company] NVARCHAR(50) NOT NULL, 
    [address] NVARCHAR(50) NULL, 
    [phone] NVARCHAR(20) NULL 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'公司名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'customer',
    @level2type = N'COLUMN',
    @level2name = N'company'