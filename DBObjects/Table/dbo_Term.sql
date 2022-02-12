--<<FileName:dbo_term.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('dbo.term') Is Null
CREATE TABLE [dbo].[term](
	[TermID] [bigint] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[TeacherRef] [bigint] NOT NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifier] [bigint] NOT NULL,
	[LastModificationDate] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('dbo.term') and
				[name] = 'ColumnName')
begin
    Alter table dbo.term Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_DBO_TermID')
ALTER TABLE [dbo].[term] ADD  CONSTRAINT [PK_DBO_TermID] PRIMARY KEY CLUSTERED 
(
	[TermID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< FOREIGNKEYS DEFINITION >>--


--<< DROP OBJECTS >>--
