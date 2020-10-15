CREATE TABLE [dbo].[Driver] (
[driverCode] int IDENTITY,
[driverNumber] int NOT NULL default 0,
[driverFirstname] varchar(128) NOT NULL default '',
[driverLastname] varchar(128) NOT NULL default '',
[driverTeamCode] varchar(3) NOT NULL default '',
[driverNationality] varchar(2) NOT NULL default '',
[driverDateOfBirth] date NOT NULL default '19900703',
[driverPlaceOfBirth] varchar(64) NOT NULL default '',
[driverImage] varchar(200) NOT NULL default '',
[teamCode] int NOT NULL default 0,
PRIMARY KEY ([driverCode])
);

INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (44, 'Lewis', 'Hamilton', 'GB', '19850107', 'England', 'MER');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (77, 'Valtteri', 'Bottas', 'FI', '19890828', 'Finland', 'MER');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (33, 'Max', 'Verstappen', 'BE', '19970930', 'Belgium', 'ASM');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (4, 'Lando', 'Norris', 'GB', '19991113', 'England', 'MCL');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (23, 'Alexander', 'Albon', 'GB', '19960323', 'England', 'ASM');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (3, 'Daniel', 'Ricciardo', 'AU', '19890701', 'Australia', 'REN');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (16, 'Charles', 'Leclerc', 'MC', '19971016', 'Monaco', 'FER');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (18, 'Lance', 'Stroll', 'CA', '19981029', 'Canada', 'BWT');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (11, 'Sergio', 'Perez', 'MX', '19900126', 'Mexico', 'BWT');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (10, 'Pierre', 'Gasly', 'FR', '19960207', 'France', 'ATH');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (55, 'Carlos', 'Sainz', 'ES', '19940901', 'Spain', 'MCL');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (31, 'Esteban', 'Ocon', 'FR', '19960917', 'Normandy', 'REN');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (5, 'Sebastian', 'Vettel', 'DE', '19870703', 'Germany', 'FER');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (26, 'Daniil', 'Kvyat', 'RU', '19940426', 'Russia', 'ATH');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (27, 'Nico', 'Hulkenberg', 'DE', '19870819', 'Germany', 'BWT');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (7, 'Kimi', 'Räikkönen', 'FI', '19791017', 'Finland', 'ARR');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (99, 'Antonio', 'Giovinazzi', 'IT', '19931214', 'Italy', 'ARR');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (20, 'Kevin', 'Magnussen', 'DK', '19921005', 'Denmark', 'HAA');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (6, 'Nicholas', 'Latifi', 'CA', '19950629', 'Canada', 'WLR');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (63, 'George', 'Russell', 'GB', '19980215', 'England', 'WLR');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, teamCode)
VALUES (8, 'Romain', 'Grosjean', 'CH', '19860417', 'Switzerland', 'HAA');