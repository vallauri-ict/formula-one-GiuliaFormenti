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
PRIMARY KEY ([driverCode])
);

INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (44, 'Lewis', 'Hamilton', 'GB', '19850107', 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (77, 'Valtteri', 'Bottas', 'GB', '19890828', 'Finland');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (33, 'Max', 'Verstappen', 'GB', '19970930', 'Belgium');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (4, 'Lando', 'Norris', 'GB', '19991113', 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (23, 'Alexander', 'Albon', 'GB', '19960323', 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (3, 'Daniel', 'Ricciardo', 'GB', '19890701', 'Australia');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (16, 'Charles', 'Leclerc', 'GB', '19971016', 'Monaco');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (18, 'Lance', 'Stroll', 'GB', '19981029', 'Canada');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (11, 'Sergio', 'Perez', 'GB', '19900126', 'Mexico');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (10, 'Pierre', 'Gasly', 'GB', '19960207', 'France');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (55, 'Carlos', 'Sainz', 'GB', '19940901', 'Spain');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (31, 'Esteban', 'Ocon', 'GB', '19960917', 'Normandy');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (5, 'Sebastian', 'Vettel', 'GB', '19870703', 'Germany');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (26, 'Daniil', 'Kvyat', 'GB', '19940426', 'Russia');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (27, 'Nicp', 'Hulkenberg', 'GB', '19870819', 'Germany');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (7, 'Kimi', 'Räikkönen', 'GB', '19791017', 'Finland');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (99, 'Antonio', 'Giovinazzi', 'GB', '19931214', 'Italy');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (20, 'Kevin', 'Magnussen', 'GB', '19921005', 'Denmark');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (6, 'Nicholas', 'Latifi', 'GB', '19950629', 'Canada');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (63, 'George', 'Russell', 'GB', '19980215', 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth)
VALUES (8, 'Romain', 'Grosjean', 'GB', '19860417', 'Switzerland');