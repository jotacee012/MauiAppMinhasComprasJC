using MauiAppMinhasComprasJC.Models;
using SQLite;

namespace MauiAppMinhasCompras;

public class Database
{
    private readonly SQLiteAsyncConnection _db;

    public Database()
    {
        var caminhoDb = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "minhascompras.db3");

        _db = new SQLiteAsyncConnection(caminhoDb);
        _db.CreateTableAsync<Produto>().Wait();
    }

    public Task<List<Produto>> GetAll()
    {
        return _db.Table<Produto>().ToListAsync();
    }

    public Task<int> Save(Produto produto)
    {
        if (produto.Id == 0)
            return _db.InsertAsync(produto);
        else
            return _db.UpdateAsync(produto);
    }

    public Task<int> Delete(Produto produto)
    {
        return _db.DeleteAsync(produto);
    }
}