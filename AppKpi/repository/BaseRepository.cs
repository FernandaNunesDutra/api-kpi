using SQLite;
using System.Threading.Tasks;

namespace AppKpi.repository
{
    public class BaseRepository<T> where T : class, new()
    {
        private SQLiteAsyncConnection _connection;

        public BaseRepository(SQLiteAsyncConnection connection)
        {
            _connection = connection;
        }

        public AsyncTableQuery<T> GetAll() => _connection.Table<T>();

        public async Task<int> Add(T obj) => await _connection.InsertAsync(obj);

        public async Task Update(T obj) => await _connection.UpdateAsync(obj);

        public async Task Delete(T obj) => await _connection.DeleteAsync(obj);

        public async Task<T> GetById(int id) => await _connection.FindAsync<T>(id);

        public async Task<int> GetLastInsertId() => await _connection.ExecuteScalarAsync<int>("SELECT last_insert_rowid()");

    }
}

