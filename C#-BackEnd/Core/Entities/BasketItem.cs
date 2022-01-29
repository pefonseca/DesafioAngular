namespace Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string ImagemUrl { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
    }
}