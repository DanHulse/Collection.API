CREATE ROLE [Collection Data Fetch]
	AUTHORIZATION [dbo];

GO
ALTER ROLE [Collection Data Fetch] ADD MEMBER [collection_app];