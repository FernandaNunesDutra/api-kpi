using SQLite;

namespace AppKpi.dependencyservice
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
