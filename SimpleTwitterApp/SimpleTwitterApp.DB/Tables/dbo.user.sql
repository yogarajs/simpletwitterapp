CREATE TABLE [dbo].[user]
(
	[user_id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [username] NVARCHAR(20) NOT NULL, 
    [password] NVARCHAR(10) NOT NULL, 
    [first_name] NVARCHAR(10) NOT NULL, 
    [middle_name] NVARCHAR(10) NULL, 
    [last_name] NVARCHAR(10) NOT NULL, 
    [e_mail] NVARCHAR(20) NOT NULL, 
    [mobile] NVARCHAR(10) NULL, 
    [state] NVARCHAR(10) NULL, 
    [country] NVARCHAR(10) NULL
)
GO

ALTER TABLE [dbo].[user]
ADD CONSTRAINT UC_user_username UNIQUE (username)
GO