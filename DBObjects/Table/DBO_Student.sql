
If Object_ID('dbo.Student') Is Null
CREATE TABLE [dbo].[Student](
	StudentID bigint NOT NULL,
	Code nvarchar(100) NOT NULL, 
	FirstName nvarchar(500) NOT NULL,
	LastName nvarchar(500) NOT NULL,
	BirthDate DateTime NOT NULL,
	Gender int NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]

Go

If not Exists (select 1 from sys.objects where name = 'PK_DBO_Student')
  ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [PK_DBO_Student] PRIMARY KEY CLUSTERED ([StudentID] ASC) ON [PRIMARY]

GO



