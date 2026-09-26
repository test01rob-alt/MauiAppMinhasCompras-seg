using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _db;

        public SQLiteDatabaseHelper(string path)
        {
            _db = new SQLiteAsyncConnection(path);
            _db.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _db.InsertAsync(p);
        }

        public Task<List<Produto>> GetAll()
        {
            return _db.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> GetProdutosPorCategoria(string categoria)
        {
            return _db.Table<Produto>()
                      .Where(p => p.Categoria == categoria)
                      .ToListAsync();
        }

        public async Task<double> GetTotalPorCategoria(string categoria)
        {
            var produtos = await GetProdutosPorCategoria(categoria);
            return produtos.Sum(p => p.Total);
        }
    }
}