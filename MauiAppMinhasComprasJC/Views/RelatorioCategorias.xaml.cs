using System.Collections.ObjectModel;
using MauiAppMinhasComprasJC.Models;

namespace MauiAppMinhasComprasJC.ViewModels;

public class RelatorioCategoriasViewModel : BaseViewModel
{
    public ObservableCollection<RelatorioCategoria> Relatorio { get; set; }

    public RelatorioCategoriasViewModel()
    {
        CarregarRelatorio();
    }

    private async void CarregarRelatorio()
    {
        var produtos = await App.Db.GetAll();

        var dados = produtos
            .GroupBy(p => p.Categoria)
            .Select(g => new RelatorioCategoria
            {
                Categoria = g.Key,
                Total = g.Sum(p => p.Total)
            });

        Relatorio = new ObservableCollection<RelatorioCategoria>(dados);
        OnPropertyChanged(nameof(Relatorio));
    }
}

public class RelatorioCategoria
{
    public string Categoria { get; set; }
    public double Total { get; set; }
}