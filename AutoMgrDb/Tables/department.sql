CREATE TABLE [dbo].[department]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(20) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'部门名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'department',
    @level2type = N'COLUMN',
    @level2name = N'name'