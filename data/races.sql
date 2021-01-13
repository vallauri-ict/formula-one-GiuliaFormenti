CREATE TABLE [dbo].[Race] (
  [raceCode] int IDENTITY(1,1),
  [circuitCode] int NOT NULL default '',
  [raceName] varchar(200) NOT NULL default '',
  [raceDate] date NOT NULL default '2020-07-05',
  [raceTime] varchar(10) NOT NULL default '14:30',
  [nLaps] int NOT NULL default 1,
  [raceURL] varchar(200) NOT NULL default '',
  PRIMARY KEY ([raceCode])
);


INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (1, 'GP AUSTRIA', '2020-07-05', '15:10', 71);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (1, 'GP AUSTRIA', '2020-07-12', '15:10', 12);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (2, 'GP UNGHERIA', '2020-08-02', '15:30', 70);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (3, 'GP GRAN BRETAGNA', '2020-08-02', '15:10', 52);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps)
VALUES (3, 'GP 70° ANNIVERSARIO F1', '2020-08-09', '15:10', 52);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (4, 'GP SPAGNA', '2020-05-10', '15:10', 66);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (5, 'GP BELGIO', '2020-08-30', '15:10', 44);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (6, 'GP ITALIA', '2020-09-06', '15:10', 53);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps)
VALUES (7, 'GP TOSCANA', '2020-09-13', '15:10', 59);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (8, 'GP RUSSIA', '2020-09-27', '13:10', 53);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (9, 'GP EIFEL', '2020-10-11', '14:10', 60);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (10, 'GP PORTOGALLO', '2020-10-25', '14:10', 66);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (11, 'GP EMILIA ROMAGNA', '2020-11-01', '14:10', 70);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (12, 'GP TURCHIA', '2020-11-15', '13:10', 53);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (13, 'GP BAHRAIN', '2020-11-29', '12:10', 66);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (14, 'GP SAKHIR', '2020-12-06', '18:10', 44);
INSERT INTO [Race] (circuitCode, raceName, raceDate, raceTime, nLaps) 
VALUES (15, 'GP ABU DHABI', '2020-12-13', '14:10', 71);