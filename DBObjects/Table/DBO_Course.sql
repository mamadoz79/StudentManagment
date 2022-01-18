IF OBJECT_ID('dbo.Course') is null
CREATE TABLE dbo.Course(
	CourseID bigint not null,
	[Name] nvarchar(256) not null,
	TeacherRef bigint not null,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifier] [bigint] NOT NULL,
	[LastModificationDate] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL
) on [primary]
GO
If not Exists (select 1 from sys.objects where name = 'PK_DBO_CourseID')
ALTER TABLE [DBO].[Course] ADD  CONSTRAINT [PK_DBO_CourseID] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
) ON [PRIMARY]
GO
If not Exists (select 1 from sys.objects where name = 'FK_DBO_Course_TeacherRef')
ALTER TABLE [DBO].[Course]  
ADD CONSTRAINT [FK_DBO_Course_TeacherRef] 
  FOREIGN KEY([TeacherRef])
  REFERENCES [GNR3].[Party] ([PartyID])
Go 
If not Exists (select 1 from sys.objects where name = 'FK_DBO_Course_Creator')
ALTER TABLE [DBO].[Course]  ADD  CONSTRAINT [FK_DBO_Course_Creator] FOREIGN KEY([Creator])
REFERENCES [SYS3].[User] ([UserID])

GO
If not Exists (select 1 from sys.objects where name = 'FK_DBO_Course_LastModifier')
ALTER TABLE [DBO].[Course]  ADD  CONSTRAINT [FK_DBO_Course_LastModifier] FOREIGN KEY([LastModifier])
REFERENCES [SYS3].[User] ([UserID])

GO