CREATE TABLE [dbo].[tweet]
(
	[tweet_id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] BIGINT NOT NULL, 
    [user_device_id] INT NOT NULL, 
    [tweet_content] NVARCHAR(50) NOT NULL, 
    [twitted_by] BIGINT NOT NULL
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