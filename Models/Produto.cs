using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }

        // Campo da Categoria (Desafio 1)
        public string Categoria { get; set; }

        // Propriedade para calcular o total do item
        public double Total => Quantidade * Preco;
    }
}