using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MisBoletos.Models;

namespace MisBoletos.Data
{
    public class BoletoDataBase
    {
        private readonly SQLiteAsyncConnection _db;

        public BoletoDataBase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Boleto>().Wait();
        }

        public Task<List<Boleto>> GetAllAsync()
            => _db.Table<Boleto>().OrderBy(b => b.Numero).ToListAsync();

        public Task<Boleto?> GetByNumeroAsync(int numero)
            => _db.Table<Boleto>().Where(b => b.Numero == numero).FirstOrDefaultAsync();

        public Task<int> InsertAsync(Boleto boleto)
            => _db.InsertAsync(boleto);

        public Task<int> DeleteAsync(Boleto boleto)
            => _db.DeleteAsync(boleto);

        public Task<int> DeleteAllAsync()
            => _db.DeleteAllAsync<Boleto>();

        // Helper: inserta solo si no existe
        public async Task<int> InsertIfNotExistsAsync(int numero)
        {
            var exists = await GetByNumeroAsync(numero);
            if (exists != null) return 0;
            return await InsertAsync(new Boleto { Numero = numero });
        }
    }
}
