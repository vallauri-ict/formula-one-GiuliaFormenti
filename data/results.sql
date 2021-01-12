CREATE TABLE [dbo].[Result] (
  [resultCode] int IDENTITY(1,1),
  [raceCode] int NOT NULL default 0,
  [driverCode] int NOT NULL default 0,
  [teamCode] varchar(3) NOT NULL,
  [resultPosition] varchar(200) NOT NULL default '',
  [resultTime] varchar(200) NOT NULL default '',
  [resultNlap] int NOT NULL default 0,
  [resultPoints] int NOT NULL default 0,
  [resultFastestLap] int NOT NULL default 0,
  [resultFastestLapTime] int NOT NULL default 0,
  PRIMARY KEY ([resultCode])
);