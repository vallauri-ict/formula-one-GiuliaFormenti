CREATE TABLE [dbo].[TeamResult] (
  [trCode] int IDENTITY(1,1),
  [teamCode] varchar(3) NOT NULL,
  [raceCode] int NOT NULL default 0,
  [resultCode] int NOT NULL default 0,
  [trTeamPoits] int NOT NULL default 0,
  PRIMARY KEY ([trCode])
);