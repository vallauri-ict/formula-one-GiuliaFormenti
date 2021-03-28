CREATE TABLE [dbo].[TeamResult] (
  [trCode] int IDENTITY(1,1),
  [teamCode] varchar(3) NOT NULL,
  [raceCode] int NOT NULL default 0,
  [resultCode] int NOT NULL default 0,
  PRIMARY KEY ([trCode])
);

INSERT INTO [TeamsResult] VALUES ('MER', 1, 25);
INSERT INTO [TeamsResult] VALUES ('FER', 1, 8);
INSERT INTO [TeamsResult] VALUES ('ATH', 1, 0);
INSERT INTO [TeamsResult] VALUES ('MER', 3, 18);
INSERT INTO [TeamsResult] VALUES ('FER', 3, 25);
INSERT INTO [TeamsResult] VALUES ('ATH', 3, 23);
INSERT INTO [TeamsResult] VALUES ('MER', 9, 25);
INSERT INTO [TeamsResult] VALUES ('FER', 9, 15);
INSERT INTO [TeamsResult] VALUES ('ATH', 9, 19);
INSERT INTO [TeamsResult] VALUES ('MER', 11, 15);
INSERT INTO [TeamsResult] VALUES ('FER', 11, 25);
INSERT INTO [TeamsResult] VALUES ('ATH', 11, 14);