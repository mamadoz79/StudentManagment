IF OBJECT_ID('dbo.CourseStudent') is null
CREATE TABLE dbo.CourseStudent
(
    CourseStudentID bigint NOT NULL,
	CourseRef bigint NOT NULL,
	StudentRef bigint NOT NULL,
	Version timestamp NOT NULL
) on [Primary]


GO
If not Exists (select 1 from sys.objects where name = 'PK_DBO_CourseStudentID')
ALTER TABLE [DBO].[CourseStudent] ADD  CONSTRAINT [PK_DBO_CourseStudentID] PRIMARY KEY CLUSTERED 
(
	[CourseStudentID] ASC
) ON [PRIMARY]
GO
If not Exists (select 1 from sys.objects where name = 'FK_DBO_CourseStudent_CourseRef')
ALTER TABLE [DBO].[CourseStudent]  
ADD CONSTRAINT [FK_DBO_CourseStudent_CourseRef] 
  FOREIGN KEY([CourseRef])
  REFERENCES [DBO].[Course] ([CourseID])
Go 

If not Exists (select 1 from sys.objects where name = 'FK_DBO_CourseStudent_StudentRef')
ALTER TABLE [DBO].[CourseStudent]  
ADD CONSTRAINT [FK_DBO_CourseStudent_StudentRef] 
  FOREIGN KEY([StudentRef])
  REFERENCES [DBO].[Student] ([StudentID])
Go 


