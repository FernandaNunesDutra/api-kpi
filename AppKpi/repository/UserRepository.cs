using System;
using System.Collections.Generic;
using System.Text;
using AppKpi.model;
using SQLite;

namespace AppKpi.repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(SQLiteAsyncConnection connection)
            : base(connection)
        {
        }
    }
}
