using MauiAppMinhasComprasJC.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiAppMinhasComprasJC.ViewModels;

public class ListaProdutosViewModel : BaseViewModel
{
    public ObservableCollection<Produto> Produtos { get; set; } = new();
    public List<string> Categorias { get; } = new()
    {
        "Todas",
        "Alimentos",
        "Higiene",
        "Limpeza",
        "Outros"
    };

    private string categoriaSelecionada = "Todas";
    public string CategoriaSelecionada
    {
        get => categoriaSelecionada;
        set
        {
            categoriaSelecionada = value;
            OnPropertyChanged();
            FiltrarProdutos();
        }
    }

    private List<Produto> todosProdutos = new();

    public ListaProdutosViewModel()
    {
        CarregarProdutos();
    }

    private async void CarregarProdutos()
    {
        todosProdutos = await App.Db.GetAll();

        Produtos.Clear();
        foreach (var p in todosProdutos)
            Produtos.Add(p);
    }

    private void FiltrarProdutos()
    {
        Produtos.Clear();

        var filtrados = categoriaSelecionada == "Todas"
            ? todosProdutos
            : todosProdutos.Where(p => p.Categoria == categoriaSelecionada);

        foreach (var p in filtrados)
            Produtos.Add(p);
    }

    public ICommand NovoProdutoCommand => new Command(async () =>
    {
        await Shell.Current.Navigation.PushAsync(new Views.NovoProduto());
    });
}