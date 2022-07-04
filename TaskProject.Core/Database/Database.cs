using SQLite;
using System;
using System.Threading.Tasks;
using TaskProject.Core.Database.Abstractions;
using TaskProject.Core.Models;

namespace TaskProject.Core.Database
{
    public class Database : IDatabase
    {
        private const SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLiteOpenFlags.SharedCache;

        private SQLiteAsyncConnection _dbContext;

        public string Path => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public SQLiteAsyncConnection Connection => _dbContext;

        public async Task<bool> ConnectAsync(string dbName)
        {
            try
            {
                _dbContext = new SQLiteAsyncConnection($"{Path}/{dbName}.db3", Flags, false);

                await InitializeAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CloseAsync()
        {
            try
            {
                await _dbContext.CloseAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task InitializeAsync()
        {
            await _dbContext.CreateTablesAsync(CreateFlags.None,
                typeof(Movie)).
                ConfigureAwait(false);
        }
    }
}
