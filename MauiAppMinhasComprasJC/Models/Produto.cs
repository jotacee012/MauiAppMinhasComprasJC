using SQLite;

namespace MauiAppMinhasComprasJC.Models
{
    public class Produto
    {
        string _descricao;
        string _categoria;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha a descrição");

                _descricao = value;
            }
        }

        public double Quantidade { get; set; }
        public double Preco { get; set; }

        public double Total => Quantidade * Preco;

        public string Categoria
        {
            get => _categoria;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha a categoria");

                _categoria = value;
            }
        }
    }
}