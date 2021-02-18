using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace FormulaOneDLL
{
    public class Utils
    {
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public const string WORKINGPATH = @"C:\data\formulaone\";

        private static string DB_PATH = System.Environment.CurrentDirectory;
        private static string RESTORE_CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DB_PATH + @"\FormulaOne.bak; Integrated Security=True";
        private static string DB_NAME = "[" + WORKINGPATH + "FormulaOne.mdf]";

        public static string[] tables = { "Country", "Driver", "Team", "Circuit", "Race", "Result", "TeamResult" };
        private static string[] sqls = { "countries.sql", "drivers.sql", "teams.sql", "circuits.sql", "races.sql", "results.sql", "teamResults.sql" };

        public static bool ExecuteSqlScript(string sqlScriptName, string WORKINGPATH, string CONNECTION_STRING, string tab = "")
        {
            bool retVal = true;
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");

            if (sqlScriptName == "drop.sql")
            {
                fileContent = fileContent.Replace("table_name", tab);
            }

            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);
            con.Open();
            int i = 0;
            int nErr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    nErr++;
                    retVal = false;
                }
            }
            string finalMessage = nErr == 0 ? "Script " + sqlScriptName + " completed successfully without errors" : "Script " + sqlScriptName + " completed with " + nErr + " errors";
            Console.WriteLine(finalMessage);
            return retVal;
        }

        //public static List<string> GetTable(string table_name)
        //{
        //    List<string> retVal = new List<string>();

        //    using (SqlConnection dbConn = new SqlConnection())
        //    {
        //        dbConn.ConnectionString = CONNECTION_STRING;
        //        dbConn.Open();
        //        Console.WriteLine("\nQuery data example:");
        //        Console.WriteLine("=========================================\n");
        //        string sql = "SELECT * FROM " + table_name;
        //        using (SqlCommand command = new SqlCommand(sql, dbConn))
        //        {
        //            dbConn.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    string IsoCod = reader.GetString(0);
        //                    string descr = reader.GetString(1);
        //                    Console.WriteLine("{0} {1}", IsoCod, descr);
        //                }
        //            }
        //        }
        //    }
        //    return retVal;
        //}

        public static DataTable GetDataTable(string table)
        {
            DataTable retVal = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = $"SELECT * FROM {table}";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(retVal);
            con.Close();
            da.Dispose();
            return retVal;
        }

        public static List<string> GetTablesNames()
        {
            List<string> tables = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                StringBuilder sb = new StringBuilder();
                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader.GetString(0));
                            tables.Add($"{reader.GetString(0)}");
                        }
                    }
                }
            }
            return tables;
        }

        public static void ResetDB()
        {
            Backup();
            try
            {
                ExecuteSqlScript("dropConstraints.sql", WORKINGPATH, CONNECTION_STRING);
                Console.WriteLine("Dropping tables...");
                for (int i = 0; i < tables.Length; i++)
                {
                    DropTable(tables[i]);
                }
                Console.WriteLine("Recreating tables...");
                for(int i = 0; i < sqls.Length; i++)
                {
                    ExecuteSqlScript(sqls[i], WORKINGPATH, CONNECTION_STRING);
                }
                ExecuteSqlScript("constraints.sql", WORKINGPATH, CONNECTION_STRING);
                Console.WriteLine("Reset DB done");
            }
            catch (Exception)
            {
                Restore();
                Console.WriteLine("Reset gone wrong. The DB has been restored");
            }
        }

        private static void DropTable(string tableName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DROP TABLE IF EXISTS " + tableName + ";", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table " + tableName + " dropped ");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " -->" + ex.Errors);
            }
            con.Close();
        }

        private static void Backup()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + DB_NAME + "] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + DB_NAME + "] TO DISK='" + DB_PATH + @"\prova.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Restore()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    string sqlStmt2 = string.Format(@"ALTER DATABASE [" + DB_NAME + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = @"USE MASTER RESTORE DATABASE [" + DB_NAME + "] FROM DISK='" + DB_PATH + @"\prova.bak' WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format(@"ALTER DATABASE [" + DB_NAME + "] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    Console.WriteLine("database restoration done successefully");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }




        //********************************COUNTRY************************************
        public static List<Models.Country> GetTableCountry()
        {
            List<Models.Country> retVal = new List<Models.Country>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Country;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string isoCode = reader.GetString(0);
                            string CountryName = reader.GetString(1);
                            retVal.Add(new Models.Country(isoCode, CountryName));
                        }
                    }
                }
            }
            //DataTable val = ToDataTable(retVal);
            return retVal;
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static Models.Country GetTableCountryByCode(string code)
        {
            Models.Country retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Country WHERE countryCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string isoCode = reader.GetString(0);
                            string CountryName = reader.GetString(1);
                            retVal = new Models.Country(isoCode, CountryName);
                        }
                    }
                }
            }
            return retVal;
        }


        //********************************DRIVER************************************
        public static List<Models.Driver> GetTableDriver()
        {
            List<Models.Driver> retVal = new List<Models.Driver>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Driver;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int driverCode = reader.GetInt32(0);
                            int driverNumber = reader.GetInt32(1);
                            string driverFirstname = reader.GetString(2);
                            string driverLastname = reader.GetString(3);
                            //string driverTeamCode = reader.GetString(4);
                            string driverNationality = reader.GetString(5);
                            DateTime driverDateOfBirth = reader.GetDateTime(6);
                            string driverPlaceOfBirth = reader.GetString(7);
                            string driverImage = reader.GetString(8);
                            string driverTeamCode = reader.GetString(9);

                            retVal.Add(new Models.Driver(driverCode, driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, driverImage, driverTeamCode));
                        }
                    }
                }
            }
            return retVal;
        }

        public static Models.Driver GetTableDriverByCode(int code)
        {
            Models.Driver retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Driver WHERE driverCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int driverCode = reader.GetInt32(0);
                            int driverNumber = reader.GetInt32(1);
                            string driverFirstname = reader.GetString(2);
                            string driverLastname = reader.GetString(3);
                            //string driverTeamCode = reader.GetString(4);
                            string driverNationality = reader.GetString(5);
                            DateTime driverDateOfBirth = reader.GetDateTime(6);
                            string driverPlaceOfBirth = reader.GetString(7);
                            string driverImage = reader.GetString(8);
                            string driverTeamCode = reader.GetString(9);
                            retVal = new Models.Driver(driverCode, driverNumber, driverFirstname, driverLastname, driverNationality, driverDateOfBirth, driverPlaceOfBirth, driverImage, driverTeamCode);
                        }
                    }
                }
            }
            return retVal;
        }


        //********************************TEAM************************************
        public static List<Models.Team> GetTableTeam()
        {
            List<Models.Team> retVal = new List<Models.Team>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Team;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamCode = reader.GetString(0);
                            string teamFullName = reader.GetString(1);
                            string teamBase = reader.GetString(2);
                            string teamChief = reader.GetString(3);
                            string teamPowerUnit = reader.GetString(4);
                            int teamWorldChampionships = reader.GetInt32(5);
                            int teamPolePositions = reader.GetInt32(6);
                            string teamImage = reader.GetString(7);

                            retVal.Add(new Models.Team(teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions, teamImage));
                        }
                    }
                }
            }
            return retVal;
        }

        public static Models.Team GetTableTeamByCode(string code)
        {
            Models.Team retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Team WHERE teamCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamCode = reader.GetString(0);
                            string teamFullName = reader.GetString(1);
                            string teamBase = reader.GetString(2);
                            string teamChief = reader.GetString(3);
                            string teamPowerUnit = reader.GetString(4);
                            int teamWorldChampionships = reader.GetInt32(5);
                            int teamPolePositions = reader.GetInt32(6);
                            string teamImage = reader.GetString(7);
                            retVal = new Models.Team(teamCode, teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions, teamImage);
                        }
                    }
                }
            }
            return retVal;
        }


        //********************************CIRCUIT************************************
        public static List<Models.Circuit> GetTableCircuit()
        {
            List<Models.Circuit> retVal = new List<Models.Circuit>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Circuit;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int circuitCode = reader.GetInt32(0);
                            string circuitName = reader.GetString(1);
                            string circuitCountry = reader.GetString(2);
                            string circuitCity = reader.GetString(3);
                            int circuitMlength = reader.GetInt32(4);
                            string image = reader.GetString(5);

                            retVal.Add(new Models.Circuit(circuitCode, circuitName, circuitCountry, circuitCity, circuitMlength, image));
                        }
                    }
                }
            }
            return retVal;
        }

        public static Models.Circuit GetTableCircuitByCode(int code)
        {
            Models.Circuit retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Circuit WHERE circuitCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int circuitCode = reader.GetInt32(0);
                            string circuitName = reader.GetString(1);
                            string circuitCountry = reader.GetString(2);
                            string circuitCity = reader.GetString(3);
                            int circuitMlength = reader.GetInt32(4);
                            string image = reader.GetString(5);
                            retVal = new Models.Circuit(circuitCode, circuitName, circuitCountry, circuitCity, circuitMlength, image);
                        }
                    }
                }
            }
            return retVal;
        }


        //********************************RACE************************************
        public static List<Models.Race> GetTableRace()
        {
            List<Models.Race> retVal = new List<Models.Race>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Race;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int raceCode = reader.GetInt32(0);
                            int circuitCode = reader.GetInt32(1);
                            string raceName = reader.GetString(2);
                            DateTime raceDate = reader.GetDateTime(3);
                            string raceTime = reader.GetString(4);
                            int nLaps = reader.GetInt32(5);
                            string raceURL = reader.GetString(6);

                            retVal.Add(new Models.Race(raceCode, circuitCode, raceName, raceDate, raceTime, nLaps, raceURL));
                        }
                    }
                }
            }
            return retVal;
        }

        public static Models.Race GetTableRaceByCode(int code)
        {
            Models.Race retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Race WHERE raceCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int raceCode = reader.GetInt32(0);
                            int circuitCode = reader.GetInt32(1);
                            string raceName = reader.GetString(2);
                            DateTime raceDate = reader.GetDateTime(3);
                            string raceTime = reader.GetString(4);
                            int nLaps = reader.GetInt32(5);
                            string raceURL = reader.GetString(6);
                            retVal = new Models.Race(raceCode, circuitCode, raceName, raceDate, raceTime, nLaps, raceURL);
                        }
                    }
                }
            }
            return retVal;
        }


        //********************************RESULT************************************
        public static List<Models.Result> GetTableResult()
        {
            List<Models.Result> retVal = new List<Models.Result>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Result;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int resultCode = reader.GetInt32(0);
                            int raceCode = reader.GetInt32(1);
                            int driverCode = reader.GetInt32(2);
                            string teamCode = reader.GetString(3);
                            string resultPosition = reader.GetString(4);
                            string resultTime = reader.GetString(5);
                            int resultNlap = reader.GetInt32(6);
                            int resultPoints = reader.GetInt32(7);
                            int resultFastestLap = reader.GetInt32(8);
                            int resultFastestLapTime = reader.GetInt32(9);

                            retVal.Add(new Models.Result(resultCode, raceCode, driverCode, teamCode, resultPosition, resultTime, resultNlap, resultPoints, resultFastestLap, resultFastestLapTime));
                        }
                    }
                }
            }
            return retVal;
        }

        public static Models.Result GetTableResultByCode(int code)
        {
            Models.Result retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Result WHERE resultCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int resultCode = reader.GetInt32(0);
                            int raceCode = reader.GetInt32(1);
                            int driverCode = reader.GetInt32(2);
                            string teamCode = reader.GetString(3);
                            string resultPosition = reader.GetString(4);
                            string resultTime = reader.GetString(5);
                            int resultNlap = reader.GetInt32(6);
                            int resultPoints = reader.GetInt32(7);
                            int resultFastestLap = reader.GetInt32(8);
                            int resultFastestLapTime = reader.GetInt32(9);
                            retVal = new Models.Result(resultCode, raceCode, driverCode, teamCode, resultPosition, resultTime, resultNlap, resultPoints, resultFastestLap, resultFastestLapTime);
                        }
                    }
                }
            }
            return retVal;
        }


        //********************************TEAM RESULT************************************
        public static List<Models.TeamResult> GetTableTeamResult()
        {
            List<Models.TeamResult> retVal = new List<Models.TeamResult>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM TeamResult;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int trCode = reader.GetInt32(0);
                            string teamCode = reader.GetString(3);
                            int raceCode = reader.GetInt32(7);
                            int resultCode = reader.GetInt32(8);
                            int trTeamPoits = reader.GetInt32(9);

                            retVal.Add(new Models.TeamResult(trCode, teamCode, raceCode, resultCode, trTeamPoits));
                        }
                    }
                }
            }
            return retVal;
        }

        public static Models.TeamResult GetTableTeamResultByCode(int code)
        {
            Models.TeamResult retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM TeamResult WHERE trCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int trCode = reader.GetInt32(0);
                            string teamCode = reader.GetString(3);
                            int raceCode = reader.GetInt32(7);
                            int resultCode = reader.GetInt32(8);
                            int trTeamPoits = reader.GetInt32(9);
                            retVal = new Models.TeamResult(trCode, teamCode, raceCode, resultCode, trTeamPoits);
                        }
                    }
                }
            }
            return retVal;
        }
    }
}
