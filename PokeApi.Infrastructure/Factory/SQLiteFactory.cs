using System.Data;
using System.Data.SQLite;

namespace PokeApi.Infrastructure.Factory
{
    public class SQLiteFactory
    {
        public IDbConnection SQLiteConnection()
        {
            return new SQLiteConnection("Data Source=C:\\Users\\Magacho\\Documents\\DBPokeApi\\DB_PokeAPI.db;Version=3;Pooling=true");
        }
    }
}