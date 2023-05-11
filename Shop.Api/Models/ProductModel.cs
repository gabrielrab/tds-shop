using System.ComponentModel.DataAnnotations;
using Shop.Api.Models.Shared;

namespace Shop.Api.Models
{
    public class ProductModel : Entity
    {
        public ProductModel() { }

        public ProductModel(int id, string name, string description, string barcode, double price, int available_quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Barcode = barcode;
            Price = price;
            AvailableQuantity = available_quantity;
        }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "A descrição do produto é obrigatório")]
        public string Description { get; set; } = default!;

        [Required(ErrorMessage = "O código de barras do produto é obrigatório")]
        public string Barcode { get; set; } = default!;

        [Required(ErrorMessage = "O preço do produto é obrigatório")]
        public double Price { get; set; } = default!;

        [Required(ErrorMessage = "A quantidade em estoque do produto é obrigatório")]
        public int AvailableQuantity { get; set; } = default!;

    }
}