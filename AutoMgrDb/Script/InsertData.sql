/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT [dbo].[branch] ON 
INSERT [dbo].[branch] ([id], [name]) VALUES (1, N'总公司')
INSERT [dbo].[branch] ([id], [name]) VALUES (2, N'增城分公司')
INSERT [dbo].[branch] ([id], [name]) VALUES (3, N'大沥分公司')
INSERT [dbo].[branch] ([id], [name]) VALUES (4, N'湛江分公司')
SET IDENTITY_INSERT [dbo].[branch] OFF

SET IDENTITY_INSERT [dbo].[department] ON 
INSERT [dbo].[department] ([id], [name]) VALUES (1, N'管理部门')
INSERT [dbo].[department] ([id], [name]) VALUES (2, N'仓库')
INSERT [dbo].[department] ([id], [name]) VALUES (3, N'修车接车')
INSERT [dbo].[department] ([id], [name]) VALUES (4, N'销售')
INSERT [dbo].[department] ([id], [name]) VALUES (5, N'采购')
INSERT [dbo].[department] ([id], [name]) VALUES (6, N'修车厂')
SET IDENTITY_INSERT [dbo].[department] OFF

SET IDENTITY_INSERT [dbo].[role] ON 
INSERT [dbo].[role] ([id], [name]) VALUES (1, N'管理员')
INSERT [dbo].[role] ([id], [name]) VALUES (2, N'总经理')
INSERT [dbo].[role] ([id], [name]) VALUES (3, N'部门经理')
INSERT [dbo].[role] ([id], [name]) VALUES (4, N'部门员工')
SET IDENTITY_INSERT [dbo].[role] OFF

SET IDENTITY_INSERT [dbo].[staff] ON
INSERT [dbo].[staff] ([id], [branch_id], [name], [idcard_num], [department_id], [role_id], [iccard_num], [deleted], [inserted_time]) VALUES (1, 1, N'张志强', NULL, 1, 1, N'0000985041', 0, CAST(0x0000A27E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[staff] OFF
