INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'af704e04-b433-4ed1-b363-74d4f83b8c9e', N'student', N'student', N'10996509-0d06-4829-85cf-e9a7334eca96')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ea2d4de0-fc96-4864-8003-369e68abb76d', N'course_admin', N'course_admin', N'6c6b1ab9-b569-4c1c-aa82-e53ddfc7d65e')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'43b6cc0e-088f-467a-b0a8-7c95d4aceaa1', N'john@students.com', N'JOHN@STUDENTS.COM', N'john@students.com', N'JOHN@STUDENTS.COM', 1, N'AQAAAAEAACcQAAAAENUyZerl1H0MFrcxtNg6ofjFq4QKegEejoGV4qd5PgKZ7VXYWcvm5ccwOlceF4qCyQ==', N'TWVKERNKOT3CIZUN3HOHAQV4GO36GB2H', N'8079ad05-9fce-4696-894b-9dbcb7f5c003', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8a14ca5c-295d-4670-bfda-9a1964914a7f', N'admin@students.com', N'ADMIN@STUDENTS.COM', N'admin@students.com', N'ADMIN@STUDENTS.COM', 1, N'AQAAAAEAACcQAAAAEJU6BOZ+KPAUxkW1h1WaNd7667Y9f6Re7JKdxvQtuL+BhXFPqEURP9gCtENcH53W1g==', N'JPSC54EHFZHYLHCYSXRF4VWUSXJLRJJ2', N'9a18e71e-fb13-4284-bf00-ccaa1c599f3b', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd5019a76-10a9-406c-a1ea-541c5d39892d', N'sam@students.com', N'SAM@STUDENTS.COM', N'sam@students.com', N'SAM@STUDENTS.COM', 1, N'AQAAAAEAACcQAAAAEFRwfInRtbfRi5Xzq5JCDJk/gOO9JWc3dd5PEIsuK0fGLBvMbn8ACbIdkofgBo+mXg==', N'WKYVVFHK74CJD4PCVJIRNOV3JDLX6DRQ', N'c57d1980-9922-49f0-b5c2-04e59c61bd70', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43b6cc0e-088f-467a-b0a8-7c95d4aceaa1', N'af704e04-b433-4ed1-b363-74d4f83b8c9e')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd5019a76-10a9-406c-a1ea-541c5d39892d', N'af704e04-b433-4ed1-b363-74d4f83b8c9e')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8a14ca5c-295d-4670-bfda-9a1964914a7f', N'ea2d4de0-fc96-4864-8003-369e68abb76d')
SET IDENTITY_INSERT [dbo].[Course] ON
INSERT INTO [dbo].[Course] ([Id], [CourseName], [TotalCredits]) VALUES (1, N'Diploma in Multimedia Design Level 6', 120)
INSERT INTO [dbo].[Course] ([Id], [CourseName], [TotalCredits]) VALUES (2, N'Graduate Diploma in Computing Level 7', 120)
INSERT INTO [dbo].[Course] ([Id], [CourseName], [TotalCredits]) VALUES (3, N'Post Graduate Diploma in Electronics Level 8', 240)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT INTO [dbo].[Student] ([Id], [Name], [Email], [Phone]) VALUES (2, N'Samson Kentfff', N'sam@students.com', N'0213458976')
INSERT INTO [dbo].[Student] ([Id], [Name], [Email], [Phone]) VALUES (3, N'John Davis', N'john@students.com', N'0215678901')
INSERT INTO [dbo].[Student] ([Id], [Name], [Email], [Phone]) VALUES (4, N'Garry Houston', N'garry@students.com', N'0213458988')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Enrolment] ON
INSERT INTO [dbo].[Enrolment] ([Id], [StudentId], [CourseId], [StartDate], [EndDate]) VALUES (1, 4, 1, N'2021-03-06 00:00:00', N'2021-12-06 00:00:00')
INSERT INTO [dbo].[Enrolment] ([Id], [StudentId], [CourseId], [StartDate], [EndDate]) VALUES (2, 3, 2, N'2021-03-06 00:00:00', N'2021-12-06 00:00:00')
INSERT INTO [dbo].[Enrolment] ([Id], [StudentId], [CourseId], [StartDate], [EndDate]) VALUES (3, 2, 3, N'2021-03-06 00:00:00', N'2021-12-06 00:00:00')
SET IDENTITY_INSERT [dbo].[Enrolment] OFF
