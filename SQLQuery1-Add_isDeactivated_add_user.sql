ALTER TABLE UserProfile
ADD IsDeactivated BIT DEFAULT 0;

UPDATE UserProfile
SET IsDeactivated = 0
WHERE Id > 0 
	AND Id <= (SELECT COUNT(Id) FROM UserProfile);

	INSERT INTO UserProfile
	(DisplayName, FirstName, LastName, Email, CreateDateTime, UserTypeId)
VALUES
	('sseals1', 'Suth', 'Seals', 'seals@example.com', SYSDATETIME(), 2);