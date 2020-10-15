CREATE TABLE [dbo].[Team] (
[teamCode] varchar(3) NOT NULL,
[teamFullName] varchar(100) NOT NULL default '',
[teamBase] varchar(100) NOT NULL default '',
[teamChief] varchar(100) NOT NULL default '',
[teamPowerUnit] varchar(100) NOT NULL default '',
[teamWorldChampionships] int NOT NULL default 0,
[teamPolePositions] int NOT NULL default 0,
[teamImage] varchar(200) NOT NULL default '',
PRIMARY KEY ([teamCode])
);

INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('MER', 'Mercedes-AMG Petronas F1 Team', 'Brackley, United Kingdom', 'Toto Wolff', 'Mercedes', 6, 113);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('ASM', 'Aston Martin Red Bull Racing', 'Milton Keynes, United Kingdom', 'Christian Horner', 'Honda', 4, 62);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('MCL', 'McLaren F1 Team', 'Woking, United Kingdom', 'Andreas Seidl', 'Renault', 8, 155);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('BWT', 'BWT Racing Point F1 Team', 'Silverstone, United Kingdom', 'Otmar Szafnauer', 'BWT Mercedes', 0, 0);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('REN', 'Renault DP World F1 Team', 'Enstone, United Kingdom', 'Cyril Abiteboul', 'Renault', 2, 20);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('FER', 'Scuderia Ferrari Mission Winnow', 'Maranello, Italy', 'Mattia Binotto', 'Ferrari', 16, 221);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('ATH', 'Scuderia AlphaTauri Honda', 'Faenza, Italy', 'Franz Tost', 'Honda', 0, 1);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('ARR', 'Alfa Romeo Racing ORLEN', 'Hinwil, Switzerland', 'Frédéric Vasseur', 'Ferrari', 0, 1);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('HAA', 'Haas F1 Team', 'Kannapolis, United States', 'Guenther Steiner', 'Ferrari', 0, 0);
INSERT INTO [Team] (teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('WLR', 'Williams Racing', 'Grove, United Kingdom', 'Simon Roberts', 'Mercedes', 9, 129);