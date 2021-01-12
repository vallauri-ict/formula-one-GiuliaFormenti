ALTER TABLE [dbo].[Driver] DROP CONSTRAINT [driver_country];

ALTER TABLE [dbo].[Driver] DROP CONSTRAINT [driver_team];

ALTER TABLE [dbo].[Circuit] DROP CONSTRAINT [circuit_country];

ALTER TABLE [dbo].[Race] DROP CONSTRAINT [race_circuit];

ALTER TABLE [dbo].[Result] DROP CONSTRAINT [result_race];

ALTER TABLE [dbo].[Result] DROP CONSTRAINT [result_driver];

ALTER TABLE [dbo].[Result] DROP CONSTRAINT [result_team];

ALTER TABLE [dbo].[TeamResult] DROP CONSTRAINT [tr_team];

ALTER TABLE [dbo].[TeamResult] DROP CONSTRAINT [tr_race];

ALTER TABLE [dbo].[TeamResult] DROP CONSTRAINT [tr_result];