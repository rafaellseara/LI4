namespace MontagemBelasPizzas.Data.Entities.Produtos
{
    public class Montagem
    {
        public int Id { get; set; } // Chave primária
        public int IdIngrediente { get; set; } // FK para Ingrediente
        public int IdProduto { get; set; } // FK para Produto
        public int Ordem { get; set; } // Ordem da montagem
        public string Descricao { get; set; } // Descrição do passo da montagem
    }
}
