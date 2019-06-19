using GrayDog.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrayDog
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        //public Task<List<T>> GetTableDataAsync<T>()where T:class
        //{
        //    return _database.Table<T>().ToListAsync();
        //}

        //public Task<int> AddTableDataAsync(T )
    }
}
