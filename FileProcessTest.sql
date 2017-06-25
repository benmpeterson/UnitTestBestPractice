USE exampledb
GO

CREATE SCHEMA tests
GO

CREATE TABLE tests.FileProcessTest
(
	FileName varchar(255) NULL,
	ExpectedValue [bit] NOT NULL,
	CausesException [bit] NOT NULL,
)
GO

INSERT INTO tests.FileProcessTest
VALUES ('C:\Windows\Regedit.exe', 1, 0);

INSERT INTO tests.FileProcessTest
VALUES ('C:\NotExists.txt', 0, 0);

INSERT INTO tests.FileProcessTest
VALUES (null, 0, 1);

