using AsientosFree.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.Services
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDatabase(string path)
        { 
            _db = new SQLiteAsyncConnection(path);
            _db.CreateTableAsync<Puc>();
            _db.CreateTableAsync<Transaccion>();
        }

        public Task<List<Puc>> GetPucsAsync()
        {
            return _db.Table<Puc>().ToListAsync();
        }

        public Task<int> AddPucAsync(Puc puc)
        { 
            return _db.InsertAsync(puc);
        }

        public Task<List<Transaccion>> GetTransaccionesAsync()
        {
            return _db.Table<Transaccion>().ToListAsync();
        }

        public Task<int> AddTransaccionAsync(Transaccion transaccion)
        {
            return _db.InsertAsync(transaccion);
        }

    }
}
