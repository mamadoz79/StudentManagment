--<<FileName:dbo_TermCourseCourse.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('dbo.TermCourse') Is Null
CREATE TABLE [dbo].[TermCourse](
	[TermCourseID] [bigint] NOT NULL,
	[TermRef] bigint NOT NULL,
	[CourseRef] [bigint] NOT NULL,
	[Teacher] [nvarchar] (256) NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('dbo.TermCourse') and
				[name] = 'ColumnName')
begin
    Alter table dbo.TermCourse Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_DBO_TermCourseID')
ALTER TABLE [dbo].[TermCourse] ADD  CONSTRAINT [PK_DBO_TermCourseID] PRIMARY KEY CLUSTERED 
(
	[TermCourseID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< FOREIGNKEYS DEFINITION >>--


--<< DROP OBJECTS >>--
