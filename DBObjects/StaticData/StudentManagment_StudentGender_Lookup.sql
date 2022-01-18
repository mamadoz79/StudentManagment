DECLARE @system nvarchar (50) = N'dbo'
DECLARE @type nvarchar(500)
DECLARE @token nvarchar (500)

SET @type = 'StudentGender'
SET @token = @system + '|' + @type
EXEC sys3.InitializeLookup @system , @type , @type

EXEC sys3.AddLookupValue @token , 1 , N'مرد' , 1 
EXEC sys3.AddLookupValue @token , 2 , N'زن' , 2 

EXEC sys3.AddLookupTranslation @token , 1 , N'en-us' , N'Male'
EXEC sys3.AddLookupTranslation @token , 2 , N'en-us' , N'Female' 