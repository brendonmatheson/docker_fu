
CREATE DATABASE Tasks ON
	PRIMARY (NAME = 'Tasks_Data', FILENAME = 'C:\Data\Tasks.MDF')
	LOG ON (NAME = 'Tasks_Log', FILENAME = 'C:\Data\Tasks.LDF');
	
USE Tasks;

CREATE TABLE Task(
	TaskId UNIQUEIDENTIFIER NOT NULL,
	Name VARCHAR(250) NOT NULL,
	Completed BIT NOT NULL,
	PRIMARY KEY(TaskId));

INSERT INTO
	Task(TaskId, Name, Completed)
VALUES
	(NEWID(), 'Buy milk', 0),
	(NEWID(), 'Pay phone bill', 0),
	(NEWID(), 'Call stockbroker', 1);
