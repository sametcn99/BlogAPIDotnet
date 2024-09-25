# Mock Query

```sql
BEGIN TRANSACTION;

DECLARE @PostIds TABLE (Id INT);

INSERT INTO [BlogAPIDb].[dbo].[Posts] ([Title], [Content], [CreatedAt])
OUTPUT inserted.Id INTO @PostIds
VALUES
('Post 1 Title', 'This is the content for Post 1.', GETDATE()),
('Post 2 Title', 'This is the content for Post 2.', GETDATE()),
('Post 3 Title', 'This is the content for Post 3.', GETDATE()),
('Post 4 Title', 'This is the content for Post 4.', GETDATE()),
('Post 5 Title', 'This is the content for Post 5.', GETDATE()),
('Post 6 Title', 'This is the content for Post 6.', GETDATE()),
('Post 7 Title', 'This is the content for Post 7.', GETDATE()),
('Post 8 Title', 'This is the content for Post 8.', GETDATE()),
('Post 9 Title', 'This is the content for Post 9.', GETDATE()),
('Post 10 Title', 'This is the content for Post 10.', GETDATE()),
('Post 11 Title', 'This is the content for Post 11.', GETDATE()),
('Post 12 Title', 'This is the content for Post 12.', GETDATE()),
('Post 13 Title', 'This is the content for Post 13.', GETDATE()),
('Post 14 Title', 'This is the content for Post 14.', GETDATE()),
('Post 15 Title', 'This is the content for Post 15.', GETDATE()),
('Post 16 Title', 'This is the content for Post 16.', GETDATE()),
('Post 17 Title', 'This is the content for Post 17.', GETDATE()),
('Post 18 Title', 'This is the content for Post 18.', GETDATE()),
('Post 19 Title', 'This is the content for Post 19.', GETDATE()),
('Post 20 Title', 'This is the content for Post 20.', GETDATE());

INSERT INTO [BlogAPIDb].[dbo].[Comments] ([Content], [CreatedAt], [PostId], [CreatedBy])
VALUES
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserA'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserB'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserC'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserD'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserE'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserF'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserG'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserH'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserI'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserJ'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserK'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserL'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserM'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserN'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserO'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserP'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserQ'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserR'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserS'),
('This is a comment for a random post.', GETDATE(), (SELECT TOP 1 Id FROM @PostIds ORDER BY NEWID()), 'UserT');

COMMIT TRANSACTION;

```
