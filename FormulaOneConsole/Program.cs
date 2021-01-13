using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using FormulaOneDLL;

namespace FormulaOneConsole
{
    class Program
    {
        //public const string WORKINGPATH = @"C:\data\formulaone\";
        //private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        //public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\\Data\\";
        //public static string DB = "[" + WORKINGPATH + "FormulaOne.mdf]";

        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string[] tableNames = { "Country", "Driver", "Team", "Circuit", "Race", "Result", "TeamResult" };

        private static string DB_PATH = System.Environment.CurrentDirectory;
        private static string RESTORE_CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DB_PATH + @"\FormulaOne.bak; Integrated Security=True";
        private static string DB_NAME = @"D:\USERS\DIEGO\DESKTOP\SCUOLA\CSHARP-CODE\BACKUPMDFDB\BACKUPMDFDB\BIN\DEBUG\PROVA.MDF";

        static void Main(string[] args)
        {
            //Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);
            //utilities.copySQLFiles(THISDATAPATH);
            char scelta = ' ';
            do
            {
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Country");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Driver");
                Console.WriteLine("4 - Create Circuit");
                Console.WriteLine("5 - Create Race");
                Console.WriteLine("6 - Create Result");
                Console.WriteLine("7 - Create TeamResult");
                Console.WriteLine("8 - Create Constraints");
                Console.WriteLine("------------------");
                Console.WriteLine("C - DROP CONSTRAINTS");
                Console.WriteLine("R - RESET DB");
                Console.WriteLine("------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        Utils.ExecuteSqlScript("countries.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case '2':
                        Utils.ExecuteSqlScript("teams.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case '3':
                        Utils.ExecuteSqlScript("drivers.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case '4':
                        Utils.ExecuteSqlScript("circuits.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case '5':
                        Utils.ExecuteSqlScript("races.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case '6':
                        Utils.ExecuteSqlScript("results.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case '7':
                        Utils.ExecuteSqlScript("teamResults.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case '8':
                        Utils.ExecuteSqlScript("constraints.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case 'C':
                        Utils.ExecuteSqlScript("dropConstraints.sql", WORKINGPATH, CONNECTION_STRING);
                        break;
                    case 'R':
                        Utils.ResetDB();
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }
    }
}
