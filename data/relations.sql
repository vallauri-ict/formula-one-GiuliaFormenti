ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [driverCountry] FOREIGN KEY([driverNationality])
REFERENCES [dbo].[Country] ([countryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [driverTeam] FOREIGN KEY([teamCode])
REFERENCES [dbo].[Team] ([teamCode])
ON UPDATE CASCADE;