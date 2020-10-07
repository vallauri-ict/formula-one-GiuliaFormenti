CREATE TABLE [dbo].[Driver] (
[driverCode] int IDENTITY,
[driverNumber] int NOT NULL default 0,
[driverFirstname] varchar(128) NOT NULL default '',
[driverLastname] varchar(128) NOT NULL default '',
[driverDateOfBirth] date NOT NULL default '01/10/2020',
[driverPlaceOfBirth] varchar(64) NOT NULL default '',
[driverImage] varchar(200) NOT NULL default '',
PRIMARY KEY ([driverCode])
);

INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (44, 'Lewis', 'Hamilton', 07/01/1985, 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (77, 'Valtteri', 'Bottas', 28/08/1989, 'Finland');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (33, 'Max', 'Verstappen', 30/09/1997, 'Belgium');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (4, 'Lando', 'Norris', 13/11/1999, 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (23, 'Alexander', 'Albon', 23/03/1996, 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (3, 'Daniel', 'Ricciardo', 01/07/1989, 'Australia');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (16, 'Charles', 'Leclerc', 16/10/1997, 'Monaco');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (18, 'Lance', 'Stroll', 29/10/1998, 'Canada');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (11, 'Sergio', 'Perez', 26/01/1990, 'Mexico');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (10, 'Pierre', 'Gasly', 07/02/1996, 'France');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (55, 'Carlos', 'Sainz', 01/09/1994, 'Spain');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (31, 'Esteban', 'Ocon', 17/09/1996, 'Normandy');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (5, 'Sebastian', 'Vettel', 03/07/1987, 'Germany');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (26, 'Daniil', 'Kvyat', 26/04/1994, 'Russia');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (27, 'Nicp', 'Hulkenberg', 19/08/1987, 'Germany');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (7, 'Kimi', 'Räikkönen', 17/10/1979, 'Finland');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (99, 'Antonio', 'Giovinazzi', 14/12/1993, 'Italy');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (20, 'Kevin', 'Magnussen', 05/10/1992, 'Denmark');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (6, 'Nicholas', 'Latifi', 29/06/1995, 'Canada');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (63, 'George', 'Russell', 15/02/1998, 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (8, 'Romain', 'Grosjean', 17/04/1986, 'Switzerland');