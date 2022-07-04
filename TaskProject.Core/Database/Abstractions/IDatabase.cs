using SQLite;
using System.Threading.Tasks;

namespace TaskProject.Core.Database.Abstractions
{
    public interface IDatabase
    {
        SQLiteAsyncConnection Connection { get; }

        Task<bool> ConnectAsync(string dbName);

        Task<bool> CloseAsync();
    }
}