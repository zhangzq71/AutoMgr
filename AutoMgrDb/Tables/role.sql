CREATE TABLE [dbo].[role]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(10) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'分员工，部门负责人，总经理，系统维护员',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'role',
    @level2type = N'COLUMN',
    @level2name = N'name'