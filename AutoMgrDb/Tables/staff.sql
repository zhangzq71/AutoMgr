CREATE TABLE [dbo].[staff]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [branch_id] INT NOT NULL,
	[name] NVARCHAR(10) NOT NULL, 
    [idcard_num] NVARCHAR(25) NULL, 
    [department_id] INT NOT NULL, 
    [role_id] INT NOT NULL, 
    [iccard_num] NVARCHAR(20) NOT NULL, 
    [deleted] BIT NOT NULL DEFAULT 0, 
    [inserted_time] DATETIME NOT NULL , 
    CONSTRAINT [FK_staff_branch] FOREIGN KEY ([branch_id]) REFERENCES [branch]([id]), 
    CONSTRAINT [FK_staff_role] FOREIGN KEY ([role_id]) REFERENCES [role]([id]), 
    CONSTRAINT [FK_staff_department] FOREIGN KEY ([department_id]) REFERENCES [department]([id]),
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'属于那个分部',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'staff',
    @level2type = N'COLUMN',
    @level2name = N'branch_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'身份证号码',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'staff',
    @level2type = N'COLUMN',
    @level2name = N'idcard_num'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'什么职位',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'staff',
    @level2type = N'COLUMN',
    @level2name = N'role_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'分配给此人的iccard号码',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'staff',
    @level2type = N'COLUMN',
    @level2name = N'iccard_num'