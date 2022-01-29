using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NomeProduto { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Preco { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantidade { get; set; }
        [Required]
        public string ImagemUrl { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Tipo { get; set; }
    }
}