using DatabaseLibrary;
using GoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UnNammed.Service
{
    public class DBService
    {
        public MySqlHandler DatabaseCommunicator { get; }

        public DBService(string hostName = "localhost", string userName = "root", string password = "", string dbName = "unnamed",
            string engine = "InnoDB", string characterSet = "latin1", string collation = "latin1_swedish_ci")
        {
            DatabaseCommunicator = new MySqlHandler(hostName, userName, password, dbName)
            {
                StorageEngine = engine
            };

            InitializeDB();
        }

        public BooleanMsg Initialized { get; private set; }

        public BooleanMsg InitializeDB()
        {
            if (Initialized)
                return Initialized;

            DatabaseCommunicator.CheckAndCreateDatabase();

            string init = "";

            if (!DatabaseCommunicator.IsConnected)
            {
                DatabaseCommunicator.Connect().OnFailure(res => { init += res; });
            }

            if (init.Length > 0)
            {
                Initialized = new BooleanMsg(false, init);
                return Initialized;
            }

            Initialized = new BooleanMsg(true);
            return Initialized;
        }

        public BooleanMsg IsTableExist(string name)
        {
            var init = InitializeDB();
            if (!init)
                return false;

            return DatabaseCommunicator.TableExists(name);
        }

        public bool CreateTable(string name, ColumnDetails[] columns)
        {
            var init = InitializeDB();
            if (!init)
                return false;

            return DatabaseCommunicator.CreateTable(name, columns);
        }

    }
}
