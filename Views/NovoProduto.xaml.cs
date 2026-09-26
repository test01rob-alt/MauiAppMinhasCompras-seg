using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Verifica se a tela recebeu um produto por BindingContext (se veio para editar)
            if (BindingContext is Produto produto_anexado)
            {
                // ATUALIZA o produto existente
                Produto p = new Produto
                {
                    Id = produto_anexado.Id,
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                    Categoria = pck_categoria.SelectedItem?.ToString() ?? "Outros"
                };

                await App.Database.Update(p);
                await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            }
            else
            {
                // INSERE um produto novo (caso tenha aberto a tela pelo botão "+")
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                    Categoria = pck_categoria.SelectedItem?.ToString() ?? "Outros"
                };

                await App.Database.Insert(p);
                await DisplayAlert("Sucesso", "Produto cadastrado!", "OK");
            }

            // Retorna para a tela de listagem
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            // Tratamento de exceções try-catch pedido na agenda
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}