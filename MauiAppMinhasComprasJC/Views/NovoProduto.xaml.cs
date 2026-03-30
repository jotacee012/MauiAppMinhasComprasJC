using MauiAppMinhasComprasJC.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void btn_salvar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = double.Parse(txt_quantidade.Text),
                Preco = double.Parse(txt_preco.Text),
                Categoria = picker_categoria.SelectedItem?.ToString()
            };

            await App.Db.Save(p);

            await DisplayAlert("OK", "Produto salvo!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}