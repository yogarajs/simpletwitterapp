DROP TABLE [dbo].[tweet]
DROP TABLE [dbo].[user_device]
DROP TABLE [dbo].[device_type]
DROP TABLE [dbo].[user]
GO

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

CREATE TABLE [dbo].[device_type]
(
	[device_type_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [device_type_name] NCHAR(10) NOT NULL
)
GO

CREATE TABLE [dbo].[user_device]
(
	[user_device_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] BIGINT NOT NULL, 
    [device_type_id] INT NOT NULL, 
    [device_name] NVARCHAR(50) NOT NULL
)
GO

ALTER TABLE [dbo].[user_device]
ADD CONSTRAINT [FK_user_device_user_user_id_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[user]([user_id])
GO

ALTER TABLE [dbo].[user_device]
ADD CONSTRAINT [FK_device_type_device_type_id_device_type_id] FOREIGN KEY ([device_type_id]) REFERENCES [dbo].[device_type]([device_type_id])
GO

CREATE TABLE [dbo].[tweet]
(
	[tweet_id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] BIGINT NOT NULL, 
    [user_device_id] INT NOT NULL, 
    [tweet_content] NVARCHAR(50) NOT NULL, 
    [twitted_by] BIGINT NOT NULL,
    [tweet_time] DATETIME NOT NULL
)
GO

ALTER TABLE [dbo].[tweet]
ADD CONSTRAINT [FK_tweet_user_user_id_user_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[user]([user_id])
GO

ALTER TABLE [dbo].[tweet]
ADD CONSTRAINT [FK_tweet_user_device_user_device_id_user_device_id] FOREIGN KEY ([user_device_id]) REFERENCES [dbo].[user_device]([user_device_id])
GO

ALTER TABLE [dbo].[tweet]
ADD CONSTRAINT [FK_tweet_user_twitted_by_user_id] FOREIGN KEY ([twitted_by]) REFERENCES [dbo].[user]([user_id])
GO

SET IDENTITY_INSERT [dbo].[user] ON
INSERT INTO [dbo].[user] ([user_id], [username], [password], [first_name], [middle_name], [last_name], [e_mail], [mobile], [state], [country]) VALUES 
(2, N'yogarajs            ', N'4113      ', N'Yogaraj   ', N'          ', N'Shanmugham', N'yogarajs@outlook.com', NULL, NULL, NULL),
(3, N'rajans            ', N'4113      ', N'Rajan   ', N'          ', N'Shanmugham', N'yogarajs@outlook.com', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[user] OFF

SET IDENTITY_INSERT [dbo].[device_type] ON
INSERT INTO [dbo].[device_type] ([device_type_id], [device_type_name]) VALUES (1, N'Desktop   ')
INSERT INTO [dbo].[device_type] ([device_type_id], [device_type_name]) VALUES (2, N'Tab       ')
INSERT INTO [dbo].[device_type] ([device_type_id], [device_type_name]) VALUES (3, N'Mobile    ')
SET IDENTITY_INSERT [dbo].[device_type] OFF
