CREATE TABLE [dbo].[user_device]
(
	[user_device_id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
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