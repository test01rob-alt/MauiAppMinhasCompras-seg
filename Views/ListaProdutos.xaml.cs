using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProdutos : ContentPage
{
    public ListaProdutos()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarProdutos();
    }

    private async Task CarregarProdutos()
    {
        var lista = await App.Database.GetAll();
        lst_produtos.ItemsSource = lista;
        lbl_total_categoria.Text = $"Total Geral: R$ {lista.Sum(p => p.Total):F2}";
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoProduto());
    }

    private async void pck_filtro_categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        string categoriaSelecionada = pck_filtro_categoria.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(categoriaSelecionada) || categoriaSelecionada == "Todas")
        {
            await CarregarProdutos();
        }
        else
        {
            var listaFiltrada = await App.Database.GetProdutosPorCategoria(categoriaSelecionada);
            lst_produtos.ItemsSource = listaFiltrada;

            double total = await App.Database.GetTotalPorCategoria(categoriaSelecionada);
            lbl_total_categoria.Text = $"Total ({categoriaSelecionada}): R$ {total:F2}";
        }
    }
}