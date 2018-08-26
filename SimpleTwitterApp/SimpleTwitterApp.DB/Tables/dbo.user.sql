CREATE TABLE [dbo].[user]
(
	[user_id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [username] NCHAR(20) NOT NULL, 
    [password] NCHAR(10) NOT NULL, 
    [first_name] NCHAR(10) NOT NULL, 
    [middle_name] NCHAR(10) NULL, 
    [last_name] NCHAR(10) NOT NULL, 
    [e_mail] NCHAR(20) NOT NULL, 
    [mobile] NCHAR(10) NULL, 
    [state] NCHAR(10) NULL, 
    [country] NCHAR(10) NULL
)
GO

ALTER TABLE [dbo].[user]
ADD CONSTRAINT UC_user_username UNIQUE (username)
GO