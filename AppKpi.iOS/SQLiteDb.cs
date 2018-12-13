using AppKpi.iOS;
using SQLite;
using System;
using System.IO;
using AppKpi.dependencyservice;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace AppKpi.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}