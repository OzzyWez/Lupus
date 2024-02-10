using Lupus.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lupus.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection connection;
        public Database() 
        {
            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir,"Lupus.db");

            var dbStringConnection = new SQLiteConnectionString(databasePath);
            connection = new SQLiteAsyncConnection(dbStringConnection);

            var response = InitializeDB();
        }

        private async Task InitializeDB()
        {
            await connection.CreateTableAsync<Players>();
        }
    }
}
