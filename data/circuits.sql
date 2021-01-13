CREATE TABLE [dbo].[Circuit] (
  [circuitCode] int IDENTITY(1,1),
  [circuitName] varchar(200) NOT NULL default '',
  [circuitCountry] varchar(2) NOT NULL default '',
  [circuitCity] varchar(200) NOT NULL default '',
  [circuitMlength] int NOT NULL default 1,
  [image] varchar(200) NOT NULL default '',
  PRIMARY KEY ([circuitCode])
);

INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Red Bull Ring', 'AT', 'Spielberg', 4318);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Hungaroring', 'HU', 'Mogyrod', 4381);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Silverstone Circuit', 'GB', 'Silverstone', 5891);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Circuit de Barcelona- Catalunya', 'ES', 'Barcellona', 4655);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Circuit de Spa-Francorchamps', 'BE', 'Francorchamps', 7004);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Autodromo Nazionale di Monza', 'IT', 'Monza', 5793);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Autodromo Internazionale del Mugello', 'IT', 'Firenze', 5245);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Sochi Autodrom', 'RU', 'Sochi', 5848);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Nürburgring', 'DE', 'Nürburg', 5148);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Autódromo Internacional do Algarve', 'PT', 'Portimão', 4684);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Autodromo Enzo e Dino Ferrari', 'IT', 'Imola', 4909);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Intercity istambul Park', 'TR', 'Akfirat', 5338);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Barhain International Circuit', 'BH', 'Sakhir', 5412);
INSERT INTO [Circuit] (circuitName, circuitCountry, circuitCity, circuitMlength) 
VALUES ('Yas Marina Circuit', 'AE', 'Isola Yas', 5554);